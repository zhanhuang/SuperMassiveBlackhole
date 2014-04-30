using UnityEngine;
using System.Collections;

// Inherits from ShipOrbitBehavior
public class AllyShipAI : ShipOrbitBehavior {
	public float speed = 10f;
	public float turnSpeed = 10f;
	
	int health = 2;
	
	float fireCoolDown = 1f;
	float fireCoolDownRemaining = 0f;
	
	bool flashing = false;

	GameObject Laser;
	GameObject Explosion;
	
	// Use this for initialization
	void Start () {
		OrbitSetup();
		
		StartCoroutine(AvoidObstacle());
		
		// load prefabs
		Laser = (GameObject)Resources.Load("Laser_Green");
		Explosion = (GameObject)Resources.Load("Explosion_Player");
	}
	
	// Update is called once per frame
	void Update () {
		fireCoolDownRemaining -= Time.deltaTime;

		int enemyCounter = currentPlanet.transform.GetComponent<PlanetPopulation>().EnemyCounter;
		if(fireCoolDownRemaining < 0f && enemyCounter > 0){
			AutoFire();
			fireCoolDownRemaining = fireCoolDown;
		}

		if(enemyCounter <= 0){
			// after you clear the planet, no more shooting allies for loot
			transform.collider.enabled = false;
		}
	}
	
	void FixedUpdate () {
		rigidbody.AddForce(transform.forward.normalized * Time.deltaTime * speed * Random.Range(-1f,4f), ForceMode.VelocityChange);
		rigidbody.AddTorque(transform.up.normalized * Time.deltaTime * turnSpeed * Random.Range(-10f,10f), ForceMode.Force);
	}
	
	
	IEnumerator AvoidObstacle(){
		while(true){
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast(transform.position, transform.forward, out hit, 30f)){
				// check if the player is in front
				if (hit.transform.tag != "Enemy"){
					rigidbody.AddForce(-transform.forward.normalized * speed * 1f, ForceMode.VelocityChange);
					rigidbody.AddTorque(transform.up.normalized * turnSpeed * 0.5f, ForceMode.VelocityChange);
				}
			}
			yield return new WaitForSeconds(1f);
		}
	}
	
	void OnCollisionEnter(Collision collision){
		Vector3 collisionDir = (collision.transform.position -  transform.position).normalized;
		rigidbody.AddForce(-collisionDir * 20f, ForceMode.VelocityChange);
		rigidbody.AddTorque(transform.up.normalized * turnSpeed * 0.5f, ForceMode.VelocityChange);
	}
	
	public void TakeDamage(int damage){
		if(health <= 0){
			return;
		}
		health -= damage;
		if(health <= 0){
			currentPlanet.GetComponent<PlanetPopulation>().AllyDied();
			Die();
		} else{
			if(!flashing){
				flashing = true;
				StartCoroutine(DamageFlash());
			}
		}
	}
	
	public void Die(){
		currentPlanet.GetComponent<PlanetPopulation>().GenerateLootAt(transform.position, 0);
		Destroy(gameObject);
		Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
	}
	
	IEnumerator DamageFlash(){
		Material targetMat = transform.FindChild("Ship").FindChild("MainBody").renderer.material;
		Color origColor = targetMat.color;
		targetMat.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		targetMat.color = origColor;
		yield return new WaitForSeconds(0.05f);
		targetMat.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		targetMat.color = origColor;
		flashing = false;
	}
	
	void AutoFire(){
		GameObject nextLaser = (GameObject)Instantiate(Laser, transform.position, transform.rotation);
		nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
		nextLaser.GetComponent<LaserBehavior>().laserPath = "orbit";
		nextLaser.GetComponent<LaserBehavior>().gravityCenter = currentPlanet.transform.position;
		nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Ally";
		nextLaser.GetComponent<LaserBehavior>().laserSpeed = 45f;
	}
}

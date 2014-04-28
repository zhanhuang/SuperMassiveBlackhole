using UnityEngine;
using System.Collections;

// Inherits from ShipOrbitBehavior
public class AllyShipAI : ShipOrbitBehavior {
	public float speed = 10f;
	public float turnSpeed = 10f;
	
	public int health = 5;
	public int level = 0;
	
	float fireCoolDown = 1f;
	float fireCoolDownRemaining = 0f;
	
	bool flashing = false;

	GameObject Laser;
	GameObject Explosion;
	
	// Loot
	GameObject Loot;
	
	
	// Use this for initialization
	void Start () {
		OrbitSetup();
		
		StartCoroutine(AvoidObstacle());
		
		// load prefabs
		Laser = (GameObject)Resources.Load("Laser_Green");
		Explosion = (GameObject)Resources.Load("Explosion_Player");
		
		// set loot
		if(Random.Range(0f,100f) < 20f){
			Loot = (GameObject)Resources.Load("Health");
		}
	}
	
	// Update is called once per frame
	void Update () {
		fireCoolDownRemaining -= Time.deltaTime;


		int enemyCounter = currentPlanet.transform.GetComponent<PlanetPopulation>().EnemyCounter;
		if(fireCoolDownRemaining < 0f && enemyCounter > 0){
			AutoFire();
			fireCoolDownRemaining = fireCoolDown;
		}
	}
	
	void FixedUpdate () {
		rigidbody.AddForce(transform.forward.normalized * Time.deltaTime * speed * Random.Range(-1f,4f), ForceMode.VelocityChange);
		rigidbody.AddTorque(transform.up.normalized * Time.deltaTime * turnSpeed * Random.Range(-10f,10f), ForceMode.Force);
	}
	
	
	IEnumerator AvoidObstacle(){
		while(true){
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast(transform.position, transform.forward, out hit, 10f)){
				// check if the player is in front
				if (hit.transform.tag != "Ally"){
					rigidbody.AddTorque(transform.up.normalized * Time.deltaTime * turnSpeed * 100f, ForceMode.VelocityChange);
				}
			}
			yield return new WaitForSeconds(1f);
		}
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
		if(Loot != null){
			Instantiate (Loot, transform.position, transform.rotation);
		}
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
		if(level < 4){
			GameObject nextLaser = (GameObject)Instantiate(Laser, transform.position, transform.rotation);
			nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
			nextLaser.GetComponent<LaserBehavior>().laserPath = "orbit";
			nextLaser.GetComponent<LaserBehavior>().gravityCenter = currentPlanet.transform.position;
			nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Ally";
			nextLaser.GetComponent<LaserBehavior>().laserSpeed = 45f;
		} else{
			for(int i = -1; i < 2; i++){
				GameObject nextLaser = (GameObject)Instantiate(Laser, transform.position, transform.rotation);
				nextLaser.transform.Rotate(new Vector3(90f,45f * i,0f));
				nextLaser.GetComponent<LaserBehavior>().laserPath = "orbit";
				nextLaser.GetComponent<LaserBehavior>().gravityCenter = currentPlanet.transform.position;
				nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Ally";
				nextLaser.GetComponent<LaserBehavior>().laserSpeed = 45f;
			}
		}
	}
}

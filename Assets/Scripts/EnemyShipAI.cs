using UnityEngine;
using System.Collections;

// Inherits from ShipOrbitBehavior
public class EnemyShipAI : ShipOrbitBehavior {
	public float speed = 10f;
	public float turnSpeed = 10f;
	
	public int health = 1;
	public int level = 0;

	public AudioClip enemyGunSound;

	float fireCoolDown = 1f;
	float fireCoolDownRemaining = 0f;
	float mineCoolDown = 15f;
	float mineCoolDownRemaining = 0f;
	
	bool flashing = false;

	GameObject player;
	GameObject Laser;
	GameObject Mine;
	GameObject Explosion;

	// AI types
	public string enemyType;	// random, chase
	public bool mineEnabled = false;
	bool chasing = false;
	float chaseTimeLimit = 8f;
	float chaseCountDown = 0f;

	// Use this for initialization
	void Start () {
		OrbitSetup();
		
		StartCoroutine(AvoidObstacle());
		
		// load prefabs
		Laser = (GameObject)Resources.Load("Laser_Red");
		Mine = (GameObject)Resources.Load("Mine_Red");
		Explosion = (GameObject)Resources.Load("Explosion_Player");

		// set player
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		fireCoolDownRemaining -= Time.deltaTime;
		mineCoolDownRemaining -= Time.deltaTime;

		if(enemyType == "random"){
			if(fireCoolDownRemaining < 0f){
				AutoFire();
				fireCoolDownRemaining = fireCoolDown;
			}
		}else if(enemyType == "chase"){
			// chasing fire pattern
			RaycastHit hit = new RaycastHit();
			Vector3 raycastDir = player.transform.position - transform.position;
			if(Physics.Raycast(transform.position + raycastDir.normalized * 2f, raycastDir, out hit, 60f)){
				// check if the player is in front
				if(hit.transform.tag == "Player" && Vector3.Angle(raycastDir, transform.forward) < 80f){
					chasing = true;
					chaseCountDown = -1f;
					if(fireCoolDownRemaining < 0f){
						AutoFire();
						fireCoolDownRemaining = fireCoolDown;
					}
				} else{
					if(chasing){
						if(chaseCountDown <= 0f){
							chaseCountDown = chaseTimeLimit;
						}
						chaseCountDown -= Time.deltaTime;
						if(chaseCountDown <= 0f){
							chasing = false;
						}
					}
				}
			}
		}

		if(mineEnabled && mineCoolDownRemaining < 0f){
			mineCoolDownRemaining = mineCoolDown;
			GameObject nextmine = (GameObject)Instantiate(Mine, transform.position, transform.rotation);
			nextmine.transform.GetComponent<MineMovement>().mineOrigin = "Enemy";
		}
	}

	void FixedUpdate () {
		if(!chasing || (player.transform.position - transform.position).magnitude > 15f){
			if(rigidbody.velocity.z < 10f){
				rigidbody.AddForce(transform.forward.normalized * Time.deltaTime * speed * Random.Range(-1f,4f), ForceMode.VelocityChange);
			}
		}
		if(chasing){
			// chase player
			Vector3 playerDir = player.transform.position - transform.position;
			Vector2 forwardDirection = new Vector3(transform.forward.x,transform.forward.z);
			float angle = 30f;
			Vector3 cross = Vector3.Cross(playerDir,transform.forward);
			if(Vector3.Dot(cross, transform.up) > 0f){
				angle = -angle;
			} else if(Vector3.Dot(cross, transform.up) == 0f){
				angle = 0f;
			}
			rigidbody.AddTorque(transform.up.normalized * Time.deltaTime * turnSpeed * angle, ForceMode.Force);
		} else{
			// random walk
			rigidbody.AddTorque(transform.up.normalized * Time.deltaTime * turnSpeed * Random.Range(-10f,10f), ForceMode.Force);
		}
	}


	IEnumerator AvoidObstacle(){
		while(true){
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast(transform.position, transform.forward, out hit, 15f)){
				// check if the player is in front
				if (hit.transform.tag != "Player"){
					rigidbody.AddForce(-transform.forward.normalized * Time.deltaTime * speed * -10f, ForceMode.VelocityChange);
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
			currentPlanet.GetComponent<PlanetPopulation>().EnemyDied();
			Die();
		} else{
			if(!flashing){
				flashing = true;
				StartCoroutine(DamageFlash());
			}
		}
	}

	public void Die(){
		currentPlanet.GetComponent<PlanetPopulation>().GenerateLootAt(transform.position, level);
		Destroy(gameObject);
		Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
	}
	
	IEnumerator DamageFlash(){
		Material targetMat = transform.FindChild("Ship").renderer.materials[0];
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
			audio.PlayOneShot(enemyGunSound);
			nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
			nextLaser.GetComponent<LaserBehavior>().laserPath = "orbit";
			nextLaser.GetComponent<LaserBehavior>().gravityCenter = currentPlanet.transform.position;
			nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Enemy";
			nextLaser.GetComponent<LaserBehavior>().laserSpeed = 45f;

		} else{
			for(int i = -1; i < 2; i++){
				GameObject nextLaser = (GameObject)Instantiate(Laser, transform.position, transform.rotation);
				audio.PlayOneShot(enemyGunSound);
				nextLaser.transform.Rotate(new Vector3(90f,45f * i,0f));
				nextLaser.GetComponent<LaserBehavior>().laserPath = "orbit";
				nextLaser.GetComponent<LaserBehavior>().gravityCenter = currentPlanet.transform.position;
				nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Enemy";
				nextLaser.GetComponent<LaserBehavior>().laserSpeed = 45f;

			}
		}
	}
}

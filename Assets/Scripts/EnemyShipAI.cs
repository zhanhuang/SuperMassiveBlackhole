using UnityEngine;
using System.Collections;

// Inherits from ShipOrbitBehavior
public class EnemyShipAI : ShipOrbitBehavior {
	public float speed = 10f;
	public float turnSpeed = 10f;
	
	public int health = 1;
	public int enemyLevel = 0;

	float fireCoolDown = 1f;
	float fireCoolDownRemaining = 0f;

	GameObject player;
	GameObject Laser;
	GameObject Explosion;

	// AI types
	public string enemyType;	// random, chase
	bool chasing = false;
	float chaseTimeLimit = 8f;
	float chaseCountDown = 0f;

	// Loot
	GameObject Loot;


	// Use this for initialization
	void Start () {
		OrbitSetup();
		
		StartCoroutine(AvoidObstacle());
		
		// load prefabs
		Laser = (GameObject)Resources.Load("Laser_Red");
		Explosion = (GameObject)Resources.Load("Explosion_Player");

		// set player
		player = GameObject.FindGameObjectWithTag("Player");

		// set loot
		if(Random.Range(0f,100f) < 20f){
			Loot = (GameObject)Resources.Load("Health");
		}
	}
	
	// Update is called once per frame
	void Update () {
		fireCoolDownRemaining -= Time.deltaTime;

		if(enemyType == "random"){
			if(fireCoolDownRemaining < 0f){
				AutoFire();
				fireCoolDownRemaining = fireCoolDown;
			}
			return;
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
					if(chasing && chaseCountDown <= 0f){
						if(chaseCountDown <= 0f){
							chaseCountDown =chaseTimeLimit;
						}
						chaseCountDown -= Time.deltaTime;
						if(chaseCountDown <= 0f){
							chasing = false;
						}
					}
				}
			}
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
			if(Physics.Raycast(transform.position, transform.forward, out hit, 10f)){
				// check if the player is in front
				if (hit.transform.tag != "Player"){
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
			currentPlanet.GetComponent<PlanetPopulation>().EnemyDied();
			Die();
		}
	}

	public void Die(){
		if(Loot != null){
			Instantiate (Loot, transform.position, transform.rotation);
		}
		Destroy(gameObject);
		Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
	}

	void AutoFire(){
		if(enemyLevel < 4){
			GameObject nextLaser = (GameObject)Instantiate(Laser, transform.position, transform.rotation);
			nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
			nextLaser.GetComponent<LaserBehavior>().laserPath = "orbit";
			nextLaser.GetComponent<LaserBehavior>().gravityCenter = currentPlanet.transform.position;
			nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Enemy";
			nextLaser.GetComponent<LaserBehavior>().laserSpeed = 45f;
		} else{
			for(int i = -1; i < 2; i++){
				GameObject nextLaser = (GameObject)Instantiate(Laser, transform.position, transform.rotation);
				nextLaser.transform.Rotate(new Vector3(90f,45f * i,0f));
				nextLaser.GetComponent<LaserBehavior>().laserPath = "orbit";
				nextLaser.GetComponent<LaserBehavior>().gravityCenter = currentPlanet.transform.position;
				nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Enemy";
				nextLaser.GetComponent<LaserBehavior>().laserSpeed = 45f;
			}
		}
	}
}

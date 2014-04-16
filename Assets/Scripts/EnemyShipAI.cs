using UnityEngine;
using System.Collections;

// Inherits from ShipOrbitBehavior
public class EnemyShipAI : ShipOrbitBehavior {
	public string EnemyType = "randomWalk";
	public float speed = 10f;
	public float turnSpeed = 10f;
	float fireCoolDown = 1f;
	float fireCoolDownRemaining = 0f;

	GameObject player;
	GameObject Laser;
	GameObject Explosion;
	
	int health = 1;

	// Use this for initialization
	void Start () {
		OrbitSetup();
		
		StartCoroutine(AvoidObstacle());
		
		// load prefabs
		Laser = (GameObject)Resources.Load("Laser_Red");
		Explosion = (GameObject)Resources.Load("Explosion_Player");

		// set player
		player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
		fireCoolDownRemaining -= Time.deltaTime;

//		RaycastHit hit = new RaycastHit();
//		if(Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, 20f)){
//			// check if the player is in front
//			if(hit.transform.tag == "Player" && Vector3.Angle(player.transform.position - transform.position, transform.forward) < 15f){
//				// player seen, fire laser
				if(fireCoolDownRemaining < 0f){
					GameObject nextLaser = (GameObject)Instantiate(Laser, transform.position, transform.rotation);
					nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
					nextLaser.GetComponent<LaserBehavior>().laserPath = "orbit";
					nextLaser.GetComponent<LaserBehavior>().gravityCenter = currentPlanet.transform.position;
					nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Enemy";
					nextLaser.GetComponent<LaserBehavior>().laserSpeed = 45f;
					fireCoolDownRemaining = fireCoolDown;
				}
//			}
//		}


	}

	void FixedUpdate () {
		if(rigidbody.velocity.z < 10f){
			rigidbody.AddForce(transform.forward.normalized * Time.deltaTime * speed * Random.Range(-1f,4f), ForceMode.VelocityChange);
		}
		rigidbody.AddTorque(transform.up.normalized * Time.deltaTime * turnSpeed * Random.Range(-10f,10f), ForceMode.Force);
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
		health -= damage;
		if(health <= 0){
			Die();
		}
	}

	public void Die(){
		Destroy(gameObject);
		Instantiate (Explosion, transform.position, transform.rotation);
	}
}

using UnityEngine;
using System.Collections;

// Inherits from ShipOrbitBehavior
public class EnemyAI : ShipOrbitBehavior {
	public float speed = 10f;
	public float turnSpeed = 10f;
	float fireCoolDown = 1f;
	float fireCoolDownRemaining = 1f;

	GameObject player;
	GameObject Laser;


	// Use this for initialization
	void Start () {
		OrbitSetup();
		
		// load prefab
		Laser = (GameObject)Resources.Load("Enemy_Laser");

		// set player
		player = GameObject.FindGameObjectWithTag("Player");

		fireCoolDownRemaining = 0f;
		StartCoroutine(AvoidObstacle());
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, 20f)){
			// check if the player is in front
			if(hit.transform.tag == "Player" && Vector3.Angle(player.transform.position - transform.position, transform.forward) < 15f){
				fireCoolDownRemaining -= Time.deltaTime;
				// player seen, fire laser
				if(fireCoolDownRemaining < 0f){
					GameObject nextLaser = (GameObject)Instantiate(Laser, transform.position, transform.rotation);
					nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
					nextLaser.GetComponent<LaserBehavior>().gravityCenter = currentPlanet.transform.position;
					nextLaser.GetComponent<LaserBehavior>().laserType = "Enemy";
					nextLaser.GetComponent<LaserBehavior>().laserSpeed = 0.5f;
					fireCoolDownRemaining = fireCoolDown;
				}
			}
		}
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
			if(Physics.Raycast(transform.position, transform.forward, out hit, 5f)){
				// check if the player is in front
				if (hit.transform.tag != "Player"){
					rigidbody.AddTorque(transform.up.normalized * Time.deltaTime * turnSpeed * 100f, ForceMode.VelocityChange);
				}
			}
			yield return new WaitForSeconds(1f);
		}
	}
}

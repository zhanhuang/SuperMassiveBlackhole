using UnityEngine;
using System.Collections;

// Inherits from ShipOrbitBehavior
public class PlayerShipController : ShipOrbitBehavior {

	public float acceleration = 30f;
	public float maxSpeed = 90f;
	public float turnAcceleration = 4f;
	public float maxTurnSpeed = 8f;

	float cameraRotateAngle = 10f;

	GameObject Laser;
	GameObject Bomb;

	private bool bombactivate = false;

	float currentSpeed = 0f;
	float currentTurningSpeed = 0f;
	
	float damageCoolDown = 1f;
	float damageCoolDownRemaining = 1f;
	
	public float fireCoolDown = 0.5f;
	float fireCoolDownRemaining = 5f;

	// Use this for initialization
	void Start () {
		currentPlanet = GameObject.Find("Planet");
		startingDirection = (transform.position - currentPlanet.transform.position).normalized;
		OrbitSetup();

		// load prefab
		Laser = (GameObject)Resources.Load("Player_Laser");
		Bomb = (GameObject)Resources.Load ("Player_Bomb");


		// set variables to initial value
		damageCoolDownRemaining = 0f;
		fireCoolDownRemaining = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		// reset
		if (Input.GetKey(KeyCode.R)){
			Application.LoadLevel(0);
		}
		//if (bombactivate = false) {
				if (Input.GetKeyDown (KeyCode.Tab)) {
						bombactivate = true;
						GameObject nextbomb = (GameObject)Instantiate (Bomb, transform.position, transform.rotation);
			nextbomb.transform.Rotate (new Vector3(0f, 0f, 0f));
			nextbomb.GetComponent<bombscript>().gravityCenter = currentPlanet.transform.position;

						}
				//}
		//if (bombactivate = true) {
				//}
		// shooting
		fireCoolDownRemaining -= Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.Space)){
			if(fireCoolDownRemaining < 0f){
				GameObject nextLaser = (GameObject)Instantiate(Laser, transform.position, transform.rotation);
				nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
				nextLaser.GetComponent<LaserBehavior>().gravityCenter = currentPlanet.transform.position;
				nextLaser.GetComponent<LaserBehavior>().laserType = "Player";
				nextLaser.GetComponent<LaserBehavior>().laserSpeed = 1f;
				fireCoolDownRemaining = fireCoolDown;
			}
		}

		// TODO: rotate camera according to speed and turning speed
		transform.GetChild(0).transform.localRotation = Quaternion.Euler(new Vector3(35f + cameraRotateAngle * rigidbody.velocity.z/maxSpeed, 0f, 0f));
	}

	void FixedUpdate () {
		// moving and turning
		if (Input.GetKey(KeyCode.W)){
			if(rigidbody.velocity.z < maxSpeed){
				rigidbody.AddForce(transform.forward.normalized * Time.deltaTime * acceleration, ForceMode.VelocityChange);
			}
		}
		if (Input.GetKey(KeyCode.S)){
			if(rigidbody.velocity.z > -maxSpeed){
				rigidbody.AddForce(-transform.forward.normalized * Time.deltaTime * acceleration, ForceMode.VelocityChange);
			}
		}
		if (Input.GetKey(KeyCode.D)){
			if(rigidbody.angularVelocity.y < maxTurnSpeed){
				rigidbody.AddTorque(transform.up.normalized * Time.deltaTime * turnAcceleration, ForceMode.VelocityChange);
			}
		}
		if (Input.GetKey(KeyCode.A)){
			if(rigidbody.angularVelocity.y > -maxTurnSpeed){
				rigidbody.AddTorque(-transform.up.normalized * Time.deltaTime * turnAcceleration, ForceMode.VelocityChange);
			}
		}
		
		//TODO: tilt on turning
//		transform.rotation =  (rigidbody.angularVelocity.y / maxTurnSpeed * tilt);
	}
}

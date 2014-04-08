using UnityEngine;
using System.Collections;

// Inherits from ShipOrbitBehavior
public class PlayerShipController : ShipOrbitBehavior {

	float acceleration = 30f;
	float maxSpeed = 90f;
	float turnAcceleration = 4f;
	float maxTurnSpeed = 8f;
	float laserSpeed = 20f;

	GameObject Laser;

	float currentSpeed = 0f;
	float currentTurningSpeed = 0f;

	// Use this for initialization
	void Start () {
		currentPlanet = GameObject.Find("Planet");
		startingDirection = (transform.position - currentPlanet.transform.position).normalized;
		OrbitSetup();

		// load prefab
		Laser = (GameObject)Resources.Load("Player_Laser");
	}
	
	// Update is called once per frame
	void Update () {
		// reset
		if (Input.GetKey(KeyCode.R)){
			Application.LoadLevel(0);
		}

		// shooting
		if (Input.GetKeyDown(KeyCode.Space)){
			GameObject nextLaser = (GameObject)Instantiate(Laser, transform.position, transform.rotation);
			nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
			nextLaser.GetComponent<LaserBehavior>().gravityCenter = currentPlanet.transform.position;
			nextLaser.GetComponent<LaserBehavior>().laserType = "Player";
		}
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
	}
}

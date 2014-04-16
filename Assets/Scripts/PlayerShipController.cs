using UnityEngine;
using System.Collections;

// Inherits from ShipOrbitBehavior
public class PlayerShipController : ShipOrbitBehavior {

	float acceleration = 50f;
	float turnAcceleration = 20f;

	GameObject playerCamera;
	GameObject Explosion;


	Vector3 cameraStartingLocalPosition;

	GameObject Laser;
	GameObject Bomb;

	float currentSpeed = 0f;
	float currentTurningSpeed = 0f;
	
	float damageCoolDown = 1f;
	float damageCoolDownRemaining = 0f;
	
	public float fireCoolDown = 0.5f;
	float fireCoolDownRemaining = 0f;

	int health = 3;
	GUIText healthText;

	// Use this for initialization
	void Start () {
		currentPlanet = GameObject.Find("Planet");
		startingDirection = (transform.position - currentPlanet.transform.position).normalized;
		OrbitSetup();

		// load prefab
		Bomb = (GameObject)Resources.Load("Bomb");
		Laser = (GameObject)Resources.Load("Laser_Blue");
		Explosion = (GameObject)Resources.Load("Explosion_Player");

		// set camera
		playerCamera = transform.GetChild(0).gameObject;
		cameraStartingLocalPosition = playerCamera.transform.localPosition;
		
		// ammo counter 
		GameObject healthTextObj = new GameObject("ammoCounter");
		healthTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		healthText = (GUIText)healthTextObj.AddComponent(typeof(GUIText));
		healthText.pixelOffset = new Vector2(-Screen.width/2 + 40, Screen.height/2 - 40);
		healthText.fontSize = 18;
		healthText.color = Color.white;
		healthText.text = "HEALTH: " + health;
	}
	
	// Update is called once per frame
	void Update () {
		
		// reset
		if (Input.GetKey(KeyCode.R)){
			Application.LoadLevel(0);
		}

		if(transform.renderer.enabled == false){
			return;
		}

		damageCoolDownRemaining -= Time.deltaTime;
		fireCoolDownRemaining -= Time.deltaTime;

		// shooting
		if (Input.GetKeyDown(KeyCode.J)){
			if(fireCoolDownRemaining < 0f){
				GameObject nextLaser = (GameObject)Instantiate(Laser, transform.position, transform.rotation);
				nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
				nextLaser.GetComponent<LaserBehavior>().laserPath = "orbit";
				nextLaser.GetComponent<LaserBehavior>().gravityCenter = currentPlanet.transform.position;
				nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Player";
				nextLaser.GetComponent<LaserBehavior>().laserSpeed = 60f;
//				fireCoolDownRemaining = fireCoolDown;
			}
		}

		float forwardVelocity = transform.InverseTransformDirection(rigidbody.velocity).z;

		// bombing
		if (Input.GetKeyDown (KeyCode.K)) {
			GameObject nextbomb = (GameObject)Instantiate (Bomb, transform.position, transform.rotation);
			nextbomb.transform.Rotate (new Vector3(180f, 0f, 0f));
			nextbomb.GetComponent<BombMovement>().gravityCenter = currentPlanet.transform.position;
			nextbomb.GetComponent<BombMovement>().bombForwardSpeed += forwardVelocity;
		}

//		// zoom camera according to speed. TODO: decide if we want this in or not	
//		Vector3 adjustedCameraRotation = new Vector3(cameraStartingLocalPosition.x, cameraStartingLocalPosition.y - forwardVelocity, cameraStartingLocalPosition.z + forwardVelocity);
//		transform.GetChild(0).transform.localPosition = adjustedCameraRotation;
	}

	void FixedUpdate () {
		if(transform.renderer.enabled == false){
			return;
		}


		// moving
		if (Input.GetKey(KeyCode.W)){
				rigidbody.AddForce(transform.forward.normalized * Time.deltaTime * acceleration, ForceMode.VelocityChange);
		}
		if (Input.GetKey(KeyCode.S)){
				rigidbody.AddForce(-transform.forward.normalized * Time.deltaTime * acceleration, ForceMode.VelocityChange);
		}

		// turning
		if (Input.GetKey(KeyCode.D)){
				rigidbody.AddTorque(transform.up.normalized * Time.deltaTime * turnAcceleration, ForceMode.VelocityChange);
		}
		if (Input.GetKey(KeyCode.A)){
				rigidbody.AddTorque(-transform.up.normalized * Time.deltaTime * turnAcceleration, ForceMode.VelocityChange);
		}
		
		//TODO: tilt on turning

	}

	public void TakeDamage(int damage){
		if(transform.renderer.enabled == false){
			return;
		}
		if(damageCoolDownRemaining < 0f){
			health -= damage;
			damageCoolDownRemaining = damageCoolDown;
			healthText.text = "HEALTH: " + health;
		}
		if(health <= 0){
			Die();
		}
	}

	public void Die(){
		transform.renderer.enabled = false;
		transform.collider.enabled = false;
		Instantiate (Explosion, transform.position, transform.rotation);
	}
}

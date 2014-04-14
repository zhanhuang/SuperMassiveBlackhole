using UnityEngine;
using System.Collections;

// Inherits from ShipOrbitBehavior
public class PlayerShipController : ShipOrbitBehavior {

	public float acceleration = 30f;
	public float maxSpeed = 90f;
	public float turnAcceleration = 4f;
	public float maxTurnSpeed = 8f;

	GameObject playerCamera;
	GameObject Explosion;
	Quaternion cameraStartingRotation;
	float cameraRotateAngle = 45f;
	float cameraStartingRotationX;

	GameObject Laser;
	GameObject Bomb;

	private bool bombactivate = false;

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
		Bomb = (GameObject)Resources.Load ("Player_Bomb");
		Laser = (GameObject)Resources.Load("Laser_Blue");
		Explosion = (GameObject)Resources.Load ("Explosion05");

		// set camera
		playerCamera = transform.GetChild(0).gameObject;
		cameraStartingRotationX = playerCamera.transform.localRotation.eulerAngles.x;

		
		// ammo counter 
		GameObject ammoTextObj = new GameObject("ammoCounter");
		ammoTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		healthText = (GUIText)ammoTextObj.AddComponent(typeof(GUIText));
		healthText.pixelOffset = new Vector2(-Screen.width/2 + 40, -Screen.height/2 + 40);
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
		if (Input.GetKeyDown(KeyCode.Space)){
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

		// rotate camera according to speed and TODO: turning speed
		transform.GetChild(0).transform.localRotation = Quaternion.Euler(new Vector3(cameraStartingRotationX - cameraRotateAngle * rigidbody.velocity.z/maxSpeed, 0f, 0f));
	}

	void FixedUpdate () {
		if(transform.renderer.enabled == false){
			return;
		}


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
		Instantiate (Explosion, transform.position, transform.rotation);
	}
}

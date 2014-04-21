﻿using UnityEngine;
using System.Collections;

// Inherits from ShipOrbitBehavior
public class PlayerShipController : ShipOrbitBehavior {
	public GalaxyPopulation Galaxy;

	// ship stat variables
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
	
	float overHeatLimit = 10f;
	float overHeatMeter = 0f;
	float coolOffCounter = 0f;

	int health = 10;
	GUIText healthText;
	GUIText heatText;
	GUIText weaponText;
	GUIText enemyText;


	// Use this for initialization
	void Start () {
//		currentPlanet = GameObject.Find("Planet");
		OrbitSetup();

		// set camera culling to spherical
		transform.GetComponentInChildren<Camera>().layerCullSpherical = true;

		// load prefab
		Bomb = (GameObject)Resources.Load("Bomb");
		Laser = (GameObject)Resources.Load("Laser_Blue");
		Explosion = (GameObject)Resources.Load("Explosion_Player");

		// set camera
		playerCamera = transform.GetChild(0).gameObject;
		cameraStartingLocalPosition = playerCamera.transform.localPosition;
		
		// health counter 
		// TODO: Have a bar for this
		GameObject healthTextObj = new GameObject("HUD_healthCounter");
		healthTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		healthText = (GUIText)healthTextObj.AddComponent(typeof(GUIText));
		healthText.pixelOffset = new Vector2(-Screen.width/2 + 40f, Screen.height/2 - 30f);
		healthText.fontSize = 18;
		healthText.color = Color.green;
		healthText.text = "HEALTH: " + health;
		
		// overheat meter
		// TODO: Have a bar for this
		GameObject heatTextObj = new GameObject("HUD_heatMeter");
		heatTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		heatText = (GUIText)heatTextObj.AddComponent(typeof(GUIText));
		heatText.anchor = TextAnchor.UpperRight;
		heatText.pixelOffset = new Vector2(Screen.width/2 - 40f, Screen.height/2 - 30f);
		heatText.fontSize = 18;
		heatText.color = Color.white;
		heatText.text = "WEAPON SYS HEAT: " + overHeatMeter.ToString("F2") + "/" + overHeatLimit.ToString("F2");
		
		// weapon text
		GameObject weaponTextObj = new GameObject("HUD_weaponText");
		weaponTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		weaponText = (GUIText)weaponTextObj.AddComponent(typeof(GUIText));
		weaponText.anchor = TextAnchor.LowerRight;
		weaponText.pixelOffset = new Vector2(Screen.width/2 - 40f, -Screen.height/2 + 30f);
		weaponText.fontSize = 18;
		weaponText.color = Color.yellow;
		weaponText.text = "[J]: Laser \n[K]: Bomb";
		
		// enemy counter for current planet
		GameObject enemyTextObj = new GameObject("HUD_enemyCounter");
		enemyTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		enemyText = (GUIText)enemyTextObj.AddComponent(typeof(GUIText));
		enemyText.anchor = TextAnchor.MiddleCenter;
		enemyText.pixelOffset = new Vector2(0f, -Screen.height/2 + 30f);
		enemyText.fontSize = 18;
		enemyText.color = Color.red;
		enemyText.text = "Enemies Left: 0";
	}
	
	// Update is called once per frame
	void Update () {
		
		// reset
		if (health == 0 && Input.GetKey(KeyCode.R)){
			Application.LoadLevel(0);
		}

		if(transform.renderer.enabled == false){
			return;
		}

		damageCoolDownRemaining -= Time.deltaTime;


		coolOffCounter += Time.deltaTime;
		if(overHeatMeter > 0){
			overHeatMeter -= Time.deltaTime * Mathf.Clamp(coolOffCounter, 1f, Mathf.Infinity);
			overHeatMeter = Mathf.Clamp(overHeatMeter, 0f, overHeatLimit*2);
		}
		
		float forwardVelocity = transform.InverseTransformDirection(rigidbody.velocity).z; // shared between bomb and camera zoom

		if(overHeatMeter < overHeatLimit){
			// color to cyan when cooldown is high to signify faster heat reduction
			if(coolOffCounter > 2f && overHeatMeter > 0f){
				heatText.color = Color.cyan;
			} else{
				heatText.color = Color.white;
			}
			// shooting
			if (Input.GetKeyDown(KeyCode.J)){
				GameObject nextLaser = (GameObject)Instantiate(Laser, transform.position, transform.rotation);
				nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
				nextLaser.GetComponent<LaserBehavior>().laserPath = "orbit";
				nextLaser.GetComponent<LaserBehavior>().gravityCenter = currentPlanet.transform.position;
				nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Player";
				nextLaser.GetComponent<LaserBehavior>().laserSpeed = 60f;

				overHeatMeter += 1f;
				coolOffCounter = 0f;
			}
			
			// bombing
			if (Input.GetKeyDown (KeyCode.K)) {
				GameObject nextbomb = (GameObject)Instantiate (Bomb, transform.position, transform.rotation);
				nextbomb.transform.Rotate (new Vector3(180f, 0f, 0f));
				nextbomb.GetComponent<BombMovement>().gravityCenter = currentPlanet.transform.position;
				nextbomb.GetComponent<BombMovement>().bombForwardSpeed += forwardVelocity;

				overHeatMeter += 1f;
				coolOffCounter = 0f;
			}
		} else{
			//TODO: show overheat meter
			heatText.color = Color.red;
		}
		
		// tail particle effect
		if(forwardVelocity > 0f){
			transform.FindChild("PlayerTailFlameLeft").GetComponent<ParticleSystem>().startSpeed = 0.3f * forwardVelocity;
			transform.FindChild("PlayerTailFlameRight").GetComponent<ParticleSystem>().startSpeed = 0.3f * forwardVelocity;
		}

//		// zoom camera according to speed. TODO: decide if we want this in or not	
//		Vector3 adjustedCameraRotation = new Vector3(cameraStartingLocalPosition.x, cameraStartingLocalPosition.y - forwardVelocity, cameraStartingLocalPosition.z + forwardVelocity);
//		transform.GetChild(0).transform.localPosition = adjustedCameraRotation;

		// update heat text
		heatText.text = "WEAPON HEAT: " + overHeatMeter.ToString("F1") + "/" + overHeatLimit.ToString("F1");
		enemyText.text = "Enemies Left: " + currentPlanet.transform.GetComponent<PlanetPopulation>().EnemyCounter;
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
			healthText.color = Color.red;
			Die();
		}
	}

	public void Die(){
		transform.renderer.enabled = false;
		transform.collider.enabled = false;
		transform.FindChild("PlayerTailFlameLeft").GetComponent<ParticleSystem>().enableEmission = false;
		transform.FindChild("PlayerTailFlameRight").GetComponent<ParticleSystem>().enableEmission = false;
		Instantiate (Explosion, transform.position, transform.rotation);
		
		GameObject loseTextObj = new GameObject("HUD_loseText");
		loseTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		GUIText loseText = (GUIText)loseTextObj.AddComponent(typeof(GUIText));
		loseText.pixelOffset = new Vector2(0f, 100f);
		loseText.anchor = TextAnchor.LowerCenter;
		loseText.text = "YOU DIED...";
		loseText.color = Color.red;
		loseText.fontSize = 48;
		loseText.enabled = true;
		
		GameObject restartTextObj = new GameObject("HUD_restartText");
		restartTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		GUIText restartText = (GUIText)restartTextObj.AddComponent(typeof(GUIText));
		restartText.pixelOffset = new Vector2(0f, 80f);
		restartText.anchor = TextAnchor.MiddleCenter;
		restartText.text = "(Press [R] To Restart)";
		restartText.color = Color.white;
		restartText.fontSize = 14;
		restartText.enabled = true;
	}
}

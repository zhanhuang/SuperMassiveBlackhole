using UnityEngine;
using System.Collections;

// Inherits from ShipOrbitBehavior
public class PlayerShipController : ShipOrbitBehavior {
	public GalaxyPopulation Galaxy;
	
	int health = 5;
	// shop and weapons
	public int currency = 30;


	// WEAPONS
	// laser
	int laserLevel = 1;
	// bomb
	int bombLevel = 1;
	// shield
	int shieldCharges = 2;
	float shieldLimit = 3f;
	public float shieldTimeRemaining = 0f;
	// death ray
	int deathRayLevel = 0;
	bool deathRayActivated = false;
	// mine
	int mineCharges = 5;
	// EMP
	int EMPLevel = 0;
	bool EMPActivated = false;
	Transform EMPTransform;
	Vector3 EMPStartingScale;
	

	// overheat
	public float overHeatLimit = 10f;
	float overHeatMeter = 0f;
	float coolOffCounter = 0f;
	Material heatMat;
	Material heatWordMat;

	public float healthBarLimit = 5f;
	Material healthMat;
	Material healthWordMat;

	// ship stat variables
	float acceleration = 50f;
	float turnAcceleration = 20f;

	public Transform shipTransform;
	Transform cameraTransform;
	GameObject Explosion;

	Vector3 cameraStartingLocalPosition;

	GameObject Laser;
	GameObject Bomb;
	GameObject Mine;

	GameObject MoveJoint;

	GameObject HealthMoveJoint;

	bool dmgFlashing = false;
	bool heatFlashing = false;

	Font GUIFont;

//	GUIText healthText;
//	GUIText heatText;
	
	GUIOutlinedText currencyText;
	GUIOutlinedText shieldText;
	GUIOutlinedText mineText;
	GUIOutlinedText movementText;
	GUIOutlinedText weaponText;
	GUIOutlinedText enemyText;
	GUIOutlinedText allyText;
	GUIOutlinedText gameText;

	public AudioClip gunSound;
	public AudioClip bombSound;
	public AudioClip healthSound;
	public AudioClip gameOverSound;
	public AudioClip deathRaySound;
	public AudioClip empSound;
	public AudioClip transmissionSound;

	public AudioSource audio2;
	public AudioSource audio3;

	int soundCount = 0;


	// compass
	GameObject compass;
	public Transform lastEnemy;
	public bool isFinalStage = false;

	// text to direct player toward red beam
	bool objectiveDisplayed = false;

	// konami code
	int konamiIndex = 0;
	KeyCode[] konamiCode = new KeyCode[11];

	// Use this for initialization
	void Start () {

		OrbitSetup();

		// setup joint for heat bar
		MoveJoint = transform.FindChild("Heat Bar").FindChild("BaseJoint").FindChild("MoveJoint").gameObject;

		// setup joint for health bar
		HealthMoveJoint = transform.FindChild("Health Bar").FindChild("BaseJoint").FindChild("MoveJoint").gameObject;

		// set camera culling to spherical
		transform.GetComponentInChildren<Camera>().layerCullSpherical = true;

		// load prefab
		Bomb = (GameObject)Resources.Load("Bomb");
		Laser = (GameObject)Resources.Load("Laser_Blue");
		Mine = (GameObject)Resources.Load("Mine_Yellow");
		Explosion = (GameObject)Resources.Load("Explosion_Player");

		// load font
		GUIFont = (Font)Resources.Load("AirStrike");

		// set camera
		shipTransform = transform.FindChild("Ship");
		cameraTransform = transform.FindChild("Camera");
		cameraStartingLocalPosition = cameraTransform.localPosition;

		// set emp
		EMPTransform = transform.FindChild("EMP");
		EMPStartingScale = EMPTransform.localScale;

		// set compass
		compass = transform.FindChild("Arrow").gameObject;
		compass.SetActive(false);
		
		// health counter 
		// TODO: Have a bar for this
//		GameObject healthTextObj = new GameObject("HUD_healthCounter");
//		healthTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
//		healthText = (GUIText)healthTextObj.AddComponent(typeof(GUIText));
//		healthText.pixelOffset = new Vector2(-Screen.width/2 + 40f, Screen.height/2 - 30f);
//		healthText.fontSize = 18;
//		healthText.font = GUIFont;
//		healthText.color = Color.green;
//		healthText.text = "HEALTH: " + health;
		
		// overheat meter
		// TODO: Have a bar for this
//		GameObject heatTextObj = new GameObject("HUD_heatMeter");
//		heatTextObj.transform.position = new Vector3(0.5f, 0.5f, 0f);
//		heatText = (GUIText)heatTextObj.AddComponent(typeof(GUIText));
//		heatText.anchor = TextAnchor.MiddleRight;
//		heatText.pixelOffset = new Vector2(Screen.width/2 - 125f, Screen.height/2 - 34f);
//		heatText.fontSize = 18;
//		heatText.font = GUIFont;
//		heatText.color = Color.white;
//		heatText.text = "WEAPON SYS HEAT: " + overHeatMeter.ToString("F2") + "/" + overHeatLimit.ToString("F2");

		healthMat = transform.FindChild("Health Bar").FindChild("Bar").renderer.material;
		healthWordMat = transform.FindChild("Health Bar").Find("HealthWord").renderer.materials[1];
		healthWordMat.color = new Color(1f, 1f, 0f);
		
		heatMat = transform.FindChild("Heat Bar").FindChild("Bar").renderer.material;
		heatWordMat = transform.FindChild("Heat Bar").FindChild("HeatText").renderer.materials[1];
		heatWordMat.color = new Color(1f, 0.25f, 0f);

		// currency counter
		currencyText = new GUIOutlinedText("HUD_currencyCounter");
		currencyText.pixelOffset = new Vector2(-Screen.width/2 + 40f, Screen.height/2 - 60f);
		currencyText.fontSize = 18;
		currencyText.font = GUIFont;
		currencyText.color = Color.yellow;
		currencyText.outlineColor = Color.black;
		currencyText.text = "CURRENCY: " + currency;


		// shield counter
		shieldText = new GUIOutlinedText("HUD_shieldCounter");
		shieldText.anchor = TextAnchor.UpperRight;
		shieldText.pixelOffset = new Vector2(Screen.width/2 - 40f, Screen.height/2 - 60f);
		shieldText.fontSize = 18;
		shieldText.font = GUIFont;
		shieldText.text = "";

		// mine counter
		mineText = new GUIOutlinedText("HUD_mineCounter");
		mineText.anchor = TextAnchor.UpperRight;
		mineText.pixelOffset = new Vector2(Screen.width/2 - 40f, Screen.height/2 - 90f);
		mineText.fontSize = 18;
		mineText.font = GUIFont;
		mineText.text = "";
		
		// movement text
		movementText = new GUIOutlinedText("HUD_moveText");
		movementText.anchor = TextAnchor.LowerLeft;
		movementText.pixelOffset = new Vector2(-Screen.width/2 + 40f, -Screen.height/2 + 30f);
		movementText.fontSize = 18;
		movementText.font = GUIFont;
		movementText.color = Color.grey;
		movementText.text = "Move: \n[Q][W][E]\n[A][S][D]";
		
		// weapon text
		weaponText = new GUIOutlinedText("HUD_weaponText");
		weaponText.anchor = TextAnchor.LowerRight;
		weaponText.pixelOffset = new Vector2(Screen.width/2 - 40f, -Screen.height/2 + 30f);
		weaponText.fontSize = 18;
		weaponText.font = GUIFont;
		weaponText.color = Color.magenta;
		
		// enemy counter for current planet
		enemyText = new GUIOutlinedText("HUD_enemyCounter");
		enemyText.anchor = TextAnchor.MiddleCenter;
		enemyText.pixelOffset = new Vector2(0f, Screen.height/2 - 30f);
		enemyText.fontSize = 18;
		enemyText.font = GUIFont;
		enemyText.color = Color.red;

		
		// ally counter for current planet
		allyText = new GUIOutlinedText("HUD_allyCounter");
		allyText.anchor = TextAnchor.MiddleCenter;
		allyText.pixelOffset = new Vector2(0f, Screen.height/2 - 70f);
		allyText.fontSize = 18;
		allyText.font = GUIFont;
		allyText.color = Color.green;
		allyText.enabled = false;
		
		// game text
//		GameObject gameTextObj = new GameObject("HUD_gameText");
//		gameTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		gameText = new GUIOutlinedText("HUD_gameText");
		gameText.anchor = TextAnchor.UpperCenter;
		gameText.alignment = TextAlignment.Center;
		gameText.pixelOffset = new Vector2(0, Screen.height/2 - 100f);
		gameText.fontSize = 24;
		gameText.font = GUIFont;
		gameText.color = new Color(0f,0.67f,1f);
		
		UpdateWeaponText();

		DisplayTextInstant("INCOMING TRANSMISSION:\n\n", 5f);
		DisplayAdditionalText("\"...You're our last ship with an\noperational planar drive now.\n\n......It's time to make them pay!!!\"", 3f);


		konamiCode[0] = KeyCode.UpArrow;
		konamiCode[1] = KeyCode.UpArrow;
		konamiCode[2] = KeyCode.DownArrow;
		konamiCode[3] = KeyCode.DownArrow;
		konamiCode[4] = KeyCode.LeftArrow;
		konamiCode[5] = KeyCode.RightArrow;
		konamiCode[6] = KeyCode.LeftArrow;
		konamiCode[7] = KeyCode.RightArrow;
		konamiCode[8] = KeyCode.B;
		konamiCode[9] = KeyCode.A;
	}
	
	// Update is called once per frame
	void Update () {

		// reset
		if (health == 0 && Input.GetKey(KeyCode.R)){
			Application.LoadLevel(0);
		}

		if(transform.collider.enabled == false){
			return;
		}


		coolOffCounter += Time.deltaTime;
		if(overHeatMeter > 0){
			if (coolOffCounter > 2f){
				overHeatMeter -= Time.deltaTime * 7;
			}
			else{
				overHeatMeter -= Time.deltaTime* 1.5f;
			}
			overHeatMeter = Mathf.Clamp(overHeatMeter, 0f, overHeatLimit*2);
			
		}

		if(shieldTimeRemaining > 0f){
			shieldText.anchor = TextAnchor.UpperLeft;
			shieldText.pixelOffset = new Vector2(Screen.width/2 - 320f, Screen.height/2 - 60f);
			shieldTimeRemaining -= Time.deltaTime;
			shieldText.text = "SHIELD ENGAGED. TIME LEFT: " + shieldTimeRemaining.ToString("F1");
			if(shieldTimeRemaining <= 0f){
				DisableShield();
			}
		}

		//sound plays on initial player movement
		if (soundCount == 0) {
			if (Input.GetKeyDown (KeyCode.W)) {
				audio.Play();
				soundCount += 1;
				}
			}


		if(overHeatMeter < overHeatLimit){
			// color to cyan when cooldown is high to signify faster heat reduction
			if(coolOffCounter > 2f && overHeatMeter > 0f){
//				heatText.color = Color.cyan;
				heatMat.color = Color.cyan;
			} else{
//				heatText.color = Color.white;
				// Yellow Color
				heatMat.color = new Color(.75f, .75f, 0f);
			}

			// shooting
			if (Input.GetKeyDown(KeyCode.J)){
				FireLaser();
				overHeatMeter += .7f + .3f * laserLevel;
				coolOffCounter = 0f;
			}
			
			// bombing
			if (Input.GetKeyDown (KeyCode.K)) {

				DropBomb();

				overHeatMeter += 2f * bombLevel;
				coolOffCounter = 0f;
			}
			
			// death ray
			if (Input.GetKeyDown (KeyCode.U)) {
				if(deathRayLevel > 0 && !deathRayActivated){
					audio.PlayOneShot (deathRaySound);
					deathRayActivated = true;
					StartCoroutine("ActivateDeathRay");
					overHeatMeter += 8f;
					coolOffCounter = 0f;
				}
			}

			// setting mine
			if (Input.GetKeyDown (KeyCode.I)) {
				if(mineCharges > 0){
					mineCharges --;
					UpdateWeaponText();
					GameObject nextmine = (GameObject)Instantiate(Mine, transform.position, transform.rotation);
					nextmine.transform.GetComponent<MineMovement>().mineOrigin = "Player";
				}
			}

			// EMP
			if (Input.GetKeyDown (KeyCode.O)) {
				if(shieldCharges > 0 && EMPLevel > 0 && !EMPActivated && shieldTimeRemaining <= 0f){
					audio.PlayOneShot (empSound);
					EMPActivated = true;
					shieldCharges --;
					UpdateWeaponText();
					StartCoroutine("ActivateEMP");
				}
			}
			if (overHeatMeter > overHeatLimit){
				overHeatMeter = overHeatLimit + 2;
				coolOffCounter = -.5f;
				StopCoroutine("OverheatFlash");
				StartCoroutine("OverheatFlash");
			}
		} 
		else{
			//TODO: show overheat meter
//			heatText.color = Color.red;
			heatMat.color = new Color(1f, .118f, .118f);
		}
		
		// shielding
		if (Input.GetKeyDown (KeyCode.L)) {
			if(shieldCharges > 0 && shieldTimeRemaining <= 0f && !EMPActivated){
				shieldCharges --;
				ActivateShield(shieldLimit);
			}
		}
			
		// tail particle effect
		float forwardVelocity = transform.InverseTransformDirection(rigidbody.velocity).z;
		if(forwardVelocity > 0f){
			shipTransform.FindChild("_TailFlameLeft").GetComponent<ParticleSystem>().startSpeed = 0.2f * forwardVelocity;
			shipTransform.FindChild("_TailFlameRight").GetComponent<ParticleSystem>().startSpeed = 0.2f * forwardVelocity;
		}
		


//		// zoom camera according to speed. TODO: decide if we want this in or not
//		Vector3 adjustedCameraRotation = new Vector3(cameraStartingLocalPosition.x, cameraStartingLocalPosition.y - forwardVelocity, cameraStartingLocalPosition.z + forwardVelocity);
//		transform.FindChild("Camera").transform.localPosition = adjustedCameraRotation;

		// update heat text
//		heatText.text = "HEAT";
		// update heat bar
		if (overHeatMeter > 10){
			MoveJoint.transform.localPosition = new Vector3(-10, MoveJoint.transform.localPosition.y, MoveJoint.transform.localPosition.z);
		}
		else{
			MoveJoint.transform.localPosition = new Vector3(-overHeatMeter, MoveJoint.transform.localPosition.y, MoveJoint.transform.localPosition.z);
		}

		// look at enemy if active
		if(compass.activeSelf){
			if(lastEnemy != null){
				compass.transform.rotation = Quaternion.LookRotation(lastEnemy.position - transform.position, transform.up);
			}else{
				lastEnemy = GameObject.FindGameObjectWithTag("Enemy").transform;
				if(lastEnemy == null){
					compass.SetActive(false);
				} else{
					compass.transform.rotation = Quaternion.LookRotation(lastEnemy.position - transform.position, transform.up);
				}
			}
		}

		// konami cheat
		if(konamiIndex < 10){
			KonamiCheck();
		}
	}

	void FixedUpdate () {
		if(transform.collider.enabled == false){
			return;
		}


		// moving
		if (Input.GetKey(KeyCode.W)){
				rigidbody.AddForce(transform.forward.normalized * Time.deltaTime * acceleration, ForceMode.VelocityChange);
		}
		if (Input.GetKey(KeyCode.S)){
				rigidbody.AddForce(-transform.forward.normalized * Time.deltaTime * acceleration, ForceMode.VelocityChange);
		}

		// strafe
		if (Input.GetKey(KeyCode.E)){
			rigidbody.AddForce(transform.right.normalized * Time.deltaTime * acceleration, ForceMode.VelocityChange);
		}
		if (Input.GetKey(KeyCode.Q)){
			rigidbody.AddForce(-transform.right.normalized * Time.deltaTime * acceleration, ForceMode.VelocityChange);
		}

		// turning
		if (Input.GetKey(KeyCode.D)){
				rigidbody.AddTorque(transform.up.normalized * Time.deltaTime * turnAcceleration, ForceMode.VelocityChange);
		}
		if (Input.GetKey(KeyCode.A)){
				rigidbody.AddTorque(-transform.up.normalized * Time.deltaTime * turnAcceleration, ForceMode.VelocityChange);
		}

		
		// tilt on turning
		// checks for both directions pressed at once. Less elegant code, but more consistent behavior
		if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)){
			Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 30f));
			shipTransform.localRotation = Quaternion.Lerp(shipTransform.localRotation, targetRotation, 5f * Time.deltaTime);
		} else if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)){
			Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, -30f));
			shipTransform.localRotation = Quaternion.Lerp(shipTransform.localRotation, targetRotation, 5f * Time.deltaTime);
		} else if(Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E)){
			Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 30f));
			shipTransform.localRotation = Quaternion.Lerp(shipTransform.localRotation, targetRotation, 5f * Time.deltaTime);
		} else if(Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.Q)){
			Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, -30f));
			shipTransform.localRotation = Quaternion.Lerp(shipTransform.localRotation, targetRotation, 5f * Time.deltaTime);
		} else{
			shipTransform.localRotation = Quaternion.Lerp(shipTransform.localRotation, Quaternion.identity, 5f * Time.deltaTime);
		}
	}

	public void TakeDamage(int damage){
		if(health <= 0){
			return;
		}

		health -= damage;
		if(health < 0){
			health = 0;
		}
		StartCoroutine(CameraShake());
//		healthText.text = "HEALTH: " + health;

		if(health <= 0){
//			healthText.color = Color.red;
			Die();
		} else{
//			if(health <= 2){
////				healthText.color = new Color(1f, 0.5f, 0f);
//				healthMat.color = new Color(1f, 0.5f, 0f);
//			} else if(health <= 1){
//				healthMat.color = new Color(1f, 0f, 0f);
//			}
			if(!dmgFlashing){
				dmgFlashing = true;
				StartCoroutine("DamageFlash");
			}
		}
		UpdateHealth();
	}

	public void UpdateHealth(){
		if (health <= 0){
			Destroy(transform.FindChild("Health Bar").FindChild("Bar").gameObject);
		}
		else{
			if(health > 2){
				//				healthText.color = Color.green;
				healthMat.color = Color.green;
			} else if (health  > 1){
				healthMat.color = new Color(1f, 0.5f, 0f);
			} else{
				healthMat.color = new Color(1f, 0f, 0f);
			}
			HealthMoveJoint.transform.localPosition = new Vector3(Mathf.Clamp(health*-2,-10f,0f), MoveJoint.transform.localPosition.y, MoveJoint.transform.localPosition.z);
		}
	}


	IEnumerator OverheatFlash(){
		Color origColor = new Color(1f, 0.25f, 0f);
		heatWordMat.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		heatWordMat.color = origColor;
		yield return new WaitForSeconds(0.05f);
		heatWordMat.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		heatWordMat.color = origColor;
		yield return new WaitForSeconds(0.05f);
		heatWordMat.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		heatWordMat.color = origColor;
		yield return new WaitForSeconds(0.05f);
		heatWordMat.color = origColor;
		yield return new WaitForSeconds(0.05f);
		heatWordMat.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		heatWordMat.color = origColor;
		yield return new WaitForSeconds(0.05f);
		heatWordMat.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		heatWordMat.color = origColor;
		yield return new WaitForSeconds(0.05f);
		heatWordMat.color = origColor;
		yield return new WaitForSeconds(0.05f);
		heatWordMat.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		heatWordMat.color = origColor;
		yield return new WaitForSeconds(0.05f);
		heatWordMat.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		heatWordMat.color = origColor;
		yield return new WaitForSeconds(0.05f);
		heatWordMat.color = origColor;

	}

	IEnumerator DamageFlash(){
		Material targetMat = shipTransform.FindChild("MainBody").renderer.material;
		Color origColor = targetMat.color;
		targetMat.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		targetMat.color = origColor;
		yield return new WaitForSeconds(0.05f);
		targetMat.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		targetMat.color = origColor;
		dmgFlashing = false;
	}

	public void Die(){
		currentPlanet.GetComponent<PlanetPopulation>().audio.Stop ();
		if (currentPlanet.GetComponent<PlanetPopulation> ().planetType == -2) {
			currentPlanet.GetComponent<PlanetPopulation> ().audio3.Stop ();
		}
		audio.PlayOneShot (gameOverSound);
		DeactivateAllWeapons();
		shipTransform.gameObject.SetActive(false);
		transform.collider.enabled = false;
		Instantiate (Explosion, transform.position, transform.rotation);
		
		GameObject loseTextObj = new GameObject("HUD_loseText");
		loseTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		GUIText loseText = (GUIText)loseTextObj.AddComponent(typeof(GUIText));
		loseText.font = GUIFont;
		loseText.pixelOffset = new Vector2(0f, 100f);
		loseText.anchor = TextAnchor.LowerCenter;
		loseText.text = "MISSION FAILED...";
		loseText.color = Color.red;
		loseText.fontSize = 48;
		loseText.enabled = true;
		
		GameObject restartTextObj = new GameObject("HUD_restartText");
		restartTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		GUIText restartText = (GUIText)restartTextObj.AddComponent(typeof(GUIText));
		restartText.font = GUIFont;
		restartText.pixelOffset = new Vector2(0f, 80f);
		restartText.anchor = TextAnchor.MiddleCenter;
		restartText.text = "(Press [R] To Restart)";
		restartText.color = Color.white;
		restartText.fontSize = 14;
		restartText.enabled = true;
	}

	void OnCollisionEnter(Collision collision){
		// take damage upon hitting a ship
		if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Ally"){
			Vector3 collisionDir = (collision.transform.position -  transform.position).normalized;
			rigidbody.AddForce(-collisionDir * 20f, ForceMode.VelocityChange);
			if(shieldTimeRemaining <= 0f){
				TakeDamage(1);
			}
		}
	}

	void FireLaser(){
		audio.PlayOneShot (gunSound);

		switch(laserLevel){
		case 1:
			CreateLaser(0f, 0f);
			break;
		case 2:
			CreateLaser(-0.6f, 0f);
			CreateLaser(0.6f, 0f);
			break;
		case 3:
			CreateLaser(-0.6f, 0f);
			CreateLaser(0f, 0f);
			CreateLaser(0.6f, 0f);
			break;
		case 4:
			CreateLaser(-0.6f, 0f);
			CreateLaser(0f, 0f);
			CreateLaser(0.6f, 0f);
			CreateLaser(-1.5f, -15f);
			CreateLaser(1.5f, 15f);
			break;
		default:
			// level = 5
			CreateLaser(-0.6f, 0f);
			CreateLaser(0f, 0f);
			CreateLaser(0.6f, 0f);
			CreateLaser(-1.5f, -15f);
			CreateLaser(1.5f, 15f);
			CreateLaser(-2f, -30f);
			CreateLaser(2f, 30f);
			break;
		}
	}

	void CreateLaser(float offsetRight, float rotateRight){
		Vector3 location =  transform.position + transform.right.normalized * offsetRight;
		GameObject nextLaser = (GameObject)Instantiate(Laser, location, transform.rotation);
		nextLaser.transform.Rotate(new Vector3(90f, rotateRight,0f));
		LaserBehavior laserScript = nextLaser.GetComponent<LaserBehavior>();
		laserScript.laserPath = "orbit";
		laserScript.gravityCenter = currentPlanet.transform.position;
		laserScript.laserOrigin = "Player";
		laserScript.laserSpeed = 60f;
	}

	void DropBomb(){
		audio.PlayOneShot (bombSound);

		float forwardVelocity = transform.InverseTransformDirection(rigidbody.velocity).z;
		switch(bombLevel){
		case 1:
			CreateBomb(0f, 0f, forwardVelocity);
			break;
		case 2:
			CreateBomb(0f, 2f, forwardVelocity);
			CreateBomb(0f, -1f, forwardVelocity);
			break;
		default:
			CreateBomb(0f, 3f, forwardVelocity);
			CreateBomb(0f, 0f, forwardVelocity);
			CreateBomb(1f, -2f, forwardVelocity);
			CreateBomb(-1f, -2f, forwardVelocity);
			break;
		}
	}

	void CreateBomb(float offsetRight, float offsetForward, float forwardVelocity){
		Vector3 location =  transform.position + transform.right.normalized * offsetRight + transform.forward.normalized * offsetForward;
		GameObject nextbomb = (GameObject)Instantiate (Bomb, location, transform.rotation);
		nextbomb.transform.Rotate (new Vector3(180f, 0f, 0f));
		nextbomb.GetComponent<BombMovement>().gravityCenter = currentPlanet.transform.position;
		nextbomb.GetComponent<BombMovement>().bombForwardSpeed += forwardVelocity;
	}
	
	public void ActivateShield(float shieldTime){
		audio2.Play ();
		shieldText.color = Color.cyan;
		transform.FindChild("Shield").renderer.enabled = true;
		transform.FindChild("Shield").collider.enabled = true;
		shieldTimeRemaining = shieldTime;
	}
	
	void DisableShield(){
		audio2.Stop ();
		transform.FindChild("Shield").renderer.enabled = false;
		transform.FindChild("Shield").collider.enabled = false;
		UpdateWeaponText();
	}

	IEnumerator ActivateDeathRay(){
		Transform deathRay1 = shipTransform.FindChild("DeathRay1");
		Transform deathRay2 = shipTransform.FindChild("DeathRay2");
		LineRenderer line1 = deathRay1.GetComponent<LineRenderer>();
		LineRenderer line2 = deathRay2.GetComponent<LineRenderer>();
		line1.enabled = true;
		line2.enabled = true;
		float width = 0.05f + deathRayLevel * 0.05f;
		line1.SetWidth(width,width);
		line2.SetWidth(width,width);

		Transform spark1 = deathRay1.FindChild("Sparks");
		Transform spark2 = deathRay2.FindChild("Sparks");
		spark1.gameObject.SetActive(true);
		spark2.gameObject.SetActive(true);

		Transform lastTarget = transform;
		float countDown = 0f;

		float deathRayDuration = 2f;
		for(float t = 0f; t < deathRayDuration; t += Time.deltaTime){
			line1.SetPosition(0, deathRay1.position);
			line2.SetPosition(0, deathRay2.position);

//			// pattern A: death ray swings upwards
//			Vector3 rayDirection = Quaternion.AngleAxis(-45f * Mathf.Clamp01(1f - t/(deathRayDuration - 1f)), -transform.right) * transform.forward;

			// pattern B: death ray focuses on the ground
			Vector3 rayDirection = Quaternion.AngleAxis(-30f, -transform.right) * transform.forward;

			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast((transform.position - transform.up.normalized * 0.5f), rayDirection, out hit, 40f)){
				if (hit.transform.tag == "Enemy" || hit.transform.tag == "Ally"){
					if(lastTarget == hit.transform && countDown > 0f){
						countDown -= Time.deltaTime;
					} else{
						hit.transform.SendMessage("TakeDamage", 1);
						lastTarget = hit.transform;
						countDown = 0.7f/deathRayLevel;
					}
				}
				line1.SetPosition(1, hit.point - transform.right.normalized * 0.2f);
				line2.SetPosition(1, hit.point + transform.right.normalized * 0.2f);
				spark1.position = hit.point - transform.right.normalized * 0.2f;
				spark2.position = hit.point + transform.right.normalized * 0.2f;
			} else{
				line1.SetPosition(1, transform.position + rayDirection * 50f - transform.right.normalized * 0.2f);
				line2.SetPosition(1, transform.position + rayDirection * 50f + transform.right.normalized * 0.2f);
				spark1.position = transform.position + rayDirection * 50f - transform.right.normalized * 0.2f;
				spark2.position = transform.position + rayDirection * 50f + transform.right.normalized * 0.2f;
			}
			yield return null;
		}
		DeactivateDeathRay();
	}

	void DeactivateDeathRay(){
		StopCoroutine("ActivateDeathRay");
		shipTransform.FindChild("DeathRay1").GetComponent<LineRenderer>().enabled = false;
		shipTransform.FindChild("DeathRay2").GetComponent<LineRenderer>().enabled = false;
		shipTransform.FindChild("DeathRay1").FindChild("Sparks").gameObject.SetActive(false);
		shipTransform.FindChild("DeathRay2").FindChild("Sparks").gameObject.SetActive(false);
		deathRayActivated = false;
	}
	
	IEnumerator ActivateEMP(){
		EMPTransform.GetComponent<EMPBehavior>().EMPDamage = EMPLevel;
		EMPTransform.renderer.enabled = true;
		EMPTransform.collider.enabled = true;
		Vector3 startingScale = EMPTransform.localScale;
		for(float t = 0f; t < 0.5f; t += Time.deltaTime){
			EMPTransform.localScale = startingScale * (1f + t * 5f);
			yield return null;
		}
		yield return new WaitForSeconds(0.3f);
		for(float t = 0f; t < 0.4f; t += Time.deltaTime){
			EMPTransform.localScale = startingScale * (3.5f + t * 200f * EMPLevel);
			yield return null;
		}
		DeactivateEMP();
	}

	void DeactivateEMP(){
		StopCoroutine("ActivateEMP");
		EMPTransform.renderer.enabled = false;
		EMPTransform.collider.enabled = false;
		EMPTransform.localScale = EMPStartingScale;
		EMPActivated = false;
		UpdateWeaponText();
	}
	
	public void DeactivateAllWeapons(){
		DisableShield();
		DeactivateDeathRay();
		DeactivateEMP();
		RemoveDisplayText();
		overHeatMeter = 0f;
		enemyText.text = "";
		allyText.text = "";
		compass.SetActive(false);
		lastEnemy = null;
		
		konamiIndex = 10;
	}
	
	public bool GetLoot(string lootType, int lootValue){
		if(lootValue < 0){
			return false;
		}
		
		switch (lootType){
		case "HeatLimitBreaker":
			break;
		case "InstantShield":
			break;
		case "Health":
			if(health >= 5){
				return false;
			}
			goto default;
		default:
			StartCoroutine(LootDisplay(lootType, lootValue));
			break;
		}
		return true;
	}

	public IEnumerator LootDisplay(string lootType, int lootValue){
		switch (lootType){
		case "Health":

			audio.PlayOneShot (healthSound);
//			for(float t = 0f; t < 1f; t += Time.deltaTime){
//				healthText.text = "HEALTH: " + (health - lootValue).ToString() + "  + " + lootValue;
//				yield return null;
//			}
//			healthText.text = "HEALTH: " + health;
			if (health >= 5){
				break;
			}
			else{
				health += lootValue;
				UpdateHealth();
			}
			break;
		case "Currency":
			currency += lootValue;
			audio.PlayOneShot (healthSound);
			for(float t = 0f; t < 1f; t += Time.deltaTime){
				currencyText.text = "CURRENCY: " + (currency - lootValue).ToString() + "  + " + lootValue;
				yield return null;
			}
			currencyText.text = "CURRENCY: " + currency;
			break;
		default:
			break;
		}
	}
	
	public void PurchaseItem(string item, int price){
		currency -= price;
		currencyText.text = "CURRENCY: " + currency;
		
		switch(item){
		case "Laser":
			DisplayText("LASER UPGRADED.",1f);
			laserLevel ++;
			break;
		case "Bomb":
			DisplayText("BOMB UPGRADED.",1f);
			bombLevel++;
			break;
		case "Shield":
			DisplayText("SHIELD CHARGE PURCHASED.",1f);
			shieldCharges++;
			break;
		case "Death Ray":
			if(deathRayLevel == 0){
				DisplayText("DEATH RAY INSTALLED. ACTIVATION:[U]\n",1f);
			} else{
				DisplayText("DEATH RAY UPGRADED.",1f);
			}
			deathRayLevel++;
			break;
		case "Mine":
			DisplayText("MINE CHARGE PURCHASED.",1f);
			mineCharges++;
			break;
		case "EMP":
			if(EMPLevel == 0){
				DisplayText("EMP INSTALLED. ACTIVATION:[O]\nUSAGE CONSUMES SHIELD CHARGES.",1f);
			} else{
				DisplayText("EMP UPGRADED.",1f);
			}
			EMPLevel++;
			break;
		default:
			break;
		}
		UpdateWeaponText();

	}

	void UpdateWeaponText(){
		string text = "[J]: Laser\n[K]: Bomb";
		if(shieldCharges > 0){
			text += "\n[L]: Shield";
		}
		if(deathRayLevel > 0){
			text += "\n[U]: Death Ray";
		}
		if(mineCharges > 0){
			text += "\n[I]: Mine";
		}
		if(shieldCharges > 0 && EMPLevel > 0){
			text += "\n[O]: EMP";
		}
		weaponText.text = text;
		
		if(mineCharges <= 0){
			mineText.color = Color.red;
		} else{
			mineText.color = Color.magenta;
		}
		mineText.text = "MINE CHARGES: " + mineCharges;

		if(EMPActivated){
			shieldText.anchor = TextAnchor.UpperRight;
			shieldText.pixelOffset = new Vector2(Screen.width/2 - 40f, Screen.height/2 - 60f);
			shieldText.color = Color.cyan;
			shieldText.text = "EMP ACTIVATED";
		} else if(shieldTimeRemaining <= 0f){
			shieldText.anchor = TextAnchor.UpperRight;
			shieldText.pixelOffset = new Vector2(Screen.width/2 - 40f, Screen.height/2 - 60f);
			if(shieldCharges <= 0){
				shieldText.color = Color.red;
			} else{
				shieldText.color = Color.magenta;
			}
			shieldText.text = "SHIELD CHARGES: " + shieldCharges;
		}
	}
	
	public bool ItemMaxed(string item){
		switch(item){
		case "Laser":
			if(laserLevel >= 5){
				return true;
			}
			break;
		case "Bomb":
			if(bombLevel >= 3){
				return true;
			}
			break;
		case "Shield":
			if(shieldCharges >= 5){
				return true;
			}
			break;
		case "Death Ray":
			if(deathRayLevel >= 3){
				return true;
			}
			break;
		case "Mine":
			if(mineCharges >= 10){
				return true;
			}
			break;
		case "EMP":
			if(EMPLevel >= 3){
				return true;
			}
			break;
		default:
			break;
		}
		
		return false;
	}
	
	public int GetItemLevel(string item){
		switch(item){
		case "Laser":
			return laserLevel;
		case "Bomb":
			return bombLevel;
		case "Shield":
			return shieldCharges;
		case "Death Ray":
			return deathRayLevel;
		case "Mine":
			return mineCharges;
		case "EMP":
			return EMPLevel;
		default:
			break;
		}
		return 0;
	}

	// ENDING SEQUENCE
	public void HUDOff(){
		currencyText.enabled = false;
		shieldText.enabled = false;
		mineText.enabled = false;
		movementText.enabled = false;
		weaponText.enabled = false;
		enemyText.enabled = false;
		allyText.enabled = false;
		transform.FindChild("Heat Bar").gameObject.SetActive(false);
		transform.FindChild("Health Bar").gameObject.SetActive(false);
		shipTransform.FindChild("_TailFlameLeft").GetComponent<ParticleSystem>().startSpeed = 0.2f * 20f;
		shipTransform.FindChild("_TailFlameRight").GetComponent<ParticleSystem>().startSpeed = 0.2f * 20f;
	}

	public void EngineOff(){
		// turn off tail flame
		shipTransform.Find("_TailFlameLeft").gameObject.SetActive(false);
		shipTransform.Find("_TailFlameRight").gameObject.SetActive(false);
	}


	// TEXT FUNCTIONS
	public void DisplayText(string text, float time){
		float HideTime = time + text.Length * 0.08f;
		StopCoroutine("DisplayTextChars");
		StopCoroutine("RemoveDisplayTextWithDelay");
		gameText.text = "";
		StartCoroutine("DisplayTextChars", text);
		StartCoroutine("RemoveDisplayTextWithDelay", HideTime);
	}
	
	public void DisplayTextInstant(string text, float time){
		StopCoroutine("DisplayTextChars");
		StopCoroutine("RemoveDisplayTextWithDelay");
		gameText.text = text;
		StartCoroutine("RemoveDisplayTextWithDelay", time);
	}

	public void DisplayAdditionalText(string text, float time){
		float HideTime = time + text.Length * 0.08f;
		StopCoroutine("DisplayTextChars");
		StopCoroutine("RemoveDisplayTextWithDelay");
		gameText.text += "\n";
		StartCoroutine("DisplayTextChars", text);
		StartCoroutine("RemoveDisplayTextWithDelay", HideTime);
	}

	IEnumerator DisplayTextChars(string text){
		for(int i = 0; i < text.Length; i++){
			gameText.text += text[i];
			yield return new WaitForSeconds(0.08f);
			audio3.Play();
	
		}
		audio3.Stop ();
	}
	
	public void RemoveDisplayText(){
		StopCoroutine("DisplayTextChars");
		audio3.Stop ();
		gameText.text = "";
	}

	IEnumerator RemoveDisplayTextWithDelay(float time){
		yield return new WaitForSeconds(time);
		RemoveDisplayText();
		audio3.Stop ();
	}

	IEnumerator CameraShake(){
		float decrease = 60f;
		float magnitude = 0.000001f;
		Quaternion origRot = cameraTransform.transform.localRotation;
		for(float t = 0f; t < 0.1f; t += Time.deltaTime){
			magnitude -= decrease * Time.deltaTime;
			float xMod = Random.Range(-magnitude, magnitude);
			float yMod = Random.Range(-magnitude, magnitude);
			float zMod = Random.Range(-magnitude, magnitude);
			Quaternion targetQuat = cameraTransform.transform.localRotation * Quaternion.Euler(new Vector3(0f,yMod,0f));
			cameraTransform.transform.localRotation =  Quaternion.Lerp(cameraTransform.transform.localRotation, targetQuat, Random.Range(0f,0.5f));
			yield return null;
		}
		cameraTransform.transform.localRotation = origRot;
	}

	// enemy and ally counters, called by planetpopulation
	public void UpdateEnemyCounter(int enemyCounter){
		if(isFinalStage){
			enemyText.color = Color.red;
			enemyText.text = "Enemies: " + enemyCounter;
		} else if(enemyCounter > 0){
			if(enemyCounter > 1){
				enemyText.color = Color.red;
				enemyText.text = "Enemies Left: " + enemyCounter;
			} else{
				enemyText.text = "";
				if(lastEnemy == null){
					compass.SetActive(true);
					lastEnemy = GameObject.FindGameObjectWithTag("Enemy").transform;
				}
			}
		} else{
			lastEnemy = null;
			compass.SetActive(false);
			enemyText.color = Color.cyan;
			enemyText.text = "Planet Cleared!";
			if(health <= 0){
				// don't display text if player died
				return;
			}
			if(allyText.enabled == true){
				allyText.enabled = false;
				int reward = 35 + Random.Range(5,15);
				GetLoot("Currency", reward);
				DisplayText(reward + " CURRENCY RECEIVED\n\n\n\"This is a token of our gratitude.\nThank you for your aid, friend.\"", 3f);
			} else if(!objectiveDisplayed){
				objectiveDisplayed = true;
				DisplayTextInstant("INCOMING TRANSMISSION:\n\n", 5f);
				DisplayAdditionalText("\"Well done, Captain.\n\n" +
				                      "But it's not over yet. We have found\n" +
				                      "a planet with a RED transport beam,\n" +
				                      "which is very likely to be their base.\n" +
				                      "\nGood luck, and Godspeed.\"", 3f);
			}
		}
	}
	
	public void UpdateAllyCounter(int allyCounter){
		if(allyCounter > 0){
			allyText.enabled = true;
			allyText.text = "Allies Left: " + allyCounter;
		} else{
			allyText.enabled = false;
		}
	}
	
	void KonamiCheck(){
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			if(konamiCode[konamiIndex] != KeyCode.UpArrow){
				konamiIndex = 0;
			} else{
				konamiIndex ++;
			}
		}
		
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			if(konamiCode[konamiIndex] != KeyCode.DownArrow){
				konamiIndex = 0;
			} else{
				konamiIndex ++;
			}
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			if(konamiCode[konamiIndex] != KeyCode.LeftArrow){
				konamiIndex = 0;
			} else{
				konamiIndex ++;
			}
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			if(konamiCode[konamiIndex] != KeyCode.RightArrow){
				konamiIndex = 0;
			} else{
				konamiIndex ++;
			}
		}
		if(Input.GetKeyDown(KeyCode.B)){
			if(konamiCode[konamiIndex] != KeyCode.B){
				konamiIndex = 0;
			} else{
				konamiIndex ++;
			}
		}
		if(Input.GetKeyDown(KeyCode.A)){
			if(konamiCode[konamiIndex] != KeyCode.A){
				konamiIndex = 0;
			} else{
				konamiIndex ++;
			}
		}
		
		if(konamiIndex == 10){
			health = 10000000;
			UpdateHealth();
			GetLoot("Currency", 9001 - currency);
			overHeatLimit = 100000000000f;
			laserLevel = 5;
			bombLevel = 3;
			shieldCharges = 100;
			deathRayLevel = 3;
			mineCharges = 100;
			EMPLevel = 3;
			UpdateWeaponText();
		}
	}
}

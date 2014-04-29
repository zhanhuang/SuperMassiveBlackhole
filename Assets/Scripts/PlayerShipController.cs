using UnityEngine;
using System.Collections;

// Inherits from ShipOrbitBehavior
public class PlayerShipController : ShipOrbitBehavior {
	public GalaxyPopulation Galaxy;

	// shop
	public int currency = 30;
	int laserLevel = 1;
	int bombLevel = 1;
	int deathRayLevel = 0;
	int pulseWeaponLevel = 0;
	int flamethrowerLevel = 0;
	
	public float overHeatLimit = 5f;
	float overHeatMeter = 0f;
	float coolOffCounter = 0f;

	int shieldCharges = 2;
	float shieldLimit = 3f;
	float shieldTimeRemaining = 0f;

	int mineCharges = 2;

	// ship stat variables
	float acceleration = 50f;
	float turnAcceleration = 20f;

	public Transform shipTransform;
	GameObject playerCamera;
	GameObject Explosion;

	Vector3 cameraStartingLocalPosition;

	GameObject Laser;
	GameObject Bomb;
	GameObject Mine;

	bool flashing = false;

	int health = 5;
	GUIText healthText;
	GUIText currencyText;
	GUIText heatText;
	GUIText shieldText;
	GUIText mineText;
	GUIText weaponText;
	GUIText enemyText;
	GUIText allyText;

	public AudioClip gunSound;
	public AudioClip bombSound;
	public AudioClip healthSound;

	int soundCount = 0;


	// Use this for initialization
	void Start () {
//		currentPlanet = GameObject.Find("Planet");
		OrbitSetup();

		// set camera culling to spherical
		transform.GetComponentInChildren<Camera>().layerCullSpherical = true;

		// load prefab
		Bomb = (GameObject)Resources.Load("Bomb");
		Laser = (GameObject)Resources.Load("Laser_Blue");
		Mine = (GameObject)Resources.Load("Mine_Yellow");
		Explosion = (GameObject)Resources.Load("Explosion_Player");

		// set camera
		shipTransform = transform.FindChild("Ship");
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
		
		GameObject currencyTextObj = new GameObject("HUD_currencyCounter");
		currencyTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		currencyText = (GUIText)currencyTextObj.AddComponent(typeof(GUIText));
		currencyText.pixelOffset = new Vector2(-Screen.width/2 + 40f, - Screen.height/2 + 30f);
		currencyText.fontSize = 18;
		currencyText.color = Color.yellow;
		currencyText.text = "CURRENCY: " + currency;
		
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
		
		// shield counter
		GameObject shieldTextObj = new GameObject("HUD_shieldCounter");
		shieldTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		shieldText = (GUIText)shieldTextObj.AddComponent(typeof(GUIText));
		shieldText.anchor = TextAnchor.UpperLeft;
		shieldText.pixelOffset = new Vector2(-Screen.width/2 + 40f, Screen.height/2 - 60f);
		shieldText.fontSize = 18;
		shieldText.color = Color.green;
		shieldText.text = "";
		if(shieldCharges > 0){
			shieldText.text = "SHIELD CHARGES: " + shieldCharges;
		}
		// mine counter
		GameObject mineTextObj = new GameObject("HUD_mineCounter");
		mineTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		mineText = (GUIText)mineTextObj.AddComponent(typeof(GUIText));
		mineText.anchor = TextAnchor.UpperLeft;
		mineText.pixelOffset = new Vector2(-Screen.width/2 + 40f, Screen.height/2 - 90f);
		mineText.fontSize = 18;
		mineText.color = Color.green;
		mineText.text = "";
		if(mineCharges > 0){
			mineText.text = "MINE CHARGES: " + mineCharges;
		}
		
		// weapon text
		GameObject weaponTextObj = new GameObject("HUD_weaponText");
		weaponTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		weaponText = (GUIText)weaponTextObj.AddComponent(typeof(GUIText));
		weaponText.anchor = TextAnchor.LowerRight;
		weaponText.pixelOffset = new Vector2(Screen.width/2 - 40f, -Screen.height/2 + 30f);
		weaponText.fontSize = 18;
		weaponText.color = Color.magenta;
		weaponText.text = "[J]: Laser\n[K]: Bomb\n[L]: Shield\n[I]: Mine";
		
		// enemy counter for current planet
		GameObject enemyTextObj = new GameObject("HUD_enemyCounter");
		enemyTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		enemyText = (GUIText)enemyTextObj.AddComponent(typeof(GUIText));
		enemyText.anchor = TextAnchor.MiddleCenter;
		enemyText.pixelOffset = new Vector2(0f, Screen.height/2 - 30f);
		enemyText.fontSize = 18;
		enemyText.color = Color.red;
		enemyText.text = "Enemies Left: 0";
		
		// ally counter for current planet
		GameObject allyTextObj = new GameObject("HUD_allyCounter");
		allyTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		allyText = (GUIText)allyTextObj.AddComponent(typeof(GUIText));
		allyText.anchor = TextAnchor.MiddleCenter;
		allyText.pixelOffset = new Vector2(0f, Screen.height/2 - 50f);
		allyText.fontSize = 18;
		allyText.color = Color.green;
		allyText.enabled = false;
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
			overHeatMeter -= Time.deltaTime * Mathf.Clamp(coolOffCounter, 1f, Mathf.Infinity);
			overHeatMeter = Mathf.Clamp(overHeatMeter, 0f, overHeatLimit*2);
		}

		if(shieldTimeRemaining > 0f){
			shieldTimeRemaining -= Time.deltaTime;
			shieldText.text = "SHIELD ENGAGED. TIME LEFT: " + shieldTimeRemaining.ToString("F2");
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
				heatText.color = Color.cyan;
			} else{
				heatText.color = Color.white;
			}

			// shooting
			if (Input.GetKeyDown(KeyCode.J)){
				FireLaser();

				overHeatMeter += 1f;
				coolOffCounter = 0f;
			}
			
			// bombing
			if (Input.GetKeyDown (KeyCode.K)) {

				DropBomb();

				overHeatMeter += 1f;
				coolOffCounter = 0f;
			}
			
			// shielding
			if (Input.GetKeyDown (KeyCode.L)) {
				if(shieldCharges > 0 && shieldTimeRemaining <= 0f){
					shieldCharges --;
					ActivateShield(shieldLimit);
				}
			}

			// setting mine
			if (Input.GetKeyDown (KeyCode.I)) {
				if(mineCharges > 0){
					mineCharges --;
					if(mineCharges <= 0){
						mineText.color = Color.red;
					}
					mineText.text = "MINE CHARGES: " + mineCharges;
					GameObject nextmine = (GameObject)Instantiate(Mine, transform.position, transform.rotation);
					nextmine.transform.GetComponent<MineMovement>().mineOrigin = "Player";
				}
			}
		} else{
			//TODO: show overheat meter
			heatText.color = Color.red;
		}
		
		// tail particle effect
		float forwardVelocity = transform.InverseTransformDirection(rigidbody.velocity).z;
		if(forwardVelocity > 0f){
			shipTransform.FindChild("_TailFlameLeft").GetComponent<ParticleSystem>().startSpeed = 0.3f * forwardVelocity;
			shipTransform.FindChild("_TailFlameRight").GetComponent<ParticleSystem>().startSpeed = 0.3f * forwardVelocity;
		}
		


//		// zoom camera according to speed. TODO: decide if we want this in or not
//		Vector3 adjustedCameraRotation = new Vector3(cameraStartingLocalPosition.x, cameraStartingLocalPosition.y - forwardVelocity, cameraStartingLocalPosition.z + forwardVelocity);
//		transform.GetChild(0).transform.localPosition = adjustedCameraRotation;

		// update heat text
		heatText.text = "WEAPON HEAT: " + overHeatMeter.ToString("F1") + "/" + overHeatLimit.ToString("F1");

		// enemy and ally counters
		int enemyCounter = currentPlanet.transform.GetComponent<PlanetPopulation>().EnemyCounter;
		if(enemyCounter > 0){
			enemyText.color = Color.red;
			enemyText.text = "Enemies Left: " + enemyCounter;
		} else{
			enemyText.color = Color.cyan;
			enemyText.text = "Planet Cleared!";
		}
		
		int allyCounter = currentPlanet.transform.GetComponent<PlanetPopulation>().AllyCounter;
		if(allyCounter > 0){
			allyText.enabled = true;
			allyText.text = "Allies Left: " + allyCounter;
		} else{
			allyText.enabled = false;
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
		healthText.text = "HEALTH: " + health;

		if(health <= 0){
			healthText.color = Color.red;
			Die();
		} else{
			if(!flashing){
				flashing = true;
				StartCoroutine(DamageFlash());
			}
		}
	}

	IEnumerator DamageFlash(){
		Material targetMat = transform.FindChild("Ship").FindChild("MainBody").renderer.material;
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

	public void Die(){
		currentPlanet.GetComponent<PlanetPopulation> ().audio.Stop ();
		Destroy(transform.Find("Ship").gameObject);
		transform.collider.enabled = false;
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
	
	public void ActivateShield(float shieldTime){
		shieldText.color = Color.cyan;
		transform.FindChild("Shield").renderer.enabled = true;
		transform.FindChild("Shield").collider.enabled = true;
		shieldTimeRemaining = shieldTime;
	}

	public void DisableShield(){
		transform.FindChild("Shield").renderer.enabled = false;
		transform.FindChild("Shield").collider.enabled = false;
		shieldText.text = "SHIELD CHARGES: " + shieldCharges;
		if(shieldCharges == 0){
			shieldText.color = Color.red;
		} else{
			shieldText.color = Color.green;
		}
	}

	public void GetLoot(string lootType, int lootValue){
		if(lootValue < 0){
			return;
		}

		switch (lootType){
		case "Health":
			health += lootValue;
			healthText.text = "HEALTH: " + health;
			audio.PlayOneShot (healthSound);
			break;
		case "Currency":
			currency += lootValue;
			currencyText.text = "CURRENCY: " + currency;
			audio.PlayOneShot (healthSound);
			break;
		default:
			break;
		}
	}

	void OnCollisionEnter(Collision collision){
		// take damage upon hitting a ship
		if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Ally"){
			Vector3 collisionDir = (collision.transform.position -  transform.position).normalized;
			rigidbody.AddForce(-collisionDir * 20f, ForceMode.VelocityChange);
			TakeDamage(1);
		}
	}
	
	public void PurchaseItem(string item, int price){
		currency -= price;
		currencyText.text = "CURRENCY: " + currency;
		
		switch(item){
		case "Laser":
			laserLevel ++;
			break;
		case "Bomb":
			bombLevel++;
			break;
		case "Shield":
			shieldCharges++;
			shieldText.enabled = true;
			shieldText.text = "SHIELD CHARGES: " + mineCharges;
			break;
		case "Mine":
			mineCharges++;
			mineText.enabled = true;
			mineText.text = "MINE CHARGES: " + mineCharges;
			break;
		default:
			break;
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
		case "Mine":
			if(mineCharges >= 10){
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
		case "Mine":
			return mineCharges;
		default:
			break;
		}
		return 0;
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
}

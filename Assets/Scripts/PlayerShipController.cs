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
	int mineCharges = 2;
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

	GameObject MoveJoint;
	GameObject BaseJoint;

	bool flashing = false;

	GUIText healthText;
	GUIText currencyText;
	GUIText heatText;
	GUIText shieldText;
	GUIText mineText;
	GUIText movementText;
	GUIText weaponText;
	GUIText enemyText;
	GUIText allyText;

	public AudioClip gunSound;
	public AudioClip bombSound;
	public AudioClip healthSound;
	public AudioClip gameOverSound;
	public AudioClip deathRaySound;
	public AudioClip empSound;

	public AudioSource audio2;

	int soundCount = 0;


	// Use this for initialization
	void Start () {
//		currentPlanet = GameObject.Find("Planet");
		OrbitSetup();

		// setup joint for heat bar
		MoveJoint = transform.FindChild("Heat Bar").FindChild("BaseJoint").FindChild("MoveJoint").gameObject;

		// set camera culling to spherical
		transform.GetComponentInChildren<Camera>().layerCullSpherical = true;

		// load prefab
		Bomb = (GameObject)Resources.Load("Bomb");
		Laser = (GameObject)Resources.Load("Laser_Blue");
		Mine = (GameObject)Resources.Load("Mine_Yellow");
		Explosion = (GameObject)Resources.Load("Explosion_Player");

		// load font
		Font GUIFont = (Font)Resources.Load("AirStrike");

		// set camera
		shipTransform = transform.FindChild("Ship");
		playerCamera = transform.FindChild("Camera").gameObject;
		cameraStartingLocalPosition = playerCamera.transform.localPosition;

		// set emp
		EMPTransform = transform.FindChild("EMP");
		EMPStartingScale = EMPTransform.localScale;
		
		// health counter 
		// TODO: Have a bar for this
		GameObject healthTextObj = new GameObject("HUD_healthCounter");
		healthTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		healthText = (GUIText)healthTextObj.AddComponent(typeof(GUIText));
		healthText.pixelOffset = new Vector2(-Screen.width/2 + 40f, Screen.height/2 - 30f);
		healthText.fontSize = 18;
		healthText.font = GUIFont;
		healthText.color = Color.green;
		healthText.text = "HEALTH: " + health;
		
		GameObject currencyTextObj = new GameObject("HUD_currencyCounter");
		currencyTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		currencyText = (GUIText)currencyTextObj.AddComponent(typeof(GUIText));
		currencyText.pixelOffset = new Vector2(-Screen.width/2 + 40f, Screen.height/2 - 60f);
		currencyText.fontSize = 18;
		currencyText.font = GUIFont;
		currencyText.color = Color.yellow;
		currencyText.text = "CURRENCY: " + currency;
		
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
		heatMat = transform.FindChild("Heat Bar").FindChild("Bar").renderer.material;
		heatWordMat = transform.FindChild("Heat Bar").FindChild("HeatText").renderer.materials[1];
		heatWordMat.color = new Color(1f, 0.25f, 0f);

		// shield counter
		GameObject shieldTextObj = new GameObject("HUD_shieldCounter");
		shieldTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		shieldText = (GUIText)shieldTextObj.AddComponent(typeof(GUIText));
		shieldText.anchor = TextAnchor.UpperRight;
		shieldText.pixelOffset = new Vector2(Screen.width/2 - 40f, Screen.height/2 - 60f);
		shieldText.fontSize = 18;
		shieldText.font = GUIFont;
		shieldText.text = "";

		// mine counter
		GameObject mineTextObj = new GameObject("HUD_mineCounter");
		mineTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		mineText = (GUIText)mineTextObj.AddComponent(typeof(GUIText));
		mineText.anchor = TextAnchor.UpperRight;
		mineText.pixelOffset = new Vector2(Screen.width/2 - 40f, Screen.height/2 - 90f);
		mineText.fontSize = 18;
		mineText.font = GUIFont;
		mineText.text = "";
		
		// movement text
		GameObject moveTextObj = new GameObject("HUD_moveText");
		moveTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		movementText = (GUIText)moveTextObj.AddComponent(typeof(GUIText));
		movementText.anchor = TextAnchor.LowerLeft;
		movementText.pixelOffset = new Vector2(-Screen.width/2 + 40f, -Screen.height/2 + 30f);
		movementText.fontSize = 18;
		movementText.font = GUIFont;
		movementText.color = Color.grey;
		movementText.text = "Move: \n[Q][W][E]\n[A][S][D]";
		
		// weapon text
		GameObject weaponTextObj = new GameObject("HUD_weaponText");
		weaponTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		weaponText = (GUIText)weaponTextObj.AddComponent(typeof(GUIText));
		weaponText.anchor = TextAnchor.LowerRight;
		weaponText.pixelOffset = new Vector2(Screen.width/2 - 40f, -Screen.height/2 + 30f);
		weaponText.fontSize = 18;
		weaponText.font = GUIFont;
		weaponText.color = Color.magenta;
		
		// enemy counter for current planet
		GameObject enemyTextObj = new GameObject("HUD_enemyCounter");
		enemyTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		enemyText = (GUIText)enemyTextObj.AddComponent(typeof(GUIText));
		enemyText.anchor = TextAnchor.MiddleCenter;
		enemyText.pixelOffset = new Vector2(0f, Screen.height/2 - 30f);
		enemyText.fontSize = 18;
		enemyText.font = GUIFont;
		enemyText.color = Color.red;
		enemyText.text = "Enemies Left: 0";
		
		// ally counter for current planet
		GameObject allyTextObj = new GameObject("HUD_allyCounter");
		allyTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		allyText = (GUIText)allyTextObj.AddComponent(typeof(GUIText));
		allyText.anchor = TextAnchor.MiddleCenter;
		allyText.pixelOffset = new Vector2(0f, Screen.height/2 - 50f);
		allyText.fontSize = 18;
		allyText.font = GUIFont;
		allyText.color = Color.green;
		allyText.enabled = false;

		
		UpdateWeaponText();
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
				overHeatMeter += .4f * laserLevel;
				coolOffCounter = 0f;
			}
			
			// bombing
			if (Input.GetKeyDown (KeyCode.K)) {

				DropBomb();

				overHeatMeter += 2f * bombLevel;
				coolOffCounter = 0f;
			}
			
			// shielding
			if (Input.GetKeyDown (KeyCode.L)) {
				if(shieldCharges > 0 && shieldTimeRemaining <= 0f && !EMPActivated){
					shieldCharges --;
					ActivateShield(shieldLimit);
				}
			}
			
			// death ray
			if (Input.GetKeyDown (KeyCode.U)) {
				if(deathRayLevel > 0 && !deathRayActivated){
					audio.PlayOneShot (deathRaySound);
					deathRayActivated = true;
					StartCoroutine(ActivateDeathRay());
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
					StartCoroutine(ActivateEMP());
				}
			}
			if (overHeatMeter > overHeatLimit){
				overHeatMeter = 12;
				coolOffCounter = -.5f;
				if(!flashing){
					flashing = true;
					StartCoroutine(OverheatFlash());
				}
			}
		} 
		else{
			//TODO: show overheat meter
//			heatText.color = Color.red;
			heatMat.color = new Color(1f, .118f, .118f);
		}
			
		// tail particle effect
		float forwardVelocity = transform.InverseTransformDirection(rigidbody.velocity).z;
		if(forwardVelocity > 0f){
			shipTransform.FindChild("_TailFlameLeft").GetComponent<ParticleSystem>().startSpeed = 0.3f * forwardVelocity;
			shipTransform.FindChild("_TailFlameRight").GetComponent<ParticleSystem>().startSpeed = 0.3f * forwardVelocity;
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
			if(health <= 2){
				healthText.color = new Color(1f, 0.5f, 0f);
			}
			if(!flashing){
				flashing = true;
				StartCoroutine(DamageFlash());
			}
		}
	}

	IEnumerator OverheatFlash(){
		Color origColor = heatWordMat.color;
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

		flashing = false;
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
		audio.PlayOneShot (gameOverSound);
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
		LineRenderer line = transform.GetComponent<LineRenderer>();
		line.enabled = true;
		line.SetWidth(0.2f,0.2f);

		Transform lastTarget = transform;
		float countDown = 0f;

		float deathRayDuration = 2f;
		for(float t = 0f; t < (deathRayDuration + 1f); t += Time.deltaTime){
			line.SetPosition(0, (transform.position - transform.up.normalized * 0.5f));
			Vector3 rayDirection = Quaternion.AngleAxis(-45f * Mathf.Clamp01(1f - t/deathRayDuration), -transform.right) * transform.forward;
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast((transform.position - transform.up.normalized * 0.5f), rayDirection, out hit, 40f)){
				if (hit.transform.tag == "Enemy" || hit.transform.tag == "Ally"){
					if(lastTarget == hit.transform && countDown > 0f){
						countDown -= Time.deltaTime;
					} else{
						hit.transform.SendMessage("TakeDamage", 1);
						lastTarget = hit.transform;
						countDown = 1f/deathRayLevel;
					}
				}
				line.SetPosition(1, hit.point);
			} else{
				line.SetPosition(1, transform.position + rayDirection * 100f);
			}
			yield return null;
		}
		
		line.enabled = false;
		deathRayActivated = false;
	}

	void DeactivateDeathRay(){
		StopCoroutine("ActivateDeathRay");
		transform.GetComponent<LineRenderer>().enabled = false;
		deathRayActivated = false;
	}
	
	IEnumerator ActivateEMP(){
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
	}
	
	public void GetLoot(string lootType, int lootValue){
		if(lootValue < 0){
			return;
		}
		
		switch (lootType){
		case "HeatLimitBreaker":
			break;
		case "InstantShield":
			break;
		default:
			StartCoroutine(LootDisplay(lootType, lootValue));
			break;
		}
	}

	public IEnumerator LootDisplay(string lootType, int lootValue){
		switch (lootType){
		case "Health":
			health += lootValue;
			audio.PlayOneShot (healthSound);
			for(float t = 0f; t < 1f; t += Time.deltaTime){
				healthText.text = "HEALTH: " + (health - lootValue).ToString() + "  + " + lootValue;
				yield return null;
			}
			healthText.text = "HEALTH: " + health;
			if(health > 2){
				healthText.color = Color.green;
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
			laserLevel ++;
			break;
		case "Bomb":
			bombLevel++;
			break;
		case "Shield":
			shieldCharges++;
			break;
		case "Death Ray":
			deathRayLevel++;
			break;
		case "Mine":
			mineCharges++;
			break;
		case "EMP":
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
}

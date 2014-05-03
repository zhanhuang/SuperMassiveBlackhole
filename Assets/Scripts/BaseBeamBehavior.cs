using UnityEngine;
using System.Collections;

public class BaseBeamBehavior : MonoBehaviour {
	public bool shopEnabled = false;

	Transform player;
	PlayerShipController playerScript;
	public GUIText beamText;

	bool liftOff = false;
	bool inSpace = false;
	bool shopping = false;

	GameObject[] surroundingPlanets;
	int lookingPlanet = 0;
	
	// shop
	string[] items = new string[6];
	int[] prices = new int[6];
	GUIText[] itemTexts = new GUIText[7];
	GUIText[] priceTexts = new GUIText[6];
	int selectedIndex = 0;

	Font GUIFont;

	// last two planets
	public bool isFinalBeam = false;
	public bool isEndBeam = false;

	public AudioSource audio2;

	public AudioClip storeScroll;
	public AudioClip storeBuy;
	public AudioClip storeCantBuy;
	public AudioClip takeoff;

	// Use this for initialization
	void Start () {
		
		// load font
		GUIFont = (Font)Resources.Load("AirStrike");

		GameObject beamTextObj = new GameObject("HUD_beamText");
		beamTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		beamText = (GUIText)beamTextObj.AddComponent(typeof(GUIText));
		beamText.fontSize = 24;
		beamText.font = GUIFont;
		beamText.anchor = TextAnchor.MiddleCenter;
		beamText.color = Color.black;
		beamText.text = "[Space]: Engage Planar Drive";
		beamText.enabled = false;

		surroundingPlanets = new GameObject[8];

	}
	
	// Update is called once per frame
	void Update () {
		if (isEndBeam && beamText.enabled){
			if(Input.GetKeyDown(KeyCode.Space)){
				StartCoroutine(BeamMeUp());
			}
			return;
		}

		if (shopping){
			if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)){
				audio2.Stop ();
				if(playerScript.currentPlanet.GetComponent<PlanetPopulation>().planetType == -1){
					player.audio.Play ();
					playerScript.currentPlanet.transform.FindChild ("ClearPulse").audio.Play ();}
				else{
					playerScript.currentPlanet.transform.GetComponent<PlanetPopulation>().audio2.Play ();
					playerScript.currentPlanet.transform.FindChild ("ClearPulse").audio.Play ();}
				shopping = false;
				CloseDownShop();
			} else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
				audio.PlayOneShot (storeScroll);
				RemoveHighLight(selectedIndex);

				selectedIndex --;
				if(selectedIndex < 0){
					selectedIndex = 5;
				}

				HighLight(selectedIndex);
			} else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
				audio.PlayOneShot (storeScroll);
				RemoveHighLight(selectedIndex);

				selectedIndex ++;
				if(selectedIndex > 5){
					selectedIndex = 0;
				}
				
				HighLight(selectedIndex);
			} else if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.J)){
				// purchased an item
				if(playerScript.currency >= prices[selectedIndex] && itemTexts[selectedIndex].text != "Sold Out"){
					audio.PlayOneShot (storeBuy);
					playerScript.PurchaseItem(items[selectedIndex], prices[selectedIndex]);
					UpdateItem(selectedIndex);
				}
				else{
					audio.PlayOneShot (storeCantBuy);
				}
			}
			return;
		}

		if (!liftOff && beamText.enabled){
			if(Input.GetKeyDown(KeyCode.Space)){
				liftOff = true;
				StartCoroutine(BeamMeUp());
			} else if(Input.GetKeyDown(KeyCode.P) && shopEnabled == true){
				playerScript.DeactivateAllWeapons();
				player.audio.Stop ();
				playerScript.currentPlanet.transform.GetComponent<PlanetPopulation>().audio2.Stop ();
				playerScript.currentPlanet.transform.FindChild ("ClearPulse").audio.Stop ();
				audio2.Play ();
				shopping = true;
				OpenUpShop();
			}
		}

		if (inSpace){
			// adjust rotation so camera faces target planet
			Vector3 lookDirection = surroundingPlanets[lookingPlanet].transform.position - player.position;
			Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
			targetRotation *= Quaternion.Inverse(player.FindChild("Camera").localRotation);
			player.rotation = Quaternion.Lerp(player.rotation, targetRotation, Time.deltaTime * 6f);
			if (Input.GetKeyDown(KeyCode.A)){
				if(lookingPlanet == 0){
					lookingPlanet = 7;
					while(surroundingPlanets[lookingPlanet] == null){
						lookingPlanet --;
					}
				} else{
					lookingPlanet --;
				}
			} else if (Input.GetKeyDown(KeyCode.D)){
				if(lookingPlanet == 7 || surroundingPlanets[lookingPlanet + 1] == null){
					lookingPlanet = 0;
				} else{
					lookingPlanet ++;
				}
			} else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.J)){
				liftOff = false;
				inSpace = false;
				audio.Stop();
				// set rotation on moving
				player.rotation = targetRotation;
				StartCoroutine(FlyOff());
			}
		}
	}

	IEnumerator BeamMeUp(){
		beamText.enabled = false;

		// disconnect and freeze player
		Destroy(player.GetComponent<ConfigurableJoint>());
		playerScript.DeactivateAllWeapons();
		playerScript.enabled = false;
		player.rigidbody.velocity = Vector3.zero;
		player.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
		playerScript.shipTransform.localRotation = Quaternion.identity;

		// play beam audio
		player.audio.Stop ();
		playerScript.currentPlanet.transform.GetComponent<PlanetPopulation>().audio2.Stop ();
		playerScript.currentPlanet.transform.FindChild ("ClearPulse").audio.Stop ();
		audio.Play ();

		if(isFinalBeam){
			gameObject.renderer.material.SetColor("_TintColor", Color.red);
		}

		// beaming
		for(float counter = 0f; counter < 2f; counter += Time.deltaTime){
			player.position += new Vector3(0f, 1f, 0f) * Time.deltaTime * 50f;
			yield return null;
		}

		if(isEndBeam){
			// ending sequence --- fly back to earth
			playerScript.HUDOff();
			StartCoroutine(Ending());
		} else if(isFinalBeam){
			// teleport and freeze player
			playerScript.currentPlanet.transform.GetComponent<PlanetPopulation>().HideBeam();

			GameObject finalPlanet = GameObject.Find("FinalPlanet");
			player.position = finalPlanet.transform.position + new Vector3(0f,-finalPlanet.GetComponent<FinalStageScript>().orbitLength,0.9f);
			playerScript.enabled = true;
			playerScript.currentPlanet = finalPlanet;
			playerScript.OrbitSetup();
			playerScript.isFinalStage = true;
			playerScript.DisplayTextInstant("WARNING!\n\nENEMY SHIPS INCOMING!!!", 2f);
			finalPlanet.GetComponent<FinalStageScript>().StageStart();
			liftOff = false;
			inSpace = false;
			audio.Stop();
		} else{
			GalaxyPopulation galaxy = playerScript.Galaxy;
			PlanetPopulation currentPlanet = playerScript.currentPlanet.transform.GetComponent<PlanetPopulation>();
			surroundingPlanets = galaxy.GetSurroundingPlanets(currentPlanet);
			lookingPlanet = 0;
			inSpace = true;
		}
	}

	IEnumerator FlyOff(){
		// set flying direction
		Vector3 flyTarget = surroundingPlanets[lookingPlanet].transform.position;
		audio.PlayOneShot (takeoff);
		// detach ship body from camera
		Transform ship = player.transform.FindChild("Ship");
		Vector3 shipLocalPos = ship.localPosition;
		Quaternion shipLocalRot = ship.localRotation;
		ship.parent = null;
		for(float t = 0f; t < 1.5f; t += Time.deltaTime){
			ship.position = Vector3.Lerp(ship.position, flyTarget, Time.deltaTime * 0.2f);
			ship.rotation = Quaternion.Lerp(ship.rotation, Quaternion.LookRotation(flyTarget-ship.position), Time.deltaTime * 5f);
			yield return null;
		}
		// populate next planet
		PlanetPopulation targetPlanet = surroundingPlanets[lookingPlanet].transform.GetComponent<PlanetPopulation>();
		targetPlanet.PopulatePlanet();

		// move player over and re-attach ship body
		player.position = surroundingPlanets[lookingPlanet].transform.position + new Vector3(0f,200f,0f);
		ship.parent = player;
		ship.localPosition = shipLocalPos;
		ship.localRotation = shipLocalRot;

		// enable player movement
		playerScript.enabled = true;
		playerScript.currentPlanet.transform.GetComponent<PlanetPopulation>().HideBeam();
		playerScript.currentPlanet = surroundingPlanets[lookingPlanet];
		playerScript.OrbitSetup();
		playerScript.ActivateShield(2f);

		
		if(targetPlanet.planetType == 3){
			playerScript.DisplayTextInstant("INCOMING TRANSMISSION:\n\n", 5f);
			playerScript.DisplayAdditionalText("\"HELP US!\"",2f);
		}
	}

	IEnumerator Ending(){
		// get target positions
		Transform startPlanet = playerScript.Galaxy.startingPlanet.transform;
		float startPlanetSurfaceDist = startPlanet.GetComponent<PlanetPopulation>().surfaceLength;
		Vector3 startPos = player.position;
		Vector3 flyTarget = startPlanet.transform.position + new Vector3(0f, startPlanetSurfaceDist * 2f, -7f);
		Vector3 landTarget = startPlanet.transform.position + new Vector3(0f, startPlanetSurfaceDist, -7f);

		// get target rotation
		Vector3 lookDirection = flyTarget - startPos;
		Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
		targetRotation *= Quaternion.Inverse(player.FindChild("Camera").localRotation);

		// show beacon on starting planet
		startPlanet.GetComponent<PlanetPopulation>().ShowBeam();

		// turn first
		for(float t = 0f; t < 2f; t += Time.deltaTime){
			player.rotation = Quaternion.Lerp(player.rotation, targetRotation, Time.deltaTime * 6f);
			yield return null;
		}

		// start on the way home
		float timeElapsed = 0f;
		playerScript.DisplayText("SUPER MASSIVE BLACKHOLE\n\nA GAME BY\n\nBEN WALTHALL\nJAMES ZHANG\nZHAN HUANG", 6f);
		for(float t = 0f; t < 10f; t += Time.deltaTime){
			timeElapsed += Time.deltaTime;
			player.position = startPos + lookDirection * timeElapsed / 50f;
			yield return null;
		}
		playerScript.DisplayText("PROGRAMMER\n\n\nZHAN HUANG", 5f);
		for(float t = 0f; t < 10f; t += Time.deltaTime){
			timeElapsed += Time.deltaTime;
			player.position = startPos + lookDirection * timeElapsed / 50f;
			yield return null;
		}
		playerScript.DisplayText("MODELING\n\n\nJAMES ZHANG", 5f);
		for(float t = 0f; t < 10f; t += Time.deltaTime){
			timeElapsed += Time.deltaTime;
			player.position = startPos + lookDirection * timeElapsed / 50f;
			yield return null;
		}
		playerScript.DisplayText("SOUNDS\n\n\nBEN WALTHALL", 5f);
		for(float t = 0f; t < 10f; t += Time.deltaTime){
			timeElapsed += Time.deltaTime;
			player.position = startPos + lookDirection * timeElapsed / 50f;
			yield return null;
		}
		playerScript.DisplayText("SPECIAL THANKS TO:\n\n\nDuael Designs\nIconian Fonts", 5f);
		for(float t = 0f; t < 10f; t += Time.deltaTime){
			// fly slow on the home stretch
			timeElapsed += Time.deltaTime/1.5f;
			player.position = startPos + lookDirection * timeElapsed / 50f;
			yield return null;
		}
		for(float t = 0f; t < 15f; t += Time.deltaTime){
			player.position = Vector3.Lerp(player.position, landTarget, Time.deltaTime * 0.4f);
			yield return null;
		}
		playerScript.EngineOff();
		playerScript.DisplayText("THANK YOU FOR PLAYING!!!", 500f);
	}

	public void EnableShop(){
		// load font
		GUIFont = (Font)Resources.Load("AirStrike");

		shopEnabled = true;

		/* TODO: upgrades for the following
		 * Health
		 * Heat
		 * 
		 */

		items[0] = "Laser";
		items[1] = "Bomb";
		items[2] = "Shield";
		items[3] = "Death Ray";
		items[4] = "Mine";
		items[5] = "EMP";

		for(int i = 0; i < 6; i ++){
			prices[i] = 20;
		}

		// populate shop item text
		for(int i = 0; i < 7; i ++){
			GameObject itemTextObj = new GameObject("HUD_itemText");
			itemTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
			GUIText nextItemText = (GUIText)itemTextObj.AddComponent(typeof(GUIText));
			nextItemText.anchor = TextAnchor.MiddleLeft;
			nextItemText.fontSize = 24;
			nextItemText.font = GUIFont;
			nextItemText.color = Color.black;
			if(i < 6){
				nextItemText.pixelOffset = new Vector2(-160f, 90f - (i * 30f));
				nextItemText.text = items[i];
			} else{
				nextItemText.anchor = TextAnchor.MiddleCenter;
				nextItemText.pixelOffset = new Vector2(0f, - Screen.height/2 + 30f);
				nextItemText.text = "[J]: Purchase \n[P]: Close Shop";
			}
			nextItemText.enabled = false;
			itemTexts[i] = nextItemText;
		}

		for(int i = 0; i < 6; i ++){
			GameObject priceTextObj = new GameObject("HUD_priceText");
			priceTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
			GUIText nextPriceText = (GUIText)priceTextObj.AddComponent(typeof(GUIText));
			nextPriceText.anchor = TextAnchor.MiddleRight;
			nextPriceText.fontSize = 24;
			nextPriceText.font = GUIFont;
			nextPriceText.color = Color.black;
			nextPriceText.pixelOffset = new Vector2(160f, 90f - (i * 30f));
			nextPriceText.text = "20";
			nextPriceText.enabled = false;
			priceTexts[i] = nextPriceText;
		}

		HighLight(0);
	}

	void OpenUpShop(){
		playerScript.enabled = false;
		player.rigidbody.velocity = Vector3.zero;
		player.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
		beamText.enabled = false;

		// update items
		for(int i = 0; i < 6; i ++){
			UpdateItem(i);
		}
		
		foreach(GUIText text in itemTexts){
			text.enabled = true;
		}
		foreach(GUIText text in priceTexts){
			text.enabled = true;
		}
	}
	
	void CloseDownShop(){
		playerScript.enabled = true;
		foreach(GUIText text in itemTexts){
			text.enabled = false;
		}
		foreach(GUIText text in priceTexts){
			text.enabled = false;
		}
		beamText.enabled = true;

		RemoveHighLight(selectedIndex);
		selectedIndex = 0;
		HighLight(selectedIndex);
	}
	
	void UpdateItem(int index){
		if(index == 2 || index == 4){
			// shield and mine charges don't ramp up in price
			prices[index] = 20;
			itemTexts[index].text = items[index];
		} else{
			// weapons ramp up according to current level
			int level = playerScript.GetItemLevel(items[index]);
			prices[index] = level * level * 10 + 20;
			itemTexts[index].text = items[index] + "(lv" + (playerScript.GetItemLevel(items[index]) + 1) + ")";
		}
		priceTexts[index].text = prices[index].ToString();
		if(playerScript.ItemMaxed(items[index])){
			// returning true means the item is maxed out
			itemTexts[index].text = "Sold Out";
			itemTexts[index].color = Color.red;
			priceTexts[index].text = "";
		}
	}

	void HighLight(int index){
		itemTexts[index].fontSize = 28;
		priceTexts[index].fontSize = 28;
		if(itemTexts[selectedIndex].text != "Sold Out"){
			itemTexts[index].color = Color.green;
			priceTexts[index].color = Color.green;
		}
	}

	void RemoveHighLight(int index){
		itemTexts[index].fontSize = 24;
		priceTexts[index].fontSize = 24;
		if(itemTexts[selectedIndex].text != "Sold Out"){
			itemTexts[index].color = Color.black;
			priceTexts[index].color = Color.black;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			if(shopEnabled){
				beamText.text = "[Space]: Engage Planar Drive\n    [P]     : Open Shop";
			}
			beamText.enabled = true;
			player = other.transform;
			playerScript = player.GetComponent<PlayerShipController>();
		}
	}
	
	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			beamText.enabled = false;
		}
	}
}

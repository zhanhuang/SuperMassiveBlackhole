using UnityEngine;
using System.Collections;

public class BaseBeamBehavior : MonoBehaviour {
	public bool shopEnabled = false;

	public Transform player;
	public PlayerShipController playerScript;

	/* States:
	 * Inactive
	 * Ground
	 * Space
	 * Shop
	 * Transition
	 */
	public string BeamState = "Inactive";

	GameObject[] surroundingPlanets = new GameObject[8];
	int lookingPlanet = 0;
	
	// shop
	string[] items = new string[6];
	int[] prices = new int[6];
	GUIOutlinedText[] itemTexts = new GUIOutlinedText[6];
	GUIOutlinedText[] priceTexts = new GUIOutlinedText[6];
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
	
	public GUIOutlinedText beamText;

	// Use this for initialization
	void Start () {
		
		// load font
		GUIFont = (Font)Resources.Load("AirStrike");

		beamText = new GUIOutlinedText("HUD_beamText");
		beamText.fontSize = 24;
		beamText.font = GUIFont;
		beamText.color = Color.yellow;
		beamText.alignment = TextAlignment.Center;
		beamText.anchor = TextAnchor.MiddleCenter;
		beamText.text = "[Space]:\nEngage Planar Drive";
		beamText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (BeamState == "Transition" || BeamState == "Inactive"){
			return;
		}
		
		if (BeamState == "Ground"){
			if(Input.GetKeyDown(KeyCode.Space)){
				BeamStateTransition("Transition");
				StartCoroutine(BeamMeUp());
			} else if(Input.GetKeyDown(KeyCode.P) && shopEnabled == true){
				BeamStateTransition("Shop");
			}
		} else if (BeamState == "Space"){
			// adjust rotation so camera faces target planet
			Vector3 lookDirection = surroundingPlanets[lookingPlanet].transform.position - player.position;
			Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
			targetRotation *= Quaternion.Inverse(player.Find("Camera").localRotation);
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
				BeamStateTransition("Transition");
				// set rotation on moving
				player.rotation = targetRotation;
				StartCoroutine(FlyOff());
			} else if (Input.GetKeyDown(KeyCode.S)){
				BeamStateTransition("Transition");
				StartCoroutine(BeamMeDown());
			}
		} else if (BeamState == "Shop"){
			if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)){
				BeamStateTransition("Ground");
			} else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
				GetComponent<AudioSource>().PlayOneShot (storeScroll);
				RemoveHighLight(selectedIndex);

				selectedIndex --;
				if(selectedIndex < 0){
					selectedIndex = 5;
				}

				HighLight(selectedIndex);
			} else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
				GetComponent<AudioSource>().PlayOneShot (storeScroll);
				RemoveHighLight(selectedIndex);

				selectedIndex ++;
				if(selectedIndex > 5){
					selectedIndex = 0;
				}
				
				HighLight(selectedIndex);
			} else if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.J)){
				// purchased an item
				if(playerScript.currency >= prices[selectedIndex] && itemTexts[selectedIndex].text != "Sold Out"){
					GetComponent<AudioSource>().PlayOneShot (storeBuy);
					playerScript.PurchaseItem(items[selectedIndex], prices[selectedIndex]);
					UpdateItem(selectedIndex);
				}
				else{
					GetComponent<AudioSource>().PlayOneShot (storeCantBuy);
				}
			}
		}
	}

	IEnumerator BeamMeDown(){
		player.rotation = Quaternion.identity;

		// disconnect and freeze player
		Destroy(player.GetComponent<ConfigurableJoint>());
		LockPlayer();
		
		// beaming
		for(float counter = 0f; counter < 2f; counter += Time.deltaTime){
			player.position -= new Vector3(0f, 1f, 0f) * Time.deltaTime * 50f;
			yield return null;
		}

		BeamStateTransition("Ground");
	}

	IEnumerator BeamMeUp(){
		// disconnect and freeze player
		Destroy(player.GetComponent<ConfigurableJoint>());
		LockPlayer();

		// play beam audio
		player.GetComponent<AudioSource>().Stop ();
		playerScript.currentPlanet.transform.GetComponent<PlanetPopulation>().audio2.Stop ();
		playerScript.currentPlanet.transform.Find ("ClearPulse").GetComponent<AudioSource>().Stop ();
		GetComponent<AudioSource>().Play ();

		if(isFinalBeam){
			gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", Color.red);
		}

		// beaming
		for(float counter = 0f; counter < 2f; counter += Time.deltaTime){
			player.position += new Vector3(0f, 1f, 0f) * Time.deltaTime * 50f;
			yield return null;
		}

		// check for special cases
		if(isEndBeam){
			BeamStateTransition("Inactive");
			playerScript.currentPlanet.transform.GetComponent<PlanetPopulation>().audio2.PlayDelayed(8f);
			
			// ending sequence --- fly back to earth
			playerScript.HUDOff();
			StartCoroutine(Ending());
		} else if(isFinalBeam){
			BeamStateTransition("Inactive");
			
			// teleport player to boss level
			GameObject finalPlanet = GameObject.Find("FinalPlanet");
			finalPlanet.GetComponent<FinalStageScript>().PlayerScript = playerScript;
			player.position = finalPlanet.transform.position + new Vector3(0f,-finalPlanet.GetComponent<FinalStageScript>().orbitLength,0.9f);
			playerScript.enabled = true;
			playerScript.currentPlanet = finalPlanet;
			playerScript.OrbitSetup();
			playerScript.isFinalStage = true;
			playerScript.DisplayText("WARNING!\n\nENEMY SHIPS INCOMING!!!", 2f);
			finalPlanet.GetComponent<FinalStageScript>().StageStart();
		} else{
			BeamStateTransition("Space");
		}
	}

	IEnumerator FlyOff(){
		playerScript.Galaxy.HidePaths();
		// set flying direction
		Transform targetPlanetTransform = surroundingPlanets[lookingPlanet].transform;
		PlanetPopulation targetPlanetScript = surroundingPlanets[lookingPlanet].transform.GetComponent<PlanetPopulation>();


		if(targetPlanetScript.beamActivated == false || targetPlanetScript.planetType == -2 || targetPlanetScript.planetType == 2){
			// ANIMATION for enemy/conflicting planet
			Vector3 flyTarget = targetPlanetTransform.position;
			GetComponent<AudioSource>().PlayOneShot (takeoff);
			// detach ship body from camera
			Transform ship = player.transform.Find("Ship");
			Vector3 shipLocalPos = ship.localPosition;
			Quaternion shipLocalRot = ship.localRotation;
			ship.parent = null;
			for(float t = 0f; t < 1.5f; t += Time.deltaTime){
				ship.position = Vector3.Lerp(ship.position, flyTarget, Time.deltaTime * 0.2f);
				ship.rotation = Quaternion.Lerp(ship.rotation, Quaternion.LookRotation(flyTarget-ship.position), Time.deltaTime * 5f);
				yield return null;
			}
			targetPlanetScript.PopulatePlanet();

			// move player over and re-attach ship body
			player.position = flyTarget + new Vector3(0f,200f,0f);
			ship.parent = player;
			ship.localPosition = shipLocalPos;
			ship.localRotation = shipLocalRot;
			
			// hide beam on this planet
			BeamStateTransition("Inactive");
			
			// set player to next planet
			playerScript.currentPlanet = surroundingPlanets[lookingPlanet];
			
			// enable player movement
			UnlockPlayer();
			playerScript.ActivateShield(2f);

			if(targetPlanetScript.planetType == 3){
				playerScript.DisplayTextInstant("INCOMING TRANSMISSION:\n\n", 5f);
				playerScript.DisplayAdditionalText("\"HELP US!\"",2f);
			}
		} else{
			// cleared planet, fly to hover above it
			BaseBeamBehavior targetBeam = targetPlanetScript.BaseBeam.GetComponent<BaseBeamBehavior>();
			targetBeam.player = player;
			targetBeam.playerScript = playerScript;

			Vector3 flyTarget = targetPlanetTransform.position + new Vector3(0f, targetPlanetScript.orbitLength + 100f, 0f);
			for(float t = 0f; t < 0.8f; t += Time.deltaTime){
				player.position = Vector3.Lerp(player.position, flyTarget, Time.deltaTime * (6f + t * 3f));
				yield return null;
			}
			
			// hide beam on this planet
			BeamStateTransition("Inactive");

			playerScript.currentPlanet = surroundingPlanets[lookingPlanet];
			targetPlanetScript.ShowBeam();
			targetBeam.BeamStateTransition("Space");
		}
	}


	void OnTriggerEnter(Collider other){
		if(other.tag == "Player" && BeamState == "Inactive"){
			player = other.transform;
			playerScript = player.GetComponent<PlayerShipController>();
			BeamState = "Ground";
			BeamTextUpdate();
		}
	}
	
	void OnTriggerExit(Collider other){
		if(other.tag == "Player" && BeamState == "Ground"){
			BeamState = "Inactive";
			BeamTextUpdate();
		}
	}

	public void BeamStateTransition(string toState){
		// change player state accordingly
		if(BeamState == "Ground"){
			LockPlayer();
		} else if (toState == "Ground"){
			UnlockPlayer();
		}

		// sound
		if(toState == "Space"){
			GetComponent<AudioSource>().Play();
		}else if(toState == "Shop"){
			player.GetComponent<AudioSource>().Stop ();
			playerScript.currentPlanet.transform.GetComponent<PlanetPopulation>().audio2.Stop ();
			playerScript.currentPlanet.transform.Find ("ClearPulse").GetComponent<AudioSource>().Stop ();
			audio2.Play ();
		} else if (toState == "Ground"){
			GetComponent<AudioSource>().Stop();
			audio2.Stop ();
			if(playerScript.currentPlanet.GetComponent<PlanetPopulation>().planetType == -1){
				player.GetComponent<AudioSource>().Play ();
				playerScript.currentPlanet.transform.Find ("ClearPulse").GetComponent<AudioSource>().Play ();}
			else{
				playerScript.currentPlanet.transform.GetComponent<PlanetPopulation>().audio2.Play ();
				playerScript.currentPlanet.transform.Find ("ClearPulse").GetComponent<AudioSource>().Play ();
			}
		} else{
			GetComponent<AudioSource>().Stop();
		}

		// shop
		if(toState == "Shop"){
			OpenUpShop();
		} else if (BeamState == "Shop"){
			CloseDownShop();
		}

		if(toState == "Inactive"){
			playerScript.currentPlanet.transform.GetComponent<PlanetPopulation>().HideBeam();
		} else if(toState == "Space"){
			GalaxyPopulation galaxy = playerScript.Galaxy;
			PlanetPopulation currentPlanet = playerScript.currentPlanet.transform.GetComponent<PlanetPopulation>();
			surroundingPlanets = galaxy.GetSurroundingPlanets(currentPlanet);
			galaxy.ShowPathsForPlanet(currentPlanet);
			foreach(GameObject planet in surroundingPlanets){
				if(planet != null){
					galaxy.ShowPathsForPlanet(planet.GetComponent<PlanetPopulation>());
				}
			}
			lookingPlanet = 0;
		}
		
		// set state
		BeamState = toState;
		BeamTextUpdate();
	}

	void BeamTextUpdate(){
		// change text display
		beamText.enabled = true;
		if(BeamState == "Ground"){
			beamText.pixelOffset = Vector2.zero;
			if(shopEnabled){
				beamText.color = new Color(29f/255f, 1f, 242f/255f);
				beamText.text = "[Space]\nEngage Planar Drive\n\n[P]\nOpen Shop";
			} else{
				beamText.color = Color.yellow;
				beamText.text = "[Space]\nEngage Planar Drive";
			}
		} else if(BeamState == "Space"){
			beamText.color = new Color(190f/255f, 230f/255f, 230f/255f);
			beamText.pixelOffset = new Vector2(0f, -Screen.height/2 + 60f);
			beamText.text = "[Space]: Onward!\n    [S]     : Drop Down";
		} else if(BeamState == "Shop"){
			beamText.color = new Color(29f/255f, 1f, 242f/255f);
			beamText.pixelOffset = new Vector2(0f, - Screen.height/2 + 30f);
			beamText.text = "[J]: Purchase \n[P]: Close Shop";
		} else{
			beamText.enabled = false;
		}
	}
	
	void LockPlayer(){
		playerScript.DeactivateAllWeapons();
		playerScript.enabled = false;
		player.GetComponent<Rigidbody>().velocity = Vector3.zero;
		player.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
		playerScript.shipTransform.localRotation = Quaternion.identity;
	}
	
	void UnlockPlayer(){
		playerScript.enabled = true;
		if(player.GetComponent<ConfigurableJoint>() == null){
			playerScript.OrbitSetup();
		}
	}


	/* ***************************************************
	 *                       SHOP
	 * ***************************************************
	*/


	
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
		for(int i = 0; i < 6; i ++){
			GUIOutlinedText nextItemText = new GUIOutlinedText("HUD_itemText");
			nextItemText.anchor = TextAnchor.MiddleLeft;
			nextItemText.fontSize = 24;
			nextItemText.font = GUIFont;
			nextItemText.color = Color.white;
			nextItemText.pixelOffset = new Vector2(-160f, 90f - (i * 30f));
			nextItemText.text = items[i];
			nextItemText.enabled = false;
			itemTexts[i] = nextItemText;
		}
		
		for(int i = 0; i < 6; i ++){
			GUIOutlinedText nextPriceText = new GUIOutlinedText("HUD_priceText");
			nextPriceText.anchor = TextAnchor.MiddleRight;
			nextPriceText.fontSize = 24;
			nextPriceText.font = GUIFont;
			nextPriceText.color = Color.white;
			nextPriceText.pixelOffset = new Vector2(160f, 90f - (i * 30f));
			nextPriceText.text = "20";
			nextPriceText.enabled = false;
			priceTexts[i] = nextPriceText;
		}
		
		HighLight(0);
	}
	
	void OpenUpShop(){
		// update items
		for(int i = 0; i < 6; i ++){
			UpdateItem(i);
		}
		
		foreach(GUIOutlinedText text in itemTexts){
			text.enabled = true;
		}
		foreach(GUIOutlinedText text in priceTexts){
			text.enabled = true;
		}
	}
	
	void CloseDownShop(){
		foreach(GUIOutlinedText text in itemTexts){
			text.enabled = false;
		}
		foreach(GUIOutlinedText text in priceTexts){
			text.enabled = false;
		}
		RemoveHighLight(selectedIndex);
		selectedIndex = 0;
		HighLight(selectedIndex);
	}
	
	void UpdateItem(int index){
		// prices
		int level = 0;
		switch(index){
		case 0:
			// laser - ramp up according to current level
			level = playerScript.GetItemLevel(items[index]);
			prices[index] = level * level * 10 + 10;
			itemTexts[index].text = items[index] + "(lv" + (playerScript.GetItemLevel(items[index]) + 1) + ")";
			break;
		case 1:
			// bomb - ramp up according to current level
			level = playerScript.GetItemLevel(items[index]);
			prices[index] = level * level * 15 + 20;
			itemTexts[index].text = items[index] + "(lv" + (playerScript.GetItemLevel(items[index]) + 1) + ")";
			break;
		case 2:
			// shield charges - don't ramp up in price
			prices[index] = 25;
			itemTexts[index].text = items[index];
			break;
		case 3:
			// death ray - ramp up according to current level
			level = playerScript.GetItemLevel(items[index]);
			if(level == 0){
				prices[index] = 25;
			} else{
				prices[index] = level * level * 10 + 20;
				itemTexts[index].text = items[index] + "(lv" + (playerScript.GetItemLevel(items[index]) + 1) + ")";
			}
			break;
		case 4:
			// mine charges - don't ramp up in price
			prices[index] = 10;
			itemTexts[index].text = items[index];
			break;
		case 5:
			// EMP - ramp up according to current level
			level = playerScript.GetItemLevel(items[index]);
			if(level == 0){
				prices[index] = 35;
			} else{
				prices[index] = level * level * 15 + 30;
				itemTexts[index].text = items[index] + "(lv" + (playerScript.GetItemLevel(items[index]) + 1) + ")";
			}
			break;
		}

		priceTexts[index].text = prices[index].ToString();

		if(playerScript.ItemMaxed(items[index])){
			// returning true means the item is maxed out
			itemTexts[index].text = "Sold Out";
			itemTexts[index].color = Color.red;
			priceTexts[index].text = "";
		} else if(index != selectedIndex){
			itemTexts[index].color = beamText.color;
			priceTexts[index].color = beamText.color;
		} else{
			itemTexts[index].color = Color.green;
			priceTexts[index].color = Color.green;
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
			itemTexts[index].color = beamText.color;
			priceTexts[index].color = beamText.color;
		}
	}

	
	/* ***************************************************
	 *                      ENDING
	 * ***************************************************
	*/
	
	
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
		targetRotation *= Quaternion.Inverse(player.Find("Camera").localRotation);
		
		// show beacon on starting planet
		startPlanet.GetComponent<PlanetPopulation>().ShowBeam();
		
		// turn first
		for(float t = 0f; t < 1f; t += Time.deltaTime){
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
		playerScript.DisplayText("3D MODEL ARTIST\n\n\nJAMES ZHANG", 5f);
		for(float t = 0f; t < 10f; t += Time.deltaTime){
			timeElapsed += Time.deltaTime;
			player.position = startPos + lookDirection * timeElapsed / 50f;
			yield return null;
		}
		playerScript.DisplayText("SOUND DESIGNER\n\n\nBEN WALTHALL", 5f);
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
}

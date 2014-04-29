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

	// Use this for initialization
	void Start () {
		GameObject beamTextObj = new GameObject("HUD_beamText");
		beamTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
		beamText = (GUIText)beamTextObj.AddComponent(typeof(GUIText));
		beamText.fontSize = 24;
		beamText.anchor = TextAnchor.MiddleCenter;
		beamText.color = Color.black;
		beamText.text = "Press [Space] To Engage Planar Drive";
		beamText.enabled = false;

		surroundingPlanets = new GameObject[8];
	}
	
	// Update is called once per frame
	void Update () {
		if (shopping){
			if(Input.GetKeyDown(KeyCode.P)){
				shopping = false;
				CloseDownShop();
			} else if(Input.GetKeyDown(KeyCode.W)){
				RemoveHighLight(selectedIndex);

				selectedIndex --;
				if(selectedIndex < 0){
					selectedIndex = 5;
				}

				HighLight(selectedIndex);
			} else if(Input.GetKeyDown(KeyCode.S)){
				RemoveHighLight(selectedIndex);

				selectedIndex ++;
				if(selectedIndex > 5){
					selectedIndex = 0;
				}
				
				HighLight(selectedIndex);
			} else if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.J)){
				// purchased an item
				if(playerScript.currency >= prices[selectedIndex] && itemTexts[selectedIndex].text != "Sold Out"){
					playerScript.PurchaseItem(items[selectedIndex], prices[selectedIndex]);
					UpdateItem(selectedIndex);
				}
			}
			return;
		}

		if (!liftOff && beamText.enabled){
			if(Input.GetKeyDown(KeyCode.Space)){
				liftOff = true;
				beamText.enabled = false;
				Destroy(player.GetComponent<ConfigurableJoint>());
				playerScript.DisableShield();
				playerScript.enabled = false;
				player.rigidbody.velocity = Vector3.zero;
				player.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
				playerScript.shipTransform.localRotation = Quaternion.identity;
				player.audio.Stop ();
				audio.Play ();
				StartCoroutine(BeamMeUp());
			} else if(Input.GetKeyDown(KeyCode.P)){
				shopping = true;
				OpenUpShop();
			}
		}

		if (inSpace){
			// adjust rotation so camera faces target planet
			Vector3 lookDirection = surroundingPlanets[lookingPlanet].transform.position - player.position;
			Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
			targetRotation *= Quaternion.Inverse(player.GetChild(0).localRotation);
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
				player.position = surroundingPlanets[lookingPlanet].transform.position + new Vector3(0f,200f,0f);
				playerScript.enabled = true;
				playerScript.currentPlanet.transform.GetComponent<PlanetPopulation>().HideBeam();
				playerScript.currentPlanet = surroundingPlanets[lookingPlanet];
				playerScript.OrbitSetup();
				playerScript.ActivateShield(2f);
				surroundingPlanets[lookingPlanet].transform.GetComponent<PlanetPopulation>().PopulatePlanet();
				liftOff = false;
				inSpace = false;
				audio.Stop();
			}
		}
	}

	IEnumerator BeamMeUp(){
		for(float counter = 0f; counter < 2f; counter += Time.deltaTime){
			player.position += new Vector3(0f, 1f, 0f) * Time.deltaTime * 50f;
			yield return null;
		}
		GalaxyPopulation galaxy = playerScript.Galaxy;
		PlanetPopulation currentPlanet = playerScript.currentPlanet.transform.GetComponent<PlanetPopulation>();
		surroundingPlanets = galaxy.GetSurroundingPlanets(currentPlanet);
		lookingPlanet = 0;
		inSpace = true;

	}

	public void EnableShop(){
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
			nextItemText.color = Color.black;
			if(i < 6){
				nextItemText.pixelOffset = new Vector2(-160f, 90f - (i * 30f));
				nextItemText.text = items[i];
			} else{
				nextItemText.pixelOffset = new Vector2(0f, - Screen.height/2 + 30f);
				nextItemText.text = "Press [P] To Close Shop";
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

		selectedIndex = 0;
	}
	
	void UpdateItem(int index){
		int level = playerScript.GetItemLevel(items[index]);
		prices[index] = level * level * 10 + 20;
		if(index == 2 || index == 4){
			itemTexts[index].text = items[index];
		} else{
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
				beamText.text = "Press [Space] To Engage Planar Drive\nPress [P] To Open Shop";
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

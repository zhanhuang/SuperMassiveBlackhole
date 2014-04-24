using UnityEngine;
using System.Collections;

public class BaseBeamBehavior : MonoBehaviour {
	public bool shopEnabled = false;

	Transform player;
	PlayerShipController playerScript;
	public GUIText beamText;

	bool liftOff = false;
	bool inSpace = false;

	GameObject[] surroundingPlanets;
	int lookingPlanet = 0;
	
	// TODO: available weapons in shop


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
		if (!liftOff && Input.GetKeyDown(KeyCode.Space) && beamText.enabled){
			liftOff = true;
			beamText.enabled = false;
			Destroy(player.GetComponent<ConfigurableJoint>());
			playerScript.enabled = false;
			player.rigidbody.velocity = Vector3.zero;
			player.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
			playerScript.shipTransform.localRotation = Quaternion.identity;
			StartCoroutine(BeamMeUp());
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
			} else if (Input.GetKeyDown(KeyCode.Space)){
				player.position = surroundingPlanets[lookingPlanet].transform.position + new Vector3(0f,200f,0f);
				playerScript.enabled = true;
				playerScript.currentPlanet = surroundingPlanets[lookingPlanet];
				playerScript.OrbitSetup();
				playerScript.ActivateShield(3f);
				surroundingPlanets[lookingPlanet].transform.GetComponent<PlanetPopulation>().PopulatePlanet();
				liftOff = false;
				inSpace = false;
			}
		}

//		enabled = false;
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

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			if(shopEnabled){
//				beamText.text = "Press [Space] To Engage Planar Drive\nPress [P] To Open Shop";
				beamText.text = "Press [Space] To Engage Planar Drive\n(Shop Temporarily Closed)";
			}
			beamText.enabled = true;
			player = other.transform;
			playerScript = player.GetComponent<PlayerShipController>();
		}
	}
	
	void OnTriggerExit(Collider other){
		beamText.enabled = false;
	}
}

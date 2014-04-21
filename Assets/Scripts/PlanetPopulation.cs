using UnityEngine;
using System.Collections;

public class PlanetPopulation : MonoBehaviour {
	/* TYPES:
	 * 1 - Hostile: Enemies, clear to move on
	 * 2 - Friendly: Shop, free to move on
	 * 3 - Conflicting: many Enemies and few Allies, clear with at least 1 ally remaining to unlock shop
	 */
	public int planetType;
	// keep track of location in galaxy. later rows have more enemies
	public int planetRow;
	public int planetCol;

	public float orbitLength;
	public float surfaceLength;

	GameObject EnemyShip;
	GameObject EnemyTurret;
	GameObject BasePrefab;

	public Transform BaseBeam;
	bool beamActivated = false;

	public int EnemyCounter = 0;
	public int AllyCounter = 0;
	
	void Awake (){
		float scale = Random.Range(80f,120f);
		transform.localScale = new Vector3(scale, scale, scale);
		orbitLength = transform.localScale.x / 2 + 5f;
		surfaceLength = transform.localScale.x / 2 - 0.02f;
	}
	
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}
	
	// generate base 
	public void GenerateBase(){
		BasePrefab = (GameObject)Resources.Load("Base");
		GameObject Base = (GameObject)Instantiate(BasePrefab, transform.position + new Vector3(0f,1f,0f) * surfaceLength, transform.rotation);
		BaseBeam = Base.transform.FindChild("BaseBeam");
	}

	// Called From GalaxyPopulation
	public void PopulatePlanet(){
		if(planetType == -2){
			// boss planet
		} else if(beamActivated){
			// planet cleared
			return;
		}

		EnemyShip = (GameObject)Resources.Load("Enemy_Ship");
		EnemyTurret = (GameObject)Resources.Load("Enemy_Turret");
		
		// TODO: generate some destructable structures


		// generate enemy ships. Max 20
		for(int i = 0; i < planetRow * 3; i++){
			Vector3 startDir = Random.insideUnitSphere.normalized;
			GameObject nextEnemyShip = (GameObject)Instantiate(EnemyShip, transform.position + startDir * orbitLength, transform.rotation);
			EnemyShipAI enemyOrbit = nextEnemyShip.transform.GetComponent<EnemyShipAI>();
			enemyOrbit.currentPlanet = gameObject;
			EnemyCounter++;
		}
		
		// generate enemy turrets. Max 20
		// TODO: make sure turrets don't overlap
		for(int i = 0; i < planetRow * 3; i++){
			Vector3 startDir = Random.insideUnitSphere.normalized;
			GameObject nextEnemyTurret = (GameObject)Instantiate(EnemyTurret, transform.position + startDir * surfaceLength, transform.rotation);
			EnemyTurretAI enemyTurret = nextEnemyTurret.transform.GetComponent<EnemyTurretAI>();
			enemyTurret.currentPlanet = gameObject;
			nextEnemyTurret.transform.up = nextEnemyTurret.transform.position - transform.position;
			EnemyCounter++;
		}

		if(planetType == 1){
			// hostile planet, no allies
			return;
		}

		// TODO: generate allies
	}

	public void AllyDied(){
		AllyCounter--;
	}

	public void EnemyDied(){
		EnemyCounter--;
		if(EnemyCounter <= 0){
			if(planetType == -2){
				// WIN
				GameObject winTextObj = new GameObject("HUD_winText");
				winTextObj.transform.position = new Vector3(0.5f,0.5f,0f);
				GUIText winText = (GUIText)winTextObj.AddComponent(typeof(GUIText));
				winText.pixelOffset = new Vector2(0f, 100f);
				winText.anchor = TextAnchor.MiddleCenter;
				winText.text = "YOU WIN!!!";
				winText.color = Color.green;
				winText.fontSize = 48;
				winText.enabled = true;
			}
			ActivateBeam();
		}
	}

	public void ActivateBeam(){
		// decide whether there is a shop
		bool shop = false;
		if(planetType == 2 || (planetType == 3 && AllyCounter > 0)){
			shop = true;
		}

		if(!beamActivated){
			// run activation animation only once
			beamActivated = true;
			StartCoroutine(ExpandBeam(shop));
		}
		BaseBeam.GetComponent<BaseBeamBehavior>().shopEnabled = shop;
	}
	
	IEnumerator ExpandBeam(bool shopEnabled) {
		// animate the activation of the beam
		yield return new WaitForSeconds(1f);
		if(planetType == -2){
			// boss planet
			BaseBeam.gameObject.renderer.material.SetColor("_TintColor", Color.red);
			BaseBeam.collider.enabled = false;
		} else if(shopEnabled){
			BaseBeam.gameObject.renderer.material.SetColor("_TintColor", Color.green);
		} else{
			BaseBeam.gameObject.renderer.material.SetColor("_TintColor", Color.yellow);
		}
		for(float counter = 0f; counter < 1f; counter += Time.deltaTime){
			BaseBeam.localPosition = new Vector3(BaseBeam.localPosition.x, BaseBeam.localPosition.y + Time.deltaTime * 200f, BaseBeam.localPosition.z);
			BaseBeam.localScale = new Vector3(BaseBeam.localScale.x, BaseBeam.localScale.y + Time.deltaTime * 400f, BaseBeam.localScale.z);
			yield return null;
		}
		for(float counter = 0f; counter < 2f; counter += Time.deltaTime){
			BaseBeam.localScale = new Vector3(BaseBeam.localScale.x + Time.deltaTime * 20f, BaseBeam.localScale.y, BaseBeam.localScale.z + Time.deltaTime * 20f);
			yield return null;
		}
	}
}

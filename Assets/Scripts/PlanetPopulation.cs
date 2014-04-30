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

	public Transform BaseBeam;
	bool beamActivated = false;

	public int EnemyCounter = 0;
	public int AllyCounter = 0;

	// Prefabs
	GameObject AllyShip;
	GameObject EnemyShip;
	GameObject EnemyShip2;
	GameObject EnemyTurret;
	GameObject BasePrefab;
	GameObject Crater;
	// Loot Prefabs
	GameObject Loot_Currency;
	GameObject Loot_Health;

	public AudioClip victorySound;

	
	void Awake (){
		float scale = Random.Range(80f,120f);
		transform.localScale = new Vector3(scale, scale, scale);
		orbitLength = transform.localScale.x / 2 + 6f;
		surfaceLength = transform.localScale.x / 2 - 0.02f;

		Loot_Currency = (GameObject)Resources.Load("Currency");
		Loot_Health = (GameObject)Resources.Load("Health");
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

//	// test for enemy ship avoiding objects
//	public void avoidTest(){
//		Crater = (GameObject)Resources.Load("Crater");
//		Vector3 startDir = new Vector3(0f,1f,0f);
//		GameObject nextCrater = (GameObject)Instantiate(Crater, transform.position + startDir * surfaceLength, transform.rotation);
//		nextCrater.transform.up = nextCrater.transform.position - transform.position;
//		GenerateLootAt(nextCrater.transform.position,planetRow + 1);
//		
//		EnemyShip = (GameObject)Resources.Load("Enemy_Ship");
//		EnemyShip2 = (GameObject)Resources.Load("Enemy_Ship_2");
//		GameObject nextEnemyShip;
//		if(Random.Range(0,2) == 0){
//			nextEnemyShip = (GameObject)Instantiate(EnemyShip, transform.position + startDir * orbitLength, transform.rotation);
//			nextEnemyShip.transform.GetComponent<EnemyShipAI>().mineEnabled = false;
//		} else{
//			nextEnemyShip = (GameObject)Instantiate(EnemyShip2, transform.position + startDir * orbitLength, transform.rotation);
//			nextEnemyShip.transform.GetComponent<EnemyShipAI>().mineEnabled = true;
//		}
//		EnemyShipAI nextShipScript = nextEnemyShip.transform.GetComponent<EnemyShipAI>();
//		nextShipScript.currentPlanet = gameObject;
//		nextShipScript.level = planetRow;
//		nextShipScript.health = (planetRow + 1)/2;
//		nextShipScript.enemyType = "chase";
//		EnemyCounter++;
//	}

	// Called From GalaxyPopulation
	public void PopulatePlanet(){
		if(planetType == -2){
			HideBeam();
		} else{
			// turn off outline upon entering planet
			transform.FindChild("Outline").renderer.enabled = false;
			if(beamActivated){
				// planet cleared
				ShowBeam();
				return;
			}
		}
		
		// generate destructable structures
		Crater = (GameObject)Resources.Load("Crater");
		for(int i = 0; i < Random.Range(1,3); i++){
			Vector3 startDir = Random.insideUnitSphere.normalized;
			GameObject nextCrater = (GameObject)Instantiate(Crater, transform.position + startDir * surfaceLength, transform.rotation);
			nextCrater.transform.up = nextCrater.transform.position - transform.position;
			GenerateLootAt(nextCrater.transform.position,planetRow + 1);
		}
		
		// generate enemy ships. Max 20 or will lag
		EnemyShip = (GameObject)Resources.Load("Enemy_Ship");
		EnemyShip2 = (GameObject)Resources.Load("Enemy_Ship_2");
		for(int i = 0; i < planetRow * 2 + Random.Range(-1,3); i++){
			Vector3 startDir = Random.insideUnitSphere.normalized;
			GameObject nextEnemyShip;
			if(Random.Range(0,2) == 0){
				nextEnemyShip = (GameObject)Instantiate(EnemyShip, transform.position + startDir * orbitLength, transform.rotation);
				nextEnemyShip.transform.GetComponent<EnemyShipAI>().mineEnabled = false;
			} else{
				nextEnemyShip = (GameObject)Instantiate(EnemyShip2, transform.position + startDir * orbitLength, transform.rotation);
				nextEnemyShip.transform.GetComponent<EnemyShipAI>().mineEnabled = true;
			}
			EnemyShipAI nextShipScript = nextEnemyShip.transform.GetComponent<EnemyShipAI>();
			nextShipScript.currentPlanet = gameObject;
			nextShipScript.level = planetRow;
			nextShipScript.health = 5; //(planetRow + 1)/2;
			if(planetType == 1){
				nextShipScript.enemyType = "chase";
			} else{
				nextShipScript.enemyType = "random";
			}
			EnemyCounter++;
		}
		
		// generate enemy turrets.
		// TODO: make sure turrets don't overlap
		EnemyTurret = (GameObject)Resources.Load("Enemy_Turret");
		for(int i = 0; i < planetRow + Random.Range(-2,2); i++){
			Vector3 startDir = Random.insideUnitSphere.normalized;
			GameObject nextEnemyTurret = (GameObject)Instantiate(EnemyTurret, transform.position + startDir * surfaceLength, transform.rotation);
			EnemyTurretAI nextTurretScript = nextEnemyTurret.transform.GetComponent<EnemyTurretAI>();
			nextTurretScript.currentPlanet = gameObject;
			nextTurretScript.level = planetRow;
			nextTurretScript.health = 1;
			nextEnemyTurret.transform.up = nextEnemyTurret.transform.position - transform.position;
			EnemyCounter++;
		}


		// generate allies for conflicting planets
		if(planetType == 3){
			AllyShip = (GameObject)Resources.Load("Ally_Ship");

			for(int i = 0; i < 2; i++){
				Vector3 startDir = Random.insideUnitSphere.normalized;
				GameObject nextAllyShip = (GameObject)Instantiate(AllyShip, transform.position + startDir * orbitLength, transform.rotation);
				AllyShipAI nextShipScript = nextAllyShip.transform.GetComponent<AllyShipAI>();
				nextShipScript.currentPlanet = gameObject;
				nextShipScript.level = planetRow;
				nextShipScript.health = 3;
				AllyCounter++;
			}
		}

		if (planetType == 1 || planetType == 3) {
						audio.Play ();
				}
	}

	public void AllyDied(){
		AllyCounter--;
	}

	public void EnemyDied(){
		EnemyCounter--;
		if(EnemyCounter <= 0){
			if(planetType == -2){
				// WIN
				BaseBeam.gameObject.renderer.material.SetColor("_TintColor", Color.green);
				transform.FindChild("Outline").renderer.material.SetColor("_Color", Color.green);
				ShowBeam();
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
			audio.Stop ();
			audio.PlayOneShot (victorySound);
			ActivateBeam();
		}
	}

	public void ActivateBeam(){
		if(!beamActivated){
			// run activation animation only once
			beamActivated = true;

			
			// decide whether there is a shop
			if(planetType == -2){
				// boss planet
				BaseBeam.gameObject.renderer.material.SetColor("_TintColor", Color.red);
				BaseBeam.collider.enabled = false;
			} else if(planetType == 2 || (planetType == 3 && AllyCounter > 0) || planetType == -1){
				BaseBeam.GetComponent<BaseBeamBehavior>().EnableShop();
				BaseBeam.gameObject.renderer.material.SetColor("_TintColor", Color.yellow);
				transform.FindChild("Outline").renderer.material.SetColor("_Color", Color.yellow);
			} else{
				BaseBeam.gameObject.renderer.material.SetColor("_TintColor", Color.green);
				transform.FindChild("Outline").renderer.material.SetColor("_Color", Color.green);
			}

			StartCoroutine(ExpandBeam());
		}
	}
	
	IEnumerator ExpandBeam() {
		// animate the activation of the beam
		if(planetType != -2){
			transform.FindChild("ClearPulse").renderer.enabled = true;
		}
		for(float counter = 0f; counter < 1f; counter += Time.deltaTime){
			BaseBeam.localPosition = new Vector3(BaseBeam.localPosition.x, BaseBeam.localPosition.y + Time.deltaTime * 150f, BaseBeam.localPosition.z);
			BaseBeam.localScale = new Vector3(BaseBeam.localScale.x, BaseBeam.localScale.y + Time.deltaTime * 300f, BaseBeam.localScale.z);
			yield return null;
		}
		transform.GetComponentInChildren<Animation>().Play();
		for(float counter = 0f; counter < 2f; counter += Time.deltaTime){
			BaseBeam.localScale = new Vector3(BaseBeam.localScale.x + Time.deltaTime * 20f, BaseBeam.localScale.y, BaseBeam.localScale.z + Time.deltaTime * 20f);
			yield return null;
		}
	}
	
	public void HideBeam(){
		BaseBeam.renderer.enabled = false;
		transform.FindChild("ClearPulse").renderer.enabled = false;
		transform.FindChild("Outline").renderer.enabled = true;
	}

	public void ShowBeam(){
		BaseBeam.renderer.enabled = true;
		transform.FindChild("ClearPulse").renderer.enabled = true;
		transform.FindChild("Outline").renderer.enabled = false;
	}

	public void GenerateLootAt(Vector3 location, int level) {
		// auto corrects for position of objects on planet surface. choose loot based on level
		Vector3 direction = (location - transform.position).normalized;
		float rnd = Random.Range(0f,100f);
		if(rnd < 10f){
			GameObject nextLoot = (GameObject)Instantiate(Loot_Health, transform.position + direction.normalized * orbitLength, Quaternion.identity);
			nextLoot.GetComponent<Loot>().lootType = "Health";
			nextLoot.GetComponent<Loot>().lootValue = 1;
			nextLoot.transform.up = nextLoot.transform.position - transform.position;
		} else if(rnd < 40f){
			GameObject nextLoot = (GameObject)Instantiate(Loot_Currency, transform.position + direction.normalized * orbitLength, Quaternion.identity);
			nextLoot.GetComponent<Loot>().lootType = "Currency";
			nextLoot.GetComponent<Loot>().lootValue = level * 5 + Random.Range(5,15);
			nextLoot.transform.up = nextLoot.transform.position - transform.position;
		}
	}
}

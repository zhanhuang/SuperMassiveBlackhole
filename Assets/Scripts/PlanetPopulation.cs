﻿using UnityEngine;
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
	public bool beamActivated = false;

	public int EnemyCounter = 0;
	public int AllyCounter = 0;
	
	public PlayerShipController PlayerScript;

	// Prefabs
	GameObject AllyShip;
	GameObject EnemyDrone;
	GameObject EnemyShipA;
	GameObject EnemyShipB;
	GameObject EnemyTurret;
	GameObject EnemyTank;
	GameObject BasePrefab;
	GameObject Crater;
	// Loot Prefabs
	GameObject Loot_Currency;
	GameObject Loot_Health;

	public AudioSource audio2;
	public AudioSource audio3;
	public AudioClip victorySound;
	public AudioClip beamAwake;
	public AudioClip winSound;

	
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
		BaseBeam = Base.transform.Find("BaseBeam");
	}

	// Called From GalaxyPopulation
	public void PopulatePlanet(){
		if(planetType == -2){
			HideBeam();
		} else{
			// turn off outline upon entering planet
			transform.Find("Outline").GetComponent<Renderer>().enabled = false;
			if(beamActivated){
				// planet cleared
				ShowBeam();
				return;
			}
		}
		
		// generate destructable structures
		Crater = (GameObject)Resources.Load("Crater");
		for(int i = 0; i < Random.Range(1,3); i++){
			Vector3 startDir = new Vector3(0f, 1f, 0f);
			while(Vector3.Angle(transform.up, startDir) < 30f){
				// make sure crater doesn't appear on the base
				startDir = Random.insideUnitSphere.normalized;
			}
			GameObject nextCrater = (GameObject)Instantiate(Crater, transform.position + startDir * surfaceLength, transform.rotation);
			nextCrater.transform.up = nextCrater.transform.position - transform.position;
			GenerateLootAt(nextCrater.transform.position,planetRow + 1);
		}
		
		// generate enemy ships. Max 20 or will lag
		EnemyDrone = (GameObject)Resources.Load("Enemy_Drone");
		EnemyShipA = (GameObject)Resources.Load("Enemy_Ship_A");
		EnemyShipB = (GameObject)Resources.Load("Enemy_Ship_B");
		for(int i = 0; i < planetRow * 2 + Random.Range(-1,3); i++){
			Vector3 startDir = Random.insideUnitSphere.normalized;
			GameObject nextEnemyShip;
			int shipType = Random.Range(0,6) + planetRow;
			if(shipType < 4){
				nextEnemyShip = (GameObject)Instantiate(EnemyDrone, transform.position + startDir * orbitLength, transform.rotation);
			} else if(shipType < 6){
				nextEnemyShip = (GameObject)Instantiate(EnemyShipA, transform.position + startDir * orbitLength, transform.rotation);
			} else{
				nextEnemyShip = (GameObject)Instantiate(EnemyShipB, transform.position + startDir * orbitLength, transform.rotation);
			}
			EnemyShipAI nextShipScript = nextEnemyShip.transform.GetComponent<EnemyShipAI>();
			nextShipScript.currentPlanet = gameObject;

			if(planetType == 3){
				nextShipScript.enemyType = "random";
			} else{
				nextShipScript.enemyType = "chase";
			}
			EnemyCounter++;
		}
		
		// generate enemy turrets.
		EnemyTurret = (GameObject)Resources.Load("Enemy_Turret");
		EnemyTank = (GameObject)Resources.Load("Enemy_Tank");
		for(int i = 0; i < planetRow + Random.Range(-1,2); i++){
			Vector3 startDir = Random.insideUnitSphere.normalized;
			GameObject nextEnemyTurret;
			int turretType = Random.Range(0,4) + planetRow;
			if(turretType < 4){
				nextEnemyTurret = (GameObject)Instantiate(EnemyTurret, transform.position + startDir * surfaceLength, transform.rotation);
			} else{
				nextEnemyTurret = (GameObject)Instantiate(EnemyTank, transform.position + startDir * surfaceLength, transform.rotation);
			}
			EnemyTurretAI nextTurretScript = nextEnemyTurret.transform.GetComponent<EnemyTurretAI>();
			nextTurretScript.currentPlanet = gameObject;
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
				AllyCounter++;
			}
		}

		if (planetType == 1 || planetType == 3) {
			GetComponent<AudioSource>().Play ();
		} 
		else if (planetType == -2) {
			audio3.Play ();
		}

		if(EnemyCounter > 0){
			PlayerScript.UpdateEnemyCounter(EnemyCounter);
			PlayerScript.UpdateAllyCounter(AllyCounter);
		}
	}
	
	public void AllyDied(){
		AllyCounter--;
		PlayerScript.UpdateAllyCounter(AllyCounter);
	}

	public virtual void EnemyDied(){
		EnemyCounter--;
		if(EnemyCounter <= 0){
			GetComponent<AudioSource>().Stop ();
			GetComponent<AudioSource>().PlayOneShot (victorySound);
			audio2.PlayDelayed (5f);
			ActivateBeam();
			if(planetType == -2){
				BaseBeam.gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(0f, 1f, 0f, 0.25f));
				audio3.Stop ();
				ShowBeam();
			}
		}
		PlayerScript.UpdateEnemyCounter(EnemyCounter);
	}

	public void ActivateBeam(){
		if(!beamActivated){
			// run activation animation only once
			beamActivated = true;
			BaseBeam.GetComponent<AudioSource>().PlayOneShot (beamAwake);
			
			// decide whether there is a shop
			if(planetType == -2){
				// boss planet
				transform.Find("ClearPulse").GetComponent<Renderer>().enabled = false;
				BaseBeam.parent.transform.Find("Sparkles").gameObject.SetActive(false);
				BaseBeam.gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(1f, 0f, 0f, 0.25f));
				BaseBeam.GetComponent<Collider>().enabled = true;
				BaseBeam.GetComponent<BaseBeamBehavior>().isFinalBeam = true;
				BaseBeam.GetComponent<BaseBeamBehavior>().EnableShop ();
			} else if(planetType == 2 || (planetType == 3 && AllyCounter > 0)){
				BaseBeam.GetComponent<BaseBeamBehavior>().EnableShop();
				BaseBeam.gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(1f, 1f, 0f, 0.25f));
				transform.Find("Outline").GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
			} else if(planetType == 0){
				// final stage planet
				BaseBeam.gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(0f, 1f, 0f, 0.25f));
			} else{
				BaseBeam.gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(0f, 1f, 0f, 0.25f));
				transform.Find("Outline").GetComponent<Renderer>().material.SetColor("_Color", Color.green);
			}
			
//			// test code: port straight to boss fight. comment out in production
//			if(planetType == -1){
//				BaseBeam.GetComponent<BaseBeamBehavior>().isFinalBeam = true;
//			}

//			// test code: start with shop. comment out in production
//			if(planetType == -1){
//				BaseBeam.GetComponent<BaseBeamBehavior>().EnableShop();
//				BaseBeam.gameObject.renderer.material.SetColor("_TintColor", Color.yellow);
//				transform.FindChild("Outline").renderer.material.SetColor("_Color", Color.yellow);
//			}
			
			StartCoroutine(ExpandBeam());
		}
	}
	
	IEnumerator ExpandBeam() {
		// animate the activation of the beam
		if(planetType != -2){
			transform.Find("ClearPulse").GetComponent<Renderer>().enabled = true;
			BaseBeam.parent.transform.Find("Sparkles").gameObject.SetActive(true);
			transform.Find ("ClearPulse").GetComponent<AudioSource>().Play ();
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
		BaseBeam.GetComponent<Renderer>().enabled = false;
		BaseBeam.GetComponent<Collider>().enabled = false;
		transform.Find("ClearPulse").GetComponent<Renderer>().enabled = false;
		BaseBeam.parent.transform.Find("Sparkles").gameObject.SetActive(false);
		transform.Find ("Outline").GetComponent<Renderer>().enabled = true;
	}

	public void ShowBeam(){
		BaseBeam.GetComponent<Renderer>().enabled = true;
		BaseBeam.GetComponent<Collider>().enabled = true;
		transform.Find("ClearPulse").GetComponent<Renderer>().enabled = true;
		BaseBeam.parent.transform.Find("Sparkles").gameObject.SetActive(true);
		transform.Find("Outline").GetComponent<Renderer>().enabled = false;
	}
	
	public virtual void GenerateLootAt(Vector3 location, int level) {
		// auto corrects for position of objects on planet surface. choose loot based on level
		Vector3 direction = (location - transform.position).normalized;
		float rnd = Random.Range(0f,100f);
		if(rnd < 10f){
			GameObject nextLoot = (GameObject)Instantiate(Loot_Health, transform.position + direction.normalized * orbitLength, Quaternion.identity);
			nextLoot.GetComponent<Loot>().lootType = "Health";
			nextLoot.GetComponent<Loot>().lootValue = 1;
			nextLoot.transform.up = nextLoot.transform.position - transform.position;
		} else if(rnd < 75f){
			GameObject nextLoot = (GameObject)Instantiate(Loot_Currency, transform.position + direction.normalized * orbitLength, Quaternion.identity);
			nextLoot.GetComponent<Loot>().lootType = "Currency";
			nextLoot.GetComponent<Loot>().lootValue = level * 4 + planetRow * 2 + Random.Range(5,12);
			nextLoot.transform.up = nextLoot.transform.position - transform.position;
		}
	}
}

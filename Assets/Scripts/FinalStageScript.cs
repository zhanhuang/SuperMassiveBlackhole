using UnityEngine;
using System.Collections;

public class FinalStageScript : PlanetPopulation {
	public GameObject[] portals = new GameObject[8];
	
	GameObject Portal;

	GameObject FinalEnemyDrone;
	GameObject FinalEnemyShipA;
	GameObject FinalEnemyShipB;
	GameObject FinalEnemyTank;

	GameObject nextEnemy;

	int portalCount = 8;

	void Awake (){
		// override parent script so we don't resize planet
		orbitLength = transform.localScale.x / 2 + 8f;
		surfaceLength = transform.localScale.x / 2 - 0.02f;

		for(int i = 0; i < 8; i++){
			portals[i].GetComponent<PortalScript>().currentPlanet = gameObject;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StageStart(){
		FinalEnemyDrone = (GameObject)Resources.Load("Enemy_Drone");
		FinalEnemyShipA = (GameObject)Resources.Load("Enemy_Ship_A");
		FinalEnemyShipB = (GameObject)Resources.Load("Enemy_Ship_B");
		FinalEnemyTank = (GameObject)Resources.Load("Enemy_Tank");

		StartCoroutine("EnemyWaveStart");
	}

	IEnumerator EnemyWaveStart(){
		// NO TANK in waves since it's impossible to kill now.
		for(int i = 0; i < 5; i++){
			int portalIndex = Random.Range(0,8);
			nextEnemy = CreateEnemy(0,1);
			while(portals[portalIndex] == null || !portals[portalIndex].GetComponent<PortalScript>().PortInEnemy(nextEnemy)){
				portalIndex = Random.Range(0,8);
				yield return null;
			}
			EnemyCounter++;
			yield return new WaitForSeconds(10f);
		}
		yield return new WaitForSeconds(10f);
		for(int i = 0; i < 8; i++){
			int portalIndex = Random.Range(0,8);
			nextEnemy = CreateEnemy(0,2);
			while(portals[portalIndex] == null || !portals[portalIndex].GetComponent<PortalScript>().PortInEnemy(nextEnemy)){
				portalIndex = Random.Range(0,8);
				yield return null;
			}
			EnemyCounter ++;
			yield return new WaitForSeconds(8f);
		}
		yield return new WaitForSeconds(10f);
		for(int i = 0; i < 10; i++){
			int portalIndex = Random.Range(0,8);
			nextEnemy = CreateEnemy(1,2);
			while(portals[portalIndex] == null || !portals[portalIndex].GetComponent<PortalScript>().PortInEnemy(nextEnemy)){
				portalIndex = Random.Range(0,8);
				yield return null;
			}
			EnemyCounter ++;
			yield return new WaitForSeconds(6f);
		}
	}

	public override void EnemyDied(){
		EnemyCounter--;
	}

	public void PortalDestroyed(){
		portalCount--;

		if(portalCount <= 0){
			Debug.Log("portals cleared");
			StopCoroutine("EnemyWaveStart");
			if(nextEnemy != null){
				Destroy(nextEnemy);
				EnemyCounter--;
			}
			StartCoroutine(ChangeBeam());
		}
		
		
//		// Test - kill one portal to win, Comment out for release
//		Debug.Log("portals cleared");
//		StopCoroutine("EnemyWaveStart");
//		if(nextEnemy != null){
//			Destroy(nextEnemy);
//			EnemyCounter--;
//		}
//		StartCoroutine(ChangeBeam());
	}

	IEnumerator ChangeBeam() {
		// change beam color and enable
		BaseBeam.gameObject.renderer.material.SetColor("_TintColor", Color.green);
		for(float counter = 0f; counter < 2f; counter += Time.deltaTime){
			BaseBeam.localPosition = new Vector3(BaseBeam.localPosition.x, BaseBeam.localPosition.y + Time.deltaTime * 50f, BaseBeam.localPosition.z);
			BaseBeam.localScale = new Vector3(BaseBeam.localScale.x + Time.deltaTime * 40f, BaseBeam.localScale.y + Time.deltaTime * 100f, BaseBeam.localScale.z + Time.deltaTime * 40f);
			yield return null;
		}
		BaseBeam.collider.enabled = true;
	}

	GameObject CreateEnemy(int lowType, int highType){
		GameObject nextEnemy = null;
		if(highType > 3){
			highType = 3;
		}
		int type = Random.Range(lowType, highType + 1);
		Vector3 startDir = new Vector3(0f,2f,0f);
		switch(type){
		case 0:
			nextEnemy = (GameObject)Instantiate(FinalEnemyDrone, transform.position + startDir * orbitLength, transform.rotation);
			nextEnemy.transform.GetComponent<EnemyShipAI>().currentPlanet = gameObject;
			nextEnemy.transform.GetComponent<EnemyShipAI>().enemyType = "chase";
			nextEnemy.transform.GetComponent<EnemyShipAI>().enabled = false;
			break;
		case 1:
			nextEnemy = (GameObject)Instantiate(FinalEnemyShipA, transform.position + startDir * orbitLength, transform.rotation);
			nextEnemy.transform.GetComponent<EnemyShipAI>().currentPlanet = gameObject;
			nextEnemy.transform.GetComponent<EnemyShipAI>().enemyType = "chase";
			nextEnemy.transform.GetComponent<EnemyShipAI>().enabled = false;
			break;
		case 2:
			nextEnemy = (GameObject)Instantiate(FinalEnemyShipB, transform.position + startDir * orbitLength, transform.rotation);
			nextEnemy.transform.GetComponent<EnemyShipAI>().currentPlanet = gameObject;
			nextEnemy.transform.GetComponent<EnemyShipAI>().enemyType = "chase";
			nextEnemy.transform.GetComponent<EnemyShipAI>().enabled = false;
			break;
		case 3:
			nextEnemy = (GameObject)Instantiate(FinalEnemyTank, transform.position + startDir * surfaceLength, transform.rotation);
			EnemyTurretAI nextTurretScript = nextEnemy.transform.GetComponent<EnemyTurretAI>();
			nextTurretScript.currentPlanet = gameObject;
			nextTurretScript.enabled = false;
			break;
		}

		return nextEnemy;
	}

	public override void GenerateLootAt(Vector3 location, int level) {
		//don't generate loot
		return;
	}
}

using UnityEngine;
using System.Collections;

public class FinalStageScript : PlanetPopulation {
	public GameObject[] portals = new GameObject[8];
	
	GameObject Portal;

	GameObject FinalEnemyDrone;
	GameObject FinalEnemyShipA;
	GameObject FinalEnemyShipB;
	GameObject FinalEnemyTank;

	void Awake (){
		// override parent script so we don't resize planet
		orbitLength = transform.localScale.x / 2 + 15f;
		surfaceLength = transform.localScale.x / 2;

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

		StartCoroutine(EnemyWaveStart());
	}

	IEnumerator EnemyWaveStart(){
		for(int i = 0; i < 10; i++){
			int portalIndex = Random.Range(0,8);
			while(portals[portalIndex] == null || !portals[portalIndex].GetComponent<PortalScript>().PortInEnemy(CreateEnemy(0,1))){
				portalIndex = Random.Range(0,8);
				yield return null;
			}
			yield return new WaitForSeconds(2f);
		}
		yield return new WaitForSeconds(5f);
	}

	public void EnemyDied(){
		EnemyCounter--;
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
		EnemyCounter++;

		return nextEnemy;
	}
}

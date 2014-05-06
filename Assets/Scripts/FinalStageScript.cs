using UnityEngine;
using System.Collections;

public class FinalStageScript : PlanetPopulation {
	public GameObject[] portals = new GameObject[8];
	public GameObject[] portalPowers = new GameObject[8];
	
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
			portals[i].SetActive(false);
			portals[i].GetComponent<PortalScript>().currentPlanet = gameObject;
		}
		// so they don't interfere with the compass
		for(int i = 0; i < 8; i++){
			portalPowers[i].SetActive(false);
		}
	}

	// Use this for initialization
	void Start () {
		ActivateBeam();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StageStart(){
		FinalEnemyDrone = (GameObject)Resources.Load("Enemy_Drone");
		FinalEnemyShipA = (GameObject)Resources.Load("Enemy_Ship_A");
		FinalEnemyShipB = (GameObject)Resources.Load("Enemy_Ship_B");
		FinalEnemyTank = (GameObject)Resources.Load("Enemy_Tank");
		
		audio3.Play ();

		for(int i = 0; i < 8; i++){
			portals[i].SetActive(true);
			portalPowers[i].SetActive(true);
		}
		
		PlayerScript.UpdateEnemyCounter(EnemyCounter);
		
		StartCoroutine("EnemyWaveStart");
		
//		// Test - win, Comment out for release
//		Win();
	}

	IEnumerator EnemyWaveStart(){
		for(int i = 0; i < 4; i++){
			int portalIndex = Random.Range(0,8);
			nextEnemy = CreateEnemy(0,1);
			while(portals[portalIndex] == null || !portals[portalIndex].GetComponent<PortalScript>().PortInEnemy(nextEnemy)){
				portalIndex = Random.Range(0,8);
				yield return null;
			}
			nextEnemy = null;
			EnemyCounter ++;
			PlayerScript.UpdateEnemyCounter(EnemyCounter);
			yield return new WaitForSeconds(6f);
		}
		while(true){
			if(EnemyCounter < 15){
				int portalIndex = Random.Range(0,8);
				nextEnemy = CreateEnemy(1,3);
				while(portals[portalIndex] == null || !portals[portalIndex].GetComponent<PortalScript>().PortInEnemy(nextEnemy)){
					portalIndex = Random.Range(0,8);
					yield return null;
				}
				nextEnemy = null;
				EnemyCounter ++;
				PlayerScript.UpdateEnemyCounter(EnemyCounter);
			}
			yield return new WaitForSeconds(4f);
		}
	}

	public override void EnemyDied(){
		EnemyCounter--;
		if(portalCount <= 0){
			Win();
		}

		PlayerScript.UpdateEnemyCounter(EnemyCounter);
	}

	public void PortalDestroyed(){
		portalCount--;

		if(portalCount <= 0){
			StopCoroutine("EnemyWaveStart");
			if(nextEnemy != null){
				Destroy(nextEnemy);
			}

			if(EnemyCounter == 0){
				Win();
			}
		}
	}

	void Win(){
		audio3.Stop ();
		audio.Stop ();
		audio.PlayOneShot (victorySound);
		audio2.PlayDelayed (5f);
		// called only when no enemy or portals are left
		transform.FindChild("ClearPulse").renderer.material.SetColor("_TintColor", Color.green);
		StartCoroutine(DisableDome());
	}

	IEnumerator DisableDome(){
		Transform dome = transform.FindChild("Dome");
		Vector3 origScale = dome.transform.localScale;
		for(float t = 0f; t < 1f; t+= Time.deltaTime){
			dome.transform.localScale = (1 - t) * origScale;
			yield return null;
		}
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
			nextEnemy.transform.GetComponent<EnemyShipAI>().chasing = true;
			nextEnemy.transform.GetComponent<EnemyShipAI>().enabled = false;
			break;
		case 1:
			nextEnemy = (GameObject)Instantiate(FinalEnemyShipA, transform.position + startDir * orbitLength, transform.rotation);
			nextEnemy.transform.GetComponent<EnemyShipAI>().currentPlanet = gameObject;
			nextEnemy.transform.GetComponent<EnemyShipAI>().enemyType = "chase";
			nextEnemy.transform.GetComponent<EnemyShipAI>().chasing = true;
			nextEnemy.transform.GetComponent<EnemyShipAI>().enabled = false;
			break;
		case 2:
			nextEnemy = (GameObject)Instantiate(FinalEnemyShipB, transform.position + startDir * orbitLength, transform.rotation);
			nextEnemy.transform.GetComponent<EnemyShipAI>().currentPlanet = gameObject;
			nextEnemy.transform.GetComponent<EnemyShipAI>().enemyType = "chase";
			nextEnemy.transform.GetComponent<EnemyShipAI>().chasing = true;
			nextEnemy.transform.GetComponent<EnemyShipAI>().enabled = false;
			break;
		case 3:
			nextEnemy = (GameObject)Instantiate(FinalEnemyTank, transform.position + startDir * surfaceLength, transform.rotation);
			EnemyTurretAI nextTurretScript = nextEnemy.transform.GetComponent<EnemyTurretAI>();
			nextTurretScript.currentPlanet = gameObject;
			nextTurretScript.chasing = true;
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

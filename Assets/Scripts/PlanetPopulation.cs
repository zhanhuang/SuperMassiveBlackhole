using UnityEngine;
using System.Collections;

public class PlanetPopulation : MonoBehaviour {
	public string planetType; // hostile, friendly, conflicting
	public float orbitLength;
	public float surfaceLength;
	public GameObject EnemyShip;
	public GameObject EnemyTurret;
	public GameObject Player;

	// TODO: Planet Texture

	
	void Awake (){
		float scale = Random.Range(40,100);
		transform.localScale = new Vector3(scale, scale, scale);
		orbitLength = transform.localScale.x / 2 + 5f;
		surfaceLength = transform.localScale.x / 2 - 0.5f;
	}
	
	// Use this for initialization
	void Start () {
		//TODO: move this call to happen after player reaches the planet
		GenerateEnemies();
	}

	// Update is called once per frame
	void Update () {
	}

	public void GenerateEnemies(){
		EnemyShip = (GameObject)Resources.Load("Enemy");
		EnemyTurret = (GameObject)Resources.Load("Enemy_Turret");
		for(int i = 0; i < 10; i++){
			Vector3 startDir = Random.insideUnitSphere.normalized;
			GameObject nextEnemyShip = (GameObject)Instantiate(EnemyShip, transform.position + startDir * orbitLength, transform.rotation);
			EnemyShipAI enemyOrbit = nextEnemyShip.transform.GetComponent<EnemyShipAI>();
			enemyOrbit.currentPlanet = gameObject;
			enemyOrbit.startingDirection = startDir;
		}
		
		for(int i = 0; i < 10; i++){
			Vector3 startDir = Random.insideUnitSphere.normalized;
			GameObject nextEnemyTurret = (GameObject)Instantiate(EnemyTurret, transform.position + startDir * surfaceLength, transform.rotation);
			nextEnemyTurret.transform.up = nextEnemyTurret.transform.position - transform.position;
		}
	}
}

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
	public GameObject EnemyShip;
	public GameObject EnemyTurret;
	public GameObject Player;

	
	void Awake (){
		float scale = Random.Range(80f,120f);
		transform.localScale = new Vector3(scale, scale, scale);
		orbitLength = transform.localScale.x / 2 + 5f;
		surfaceLength = transform.localScale.x / 2 - 0.02f;
	}
	
	// Use this for initialization
	void Start () {
		//TODO: move this call to happen after player reaches the planet
		//GenerateEnemies();
	}

	// Update is called once per frame
	void Update () {
	}

	public void GenerateEnemies(){
		EnemyShip = (GameObject)Resources.Load("Enemy_Ship");
		EnemyTurret = (GameObject)Resources.Load("Enemy_Turret");

		// generate enemy ships. Max 20
		for(int i = 0; i < 10; i++){
			Vector3 startDir = Random.insideUnitSphere.normalized;
			GameObject nextEnemyShip = (GameObject)Instantiate(EnemyShip, transform.position + startDir * orbitLength, transform.rotation);
			EnemyShipAI enemyOrbit = nextEnemyShip.transform.GetComponent<EnemyShipAI>();
			enemyOrbit.currentPlanet = gameObject;
			enemyOrbit.startingDirection = startDir;
		}
		
		// generate enemy turrets. Max 20
		// TODO: make sure turrets don't overlap
		for(int i = 0; i < 10; i++){
			Vector3 startDir = Random.insideUnitSphere.normalized;
			GameObject nextEnemyTurret = (GameObject)Instantiate(EnemyTurret, transform.position + startDir * surfaceLength, transform.rotation);
			EnemyTurretAI enemyOrbit = nextEnemyTurret.transform.GetComponent<EnemyTurretAI>();
			nextEnemyTurret.transform.up = nextEnemyTurret.transform.position - transform.position;
		}
	}
}

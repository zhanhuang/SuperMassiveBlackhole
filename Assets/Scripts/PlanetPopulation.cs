using UnityEngine;
using System.Collections;

public class PlanetPopulation : MonoBehaviour {
	public string planetType;
	public float orbitLength;
	public GameObject Enemy;
	public GameObject Player;
	//Material
	
	void Awake (){
		float scale = Random.Range(40,100);
		transform.localScale = new Vector3(scale, scale, scale);
		orbitLength = transform.localScale.x / 2 + 3f;
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
		Enemy = (GameObject)Resources.Load("Enemy");
		for(int i = 0; i < 10; i++){
			Vector3 startDir = Random.insideUnitSphere.normalized;
			GameObject nextEnemy = (GameObject)Instantiate(Enemy, transform.position + startDir * orbitLength, transform.rotation);
			EnemyAI enemyOrbit = nextEnemy.transform.GetComponent<EnemyAI>();
			enemyOrbit.currentPlanet = gameObject;
			enemyOrbit.startingDirection = startDir;
		}
	}
}

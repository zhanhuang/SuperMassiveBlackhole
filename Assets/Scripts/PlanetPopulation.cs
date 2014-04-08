using UnityEngine;
using System.Collections;

public class PlanetPopulation : MonoBehaviour {
	public int planetType;
	public float orbitLength;
	public GameObject Enemy;
	public GameObject Player;
	
	void Awake (){
		float scale = Random.Range(40,100);
		transform.localScale = new Vector3(scale, scale, scale);
		orbitLength = transform.localScale.x / 2 + 3f;
	}
	
	// Use this for initialization
	void Start () {
		Enemy = (GameObject)Resources.Load("Enemy");
		for(int i = 0; i < 10; i++){
			Vector3 startDir = Random.insideUnitSphere.normalized;
			GameObject nextEnemy = (GameObject)Instantiate(Enemy, transform.position + startDir * orbitLength, transform.rotation);
			EnemyAI enemyOrbit = nextEnemy.transform.GetComponent<EnemyAI>();
			enemyOrbit.currentPlanet = gameObject;
			enemyOrbit.startingDirection = startDir;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}

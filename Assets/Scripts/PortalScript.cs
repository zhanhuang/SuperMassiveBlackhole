using UnityEngine;
using System.Collections;

public class PortalScript : MonoBehaviour {
	public int Power = 2;
	public GameObject currentPlanet;

	GameObject enemy;

	bool porting = false;
	Vector3 startingPosition;

	// Use this for initialization
	void Start () {
		PlanetPopulation planet = currentPlanet.GetComponent<PlanetPopulation>();
		startingPosition = transform.position - transform.forward.normalized * 10f + transform.up.normalized * (planet.orbitLength - planet.surfaceLength);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool PortInEnemy(GameObject nextEnemy){
		if(porting){
			return false;
		} else{
			porting = true;
			enemy = nextEnemy;
			StartCoroutine(EnemyEmergence());
		}

		return true;
	}

	IEnumerator EnemyEmergence(){
		enemy.transform.position = startingPosition;
		enemy.transform.up = enemy.transform.position - currentPlanet.transform.position;
		if(enemy.GetComponent<EnemyTurretAI>() != null){
			// start tanks on the ground
			PlanetPopulation planet = currentPlanet.GetComponent<PlanetPopulation>();
			enemy.transform.position = enemy.transform.position - enemy.transform.up.normalized * (planet.orbitLength - planet.surfaceLength);
		}
		for(float t = 0f; t < 1.8f; t += Time.deltaTime){
			enemy.transform.RotateAround(currentPlanet.transform.position, enemy.transform.right, 1f);
			yield return null;
		}
		if(enemy.GetComponent<EnemyShipAI>() != null){
			enemy.GetComponent<EnemyShipAI>().OrbitSetup();
			enemy.GetComponent<EnemyShipAI>().enabled = true;
		} else if(enemy.GetComponent<EnemyTurretAI>() != null){
			enemy.GetComponent<EnemyTurretAI>().enabled = true;
		}
		porting = false;
	}

	public void LosePower(){
		Power--;
		if(Power <= 0){
			StopCoroutine("EnemyEmergence");
			if(porting){
				enemy.SendMessage("Die");
			}
			Destroy(gameObject);
		}
	}

	void FacePortal(){
		Vector3 playerDir = transform.position - enemy.transform.position;
		Vector2 forwardDirection = new Vector3(enemy.transform.forward.x,enemy.transform.forward.z);
		float angle = 30f;
		Vector3 cross = Vector3.Cross(playerDir,transform.forward);
		if(Vector3.Dot(cross, enemy.transform.up) > 0f){
			angle = -angle;
		} else if(Vector3.Dot(cross, enemy.transform.up) == 0f){
			angle = 0f;
		}
		rigidbody.AddTorque(enemy.transform.up.normalized * angle, ForceMode.Force);
	}
}
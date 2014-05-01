using UnityEngine;
using System.Collections;

public class PortalScript : MonoBehaviour {
	public int Power = 2;
	public GameObject currentPlanet;

	GameObject enemy;
	GameObject Explosion;

	bool porting = false;
	Vector3 startingPosition;

	// Use this for initialization
	void Start () {
		Explosion = (GameObject)Resources.Load("Explosion_Player");

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
		enemy.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		if(enemy.GetComponent<EnemyTurretAI>() != null){
			// start tanks on the ground
			PlanetPopulation planet = currentPlanet.GetComponent<PlanetPopulation>();
			enemy.transform.position = enemy.transform.position - enemy.transform.up.normalized * (planet.orbitLength - planet.surfaceLength);
			enemy.transform.rotation = Quaternion.LookRotation(transform.position + transform.up.normalized * 1f - enemy.transform.position);
		} else if(enemy.GetComponent<EnemyShipAI>() != null){
			enemy.GetComponent<EnemyShipAI>().OrbitSetup();
			enemy.transform.rotation = Quaternion.LookRotation(transform.position + transform.up.normalized * 10f - enemy.transform.position);
		}
		for(float t = 0f; t < 5f; t += Time.deltaTime){
			if(enemy != null){
				enemy.transform.RotateAround(currentPlanet.transform.position, enemy.transform.right, Time.deltaTime * 3f);
			}
			yield return null;
		}
		if(enemy != null){
			if(enemy.GetComponent<EnemyShipAI>() != null){
				// store the rotation so OrbitSetup doesn't mess it up
				Quaternion originalRotation = enemy.transform.rotation;
				enemy.GetComponent<EnemyShipAI>().enabled = true;
				enemy.transform.rotation = originalRotation;
			} else if(enemy.GetComponent<EnemyTurretAI>() != null){
				enemy.GetComponent<EnemyTurretAI>().enabled = true;
			}
			enemy.rigidbody.constraints = RigidbodyConstraints.None;
		}
		porting = false;
	}

	public void LosePower(){
		Power--;
		if(Power <= 0){
			StopCoroutine("EnemyEmergence");
			if(porting && enemy != null){
				enemy.SendMessage("Die");
			}
			porting = true;
			StartCoroutine(DieSlowly());
		}
	}

	IEnumerator DieSlowly(){
		Vector3 explosionCenter = transform.position + transform.up * 10f;
		Vector3 explosionOffset = Vector3.zero;
		for(int i = 0; i < 3; i++){
			explosionOffset = Random.Range(-3f, 3f) * transform.right + Random.Range(-5f, 5f) * transform.up;
			Destroy(Instantiate(Explosion, explosionCenter + explosionOffset, transform.rotation), 2f);
			yield return new WaitForSeconds(1f);
		}
		Destroy(gameObject);
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
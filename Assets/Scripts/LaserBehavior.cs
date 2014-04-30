using UnityEngine;
using System.Collections;

public class LaserBehavior : MonoBehaviour {
	public string laserOrigin;
	public string laserPath;
	public float laserSpeed;
	public Vector3 gravityCenter;
	GameObject Explosion;

	public AudioClip playerHitSound;
	// Use this for initialization
	void Start () {
		Explosion = (GameObject)Resources.Load ("Explosion_Laser");
		Destroy(gameObject, 80f / laserSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		if(laserPath == "orbit"  &&  gravityCenter != null){
			transform.RotateAround(gravityCenter,transform.right, laserSpeed * Time.deltaTime);
		} else if(laserPath == "straight"){
			transform.position += transform.up.normalized * laserSpeed * Time.deltaTime;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		/* Enemies can be hit by player or ally
		 * Allies can be hit by player or enemy
		 * Player and Shield can be hit by enemy only
		 */ 
		if(other.tag == "Player" || other.tag == "Shield"){
			if(laserOrigin == "Enemy"){
//				Debug.Log("player hit");
				Destroy(gameObject);
				Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
				if(other.transform.GetComponent<PlayerShipController>() != null){
					other.gameObject.SendMessage("TakeDamage", 1);
					other.audio.PlayOneShot (playerHitSound);
				}
			}
		} else if(other.tag == "Ally"){
			if(laserOrigin == "Player" || laserOrigin == "Enemy"){
//				Debug.Log("ally hit");
				Destroy(gameObject);
				Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
				if(other.transform.GetComponent<AllyShipAI>() != null){
					other.gameObject.SendMessage("TakeDamage", 1);
				}
			}
		} else if(other.tag == "Enemy"){
			if(laserOrigin == "Player" || laserOrigin == "Ally"){
//				Debug.Log("enemy hit");
				Destroy(gameObject);
				Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
				if(other.transform.GetComponent<EnemyShipAI>() != null || other.transform.GetComponent<EnemyTurretAI>() != null){
					other.gameObject.SendMessage("TakeDamage", 1);
				}
			}
		} else{
			// disappear upon hitting structure
			if(!other.isTrigger && other.tag != "Planet"){
				Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
				Destroy(gameObject);
			} else if(other.transform.GetComponent<LaserBehavior>() != null && other.transform.GetComponent<LaserBehavior>().laserOrigin != laserOrigin){
				Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
				Destroy(gameObject);
			}  else if(other.transform.GetComponent<MineMovement>() != null && other.transform.GetComponent<MineMovement>().mineOrigin != laserOrigin){
				Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
				Destroy(gameObject);
			} 
		}
	}
}

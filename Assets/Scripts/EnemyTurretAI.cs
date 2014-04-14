using UnityEngine;
using System.Collections;

public class EnemyTurretAI : MonoBehaviour {
	float fireCoolDown = 1f;
	float fireCoolDownRemaining = 0f;
	
	GameObject player;
	GameObject Laser;

	// Use this for initialization
	void Start () {
		
		// load prefab
		Laser = (GameObject)Resources.Load("Laser_Red");

		// set player
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		fireCoolDownRemaining -= Time.deltaTime;
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, 20f)){
			// check if the player is in front
			if(hit.transform.tag == "Player"){
				// player seen, fire laser
				if(fireCoolDownRemaining < 0f){
					GameObject nextLaser = (GameObject)Instantiate(Laser, transform.position, Quaternion.LookRotation(player.transform.position - transform.position));
					nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
					nextLaser.GetComponent<LaserBehavior>().laserPath = "straight";
					nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Enemy";
					nextLaser.GetComponent<LaserBehavior>().laserSpeed = 0.5f;
					fireCoolDownRemaining = fireCoolDown;
				}
			}
		}
	}
}

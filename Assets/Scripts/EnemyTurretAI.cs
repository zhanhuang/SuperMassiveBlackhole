using UnityEngine;
using System.Collections;

public class EnemyTurretAI : MonoBehaviour {
	float fireCoolDown = 0.5f;
	float fireCoolDownRemaining = 0f;
	
	GameObject player;
	GameObject Laser;
	GameObject Explosion;
	Vector3 LaserStartPosition;
	
	int health = 1;

	// Use this for initialization
	void Start () {
		
		// load prefabs
		Laser = (GameObject)Resources.Load("Laser_Red");
		Explosion = (GameObject)Resources.Load("Explosion_Player");

		// set player
		player = GameObject.FindGameObjectWithTag("Player");

		// set laser to fire above turret to avoid collision with planet itself
		LaserStartPosition = transform.position + transform.up.normalized * 1f;
	}
	
	// Update is called once per frame
	void Update () {
		fireCoolDownRemaining -= Time.deltaTime;
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, 20f)){
			// check if the player is in front
			if(hit.transform.tag == "Player" && Vector3.Angle(player.transform.position - transform.position, transform.up) < 60f){
				// player seen, fire laser
				if(fireCoolDownRemaining < 0f){
					GameObject nextLaser = (GameObject)Instantiate(Laser, LaserStartPosition, Quaternion.LookRotation(player.transform.position - LaserStartPosition));
					nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
					nextLaser.GetComponent<LaserBehavior>().laserPath = "straight";
					nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Enemy";
					nextLaser.GetComponent<LaserBehavior>().laserSpeed = 20f;
					fireCoolDownRemaining = fireCoolDown;
				}
			}
		}
	}
	
	public void TakeDamage(int damage){
		health -= damage;
		if(health <= 0){
			Die();
		}
	}
	
	public void Die(){
		Destroy(gameObject);
		Instantiate (Explosion, transform.position, transform.rotation);
	}
}

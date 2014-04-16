using UnityEngine;
using System.Collections;

public class EnemyTurretAI : MonoBehaviour {
	public float fireCoolDown = 0.5f;
	public float fireCoolDownRemaining = 0f;
	
	public GameObject player;
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
		if(fireCoolDownRemaining < 0f){
			RaycastHit hit = new RaycastHit();
			Vector3 raycastDir = player.transform.position - transform.position;
			if(Physics.Raycast(transform.position + raycastDir.normalized * 2f, raycastDir, out hit, 20f)){
				// check if the player is above
				if(hit.transform.tag == "Player" && Vector3.Angle(raycastDir, transform.up) < 60f){
					// player seen, fire laser
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
		Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
	}
}

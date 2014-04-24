using UnityEngine;
using System.Collections;

public class EnemyTurretAI : MonoBehaviour {
	public int health = 1;
	public int level = 0;

	public GameObject currentPlanet;
	float fireCoolDown = 0.5f;
	float fireCoolDownRemaining = 0f;
	
	bool flashing = false;

	public GameObject player;
	GameObject Laser;
	GameObject Explosion;
	Vector3 LaserStartPosition;

	public AudioClip turretGunSound;


	// Use this for initialization
	void Start () {
		
		// load prefabs
		Laser = (GameObject)Resources.Load("Laser_Red");
		Explosion = (GameObject)Resources.Load("Explosion_Player");

		// set player
		player = GameObject.Find("Player(Clone)");

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
				if(hit.transform.tag == "Player" && Vector3.Angle(raycastDir, transform.up) < 75f){
					// player seen, fire laser
					GameObject nextLaser = (GameObject)Instantiate(Laser, LaserStartPosition, Quaternion.LookRotation(player.transform.position - LaserStartPosition));
					audio.PlayOneShot(turretGunSound);
					nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
					nextLaser.GetComponent<LaserBehavior>().laserPath = "straight";
					nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Enemy";
					nextLaser.GetComponent<LaserBehavior>().laserSpeed = 20f;
					fireCoolDownRemaining = fireCoolDown;
				}
			}
			if(fireCoolDownRemaining < -2f * fireCoolDown){
				AutoFire();
				fireCoolDownRemaining = fireCoolDown;
			}
		}
	}
	
	public void TakeDamage(int damage){
		if(health <= 0){
			return;
		}
		health -= damage;
		if(health <= 0){
			currentPlanet.GetComponent<PlanetPopulation>().EnemyDied();
			Die();
		} else{
			if(!flashing){
				flashing = true;
				StartCoroutine(DamageFlash());
			}
		}
	}
	
	public void Die(){
		Destroy(gameObject);
		Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
	}
	
	IEnumerator DamageFlash(){
		Material targetMat1 = transform.FindChild("TurretBase").renderer.material;
		Material targetMat2 = transform.FindChild("TurretHead").renderer.material;

		Color origColor1 = targetMat1.color;
		Color origColor2 = targetMat2.color;
		targetMat1.color = Color.white;
		targetMat2.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		targetMat1.color = origColor1;
		targetMat2.color = origColor2;
		yield return new WaitForSeconds(0.05f);
		targetMat1.color = Color.white;
		targetMat2.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		targetMat1.color = origColor1;
		targetMat2.color = origColor2;
		flashing = false;
	}

	void AutoFire(){
		if(level < 2){
			// fires straight up when idle
			GameObject nextLaser = (GameObject)Instantiate(Laser, LaserStartPosition, Quaternion.LookRotation(transform.up));
			audio.PlayOneShot(turretGunSound);
			nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
			nextLaser.GetComponent<LaserBehavior>().laserPath = "straight";
			nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Enemy";
			nextLaser.GetComponent<LaserBehavior>().laserSpeed = 20f;
		} else{
			// fires at 45 degree angles when idle
			for(int i = 0; i < 4; i++){
				GameObject nextLaser = (GameObject)Instantiate(Laser, LaserStartPosition, Quaternion.LookRotation(transform.up));
				audio.PlayOneShot(turretGunSound);
				nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
				nextLaser.transform.Rotate(new Vector3(45f,90f*i,0f));
				nextLaser.GetComponent<LaserBehavior>().laserPath = "straight";
				nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Enemy";
				nextLaser.GetComponent<LaserBehavior>().laserSpeed = 20f;
			}
		}
	}
}

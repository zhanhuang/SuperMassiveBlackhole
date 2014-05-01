using UnityEngine;
using System.Collections;

public class EnemyTurretAI : MonoBehaviour {
	public int level = 0;
	public int health = 1;

	public GameObject currentPlanet;
	float fireCoolDown = 0.8f;
	float fireCoolDownRemaining = 0f;
	
	bool flashing = false;

	public GameObject player;
	GameObject Laser;
	GameObject Explosion;

	public AudioClip turretGunSound;
	public AudioClip turretDeadSound;

	// for tanks
	float speed = 5f;
	float turnSpeed = 10f;

	bool chasing = false;
	float chaseTimeLimit = 8f;
	float chaseCountDown = 0f;
	float rotationDir = 1f;
	float rotationTime = 0f;
	GameObject turretDeathAudioSource;
	
	void Awake (){
	}

	// Use this for initialization
	void Start () {
		// load prefabs
		Laser = (GameObject)Resources.Load("Laser_Red");

		// set player
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		fireCoolDownRemaining -= Time.deltaTime;
		if(fireCoolDownRemaining < 0f){
			// set laser to fire above turret to avoid collision with planet itself
			Vector3 LaserStartPosition = transform.position + transform.up.normalized * 1f;

			// check if the player is above
			Vector3 playerDir = player.transform.position - transform.position;
			if((playerDir).magnitude < 20f && Vector3.Angle(playerDir, transform.up) < 75f){
				// player seen, fire laser
				GameObject nextLaser = (GameObject)Instantiate(Laser, LaserStartPosition, Quaternion.LookRotation(player.transform.position - LaserStartPosition));
				audio.PlayOneShot(turretGunSound);
				nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
				nextLaser.GetComponent<LaserBehavior>().laserPath = "straight";
				nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Enemy";
				nextLaser.GetComponent<LaserBehavior>().laserSpeed = 20f;
				fireCoolDownRemaining = fireCoolDown - level * 0.5f * fireCoolDown;
				if(level > 0){
					chasing = true;
				}
			} else if(chasing){
				if(chaseCountDown <= 0f){
					chaseCountDown = chaseTimeLimit;
				}
				chaseCountDown -= Time.deltaTime;
				if(chaseCountDown <= 0f){
					chasing = false;
				}
			} else if(fireCoolDownRemaining < -2f * fireCoolDown){
				if(level > 0){
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
				fireCoolDownRemaining = fireCoolDown - level * 0.5f * fireCoolDown;
			}
		}

		// Tank only
		if(level > 0){
			// moving
			if(!chasing){
				// random walk if chasing or not in range
				transform.RotateAround(currentPlanet.transform.position,transform.right, Time.deltaTime * 4f);
			} else if (chasing){
				if((player.transform.position - transform.position).magnitude > 10f){
					transform.RotateAround(currentPlanet.transform.position,transform.right, Time.deltaTime * 8f);
				}
			}
			// turning
			if(chasing){
				if((player.transform.position - transform.position).magnitude > 10f){
					// turn to chase player
					Vector3 playerDir = player.transform.position - transform.position;
					Vector2 forwardDirection = new Vector3(transform.forward.x,transform.forward.z);
					float angle = 30f;
					Vector3 cross = Vector3.Cross(playerDir,transform.forward);
					if(Vector3.Dot(cross, transform.up) > 0f){
						angle = -angle;
					} else if(Vector3.Dot(cross, transform.up) == 0f){
						angle = 0f;
					}
					transform.Rotate(new Vector3(0f, angle/Mathf.Abs(angle) * 2f, 0f));
				}
			} else{
				// random walk
				rotationTime += Time.deltaTime;
				if(rotationTime > 10f){
					if(Random.Range(0,2) == 0){
						rotationDir = -rotationDir;
						rotationTime = 0f;
					} else{
						rotationTime -= Random.Range(8f,10f);
					}
				}
				transform.Rotate(new Vector3(0f, Random.Range(0f,0.5f) * rotationDir, 0f));
			}
		}
	}
	
	public void TakeDamage(int damage){
		if(health <= 0){
			return;
		}
		health -= damage;
		if(health <= 0){
			Die();
		} else{
			if(!flashing){
				flashing = true;
				StartCoroutine("DamageFlash");
			}
		}
	}
	
	public void Die(){
		currentPlanet.GetComponent<PlanetPopulation>().EnemyDied();
		Explosion = (GameObject)Resources.Load("Explosion_Player");
		turretDeathAudioSource = (GameObject)Resources.Load ("turretdeathprefab");
		currentPlanet.GetComponent<PlanetPopulation>().GenerateLootAt(transform.position, level);
		Destroy(Instantiate (turretDeathAudioSource, transform.position, transform.rotation), turretDeadSound.length);
		Destroy(gameObject);
		Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
	}
	
	IEnumerator DamageFlash(){
		Material targetMat = null;
		if(level == 0){
			targetMat = transform.FindChild("TurretTop").FindChild("polySurface14").renderer.material;
		} else if(level == 1){
			targetMat = transform.FindChild("Tank_Body").renderer.material;
		}
		Color origColor = targetMat.color;
		targetMat.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		targetMat.color = origColor;
		yield return new WaitForSeconds(0.05f);
		targetMat.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		targetMat.color = origColor;
		flashing = false;
	}

	void OnTriggerEnter(Collider other) {
		if(level > 0){
			if(other.tag == "Destructible" || other.tag == "Enemy"){
				transform.RotateAround(currentPlanet.transform.position, -transform.right, 1f);
				transform.Rotate(new Vector3(0f, -30f * rotationDir, 0f));
			}
		}
	}
}

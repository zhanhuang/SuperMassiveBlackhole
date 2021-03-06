﻿using UnityEngine;
using System.Collections;

// Inherits from ShipOrbitBehavior
public class EnemyShipAI : ShipOrbitBehavior {
	public float speed = 10f;
	public float turnSpeed = 10f;
	
	public int health = 1;
	public int level = 0;

	public AudioClip enemyGunSound;
	public AudioClip deathSound;

	public float fireCoolDown = 1f;
	float fireCoolDownRemaining = 0f;
	float mineCoolDown = 15f;
	float mineCoolDownRemaining = 0f;
	
	bool flashing = false;

	GameObject player;
	GameObject Laser;
	GameObject Mine;
	GameObject Explosion;
	GameObject deathAudioSource;

	// AI types
	public string enemyType;	// random, chase
	public bool mineEnabled = false;
	public bool chasing = false;
	float chaseTimeLimit = 8f;
	float chaseCountDown = 0f;

	// fix for turning after emerged from portal
	public Quaternion snapRotation = Quaternion.identity;

	void Awake (){
	}

	// Use this for initialization
	void Start () {
		
		// load prefabs
		Laser = (GameObject)Resources.Load("Laser_Red");
		Mine = (GameObject)Resources.Load("Mine_Red");
		
		// set player
		player = GameObject.FindGameObjectWithTag("Player");
		
		OrbitSetup();
		StartCoroutine("AvoidObstacle");

		if(snapRotation != Quaternion.identity){
			transform.rotation = snapRotation;
		}

		mineCoolDownRemaining = Random.Range(0f, mineCoolDown/2f);
	}
	
	// Update is called once per frame
	void Update () {
		fireCoolDownRemaining -= Time.deltaTime;
		mineCoolDownRemaining -= Time.deltaTime;

		if(enemyType == "random"){
			if(fireCoolDownRemaining < 0f){
				AutoFire();
				fireCoolDownRemaining = fireCoolDown;
			}
		}else if(enemyType == "chase"){
			// chasing fire pattern
			RaycastHit hit = new RaycastHit();
			Vector3 raycastDir = player.transform.position - transform.position;
			if(Physics.Raycast(transform.position + raycastDir.normalized * 2f, raycastDir, out hit, 60f)){
				// check if the player is in front
				if(hit.transform.tag == "Player" && Vector3.Angle(raycastDir, transform.forward) < 80f){
					chasing = true;
					chaseCountDown = -1f;
					if(fireCoolDownRemaining < 0f){
						AutoFire();
						fireCoolDownRemaining = fireCoolDown;
					}
				} else{
					if(chasing){
						if(chaseCountDown <= 0f){
							chaseCountDown = chaseTimeLimit;
						}
						chaseCountDown -= Time.deltaTime;
						if(chaseCountDown <= 0f){
							chasing = false;
						}
					}
				}
			}
		}

		if(mineEnabled && mineCoolDownRemaining < 0f){
			mineCoolDownRemaining = mineCoolDown;
			GameObject nextmine = (GameObject)Instantiate(Mine, transform.position, transform.rotation);
			nextmine.transform.GetComponent<MineMovement>().mineOrigin = "Enemy";
		}
	}

	void FixedUpdate () {
		if(!chasing || (player.transform.position - transform.position).magnitude > 15f){
			// random walk if chasing or not in range
			if(GetComponent<Rigidbody>().velocity.z < 10f){
				GetComponent<Rigidbody>().AddForce(transform.forward.normalized * Time.deltaTime * speed * Random.Range(-1f,4f), ForceMode.VelocityChange);
			}
		} else if (chasing){
			GetComponent<Rigidbody>().AddForce(transform.forward.normalized * Time.deltaTime * speed * 4f, ForceMode.Force);
		}
		if(chasing){
			// chase player
			Vector3 playerDir = player.transform.position - transform.position;
			Vector2 forwardDirection = new Vector3(transform.forward.x,transform.forward.z);
			float angle = 30f;
			Vector3 cross = Vector3.Cross(playerDir,transform.forward);
			if(Vector3.Dot(cross, transform.up) > 0f){
				angle = -angle;
			} else if(Vector3.Dot(cross, transform.up) == 0f){
				angle = 0f;
			}
			if(angle != 0f){
				GetComponent<Rigidbody>().AddTorque(transform.up.normalized * Time.deltaTime * turnSpeed * angle, ForceMode.Force);
			}
		} else{
			// random walk
			GetComponent<Rigidbody>().AddTorque(transform.up.normalized * Time.deltaTime * turnSpeed * Random.Range(-10f,10f), ForceMode.Force);
		}
	}


	IEnumerator AvoidObstacle(){
		while(true){
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast(transform.position, transform.forward, out hit, 15f)){
				// check if the player is in front
				if (hit.transform.tag != "Player" && hit.transform.tag != "Shield" && hit.transform.tag != "Ally"){
//					Debug.Log("Avoid Obstacle At:" + hit.transform.position);
					GetComponent<Rigidbody>().AddForce(-transform.forward.normalized * speed * 1f, ForceMode.VelocityChange);
					GetComponent<Rigidbody>().AddTorque(transform.up.normalized * turnSpeed * 0.5f, ForceMode.VelocityChange);
				}
			}
			yield return new WaitForSeconds(1f);
		}
	}
	
	void OnCollisionEnter(Collision collision){
		Vector3 collisionDir = (collision.transform.position -  transform.position).normalized;
		GetComponent<Rigidbody>().AddForce(-collisionDir * 20f, ForceMode.VelocityChange);
		GetComponent<Rigidbody>().AddTorque(transform.up.normalized * turnSpeed * 0.5f, ForceMode.VelocityChange);
	}
	
	public void TakeDamage(int damage){
		if(health <= 0){
			return;
		}
		health -= damage;
		if(health <= 0){
			Die();
		} else{
			// chase on hit
			chasing = true;

			// flash on hit
			if(!flashing){
				flashing = true;
				StartCoroutine("DamageFlash");
			}
		}
	}

	public void Die(){
		Explosion = (GameObject)Resources.Load("Explosion_Player");
		deathAudioSource = (GameObject)Resources.Load ("enemydeathprefab");
		currentPlanet.GetComponent<PlanetPopulation>().GenerateLootAt(transform.position, level);
		Destroy(Instantiate (deathAudioSource, transform.position, transform.rotation), deathSound.length);
		Destroy(gameObject);
		Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
		currentPlanet.GetComponent<PlanetPopulation>().EnemyDied();
	}
	
	IEnumerator DamageFlash(){
		Material targetMat = transform.Find("Ship").GetComponent<Renderer>().materials[0];
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

	void AutoFire(){
		if(level < 2){
			GameObject nextLaser = (GameObject)Instantiate(Laser, transform.position, transform.rotation);
			GetComponent<AudioSource>().PlayOneShot(enemyGunSound);
			nextLaser.transform.Rotate(new Vector3(90f,0f,0f));
			nextLaser.GetComponent<LaserBehavior>().laserPath = "orbit";
			nextLaser.GetComponent<LaserBehavior>().gravityCenter = currentPlanet.transform.position;
			nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Enemy";
			nextLaser.GetComponent<LaserBehavior>().laserSpeed = 45f;

		} else{
			for(int i = -1; i < 2; i++){
				GameObject nextLaser = (GameObject)Instantiate(Laser, transform.position, transform.rotation);
				GetComponent<AudioSource>().PlayOneShot(enemyGunSound);
				nextLaser.transform.Rotate(new Vector3(90f,30f * i,0f));
				nextLaser.GetComponent<LaserBehavior>().laserPath = "orbit";
				nextLaser.GetComponent<LaserBehavior>().gravityCenter = currentPlanet.transform.position;
				nextLaser.GetComponent<LaserBehavior>().laserOrigin = "Enemy";
				nextLaser.GetComponent<LaserBehavior>().laserSpeed = 45f;

			}
		}
	}
}

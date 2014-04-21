﻿using UnityEngine;
using System.Collections;

public class LaserBehavior : MonoBehaviour {
	public string laserOrigin;
	public string laserPath;
	public float laserSpeed;
	public Vector3 gravityCenter;
	GameObject Explosion;
	GameObject Health;

	// Use this for initialization
	void Start () {
		Explosion = (GameObject)Resources.Load ("Explosion_Laser");
		Health = (GameObject)Resources.Load ("Health");
		Destroy(gameObject, 120f / laserSpeed);
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
//		Debug.Log("trigger enter");
		if(other.tag == "Player"){
			if(laserOrigin == "Enemy"){
				Debug.Log("player hit");
				Destroy(gameObject);
				Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
				if(other.transform.GetComponent<PlayerShipController>() != null){
					other.gameObject.SendMessage("TakeDamage", 1);
				}
			}
		} else if(other.tag == "Enemy"){
			if(laserOrigin == "Player"){
				Debug.Log("enemy hit");
				if(other.transform.GetComponent<EnemyShipAI>().enemyDrop == (0)||other.transform.GetComponent<EnemyShipAI>().enemyDrop == (1)){
					Instantiate (Health, transform.position, transform.rotation);
				}
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
			}
		}
	}
}

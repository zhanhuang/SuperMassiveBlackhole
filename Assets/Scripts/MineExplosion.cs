﻿using UnityEngine;
using System.Collections;

public class MineExplosion : MonoBehaviour {
	GameObject dustCloud;
	float countDown = 0.3f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		countDown -= Time.deltaTime;
		if(countDown <= 0f){
			transform.GetComponent<Collider>().enabled = false;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player" && other.GetComponent<PlayerShipController>().shieldTimeRemaining <= 0f){
			other.gameObject.SendMessage("TakeDamage", 2);
		} else if(other.tag == "Enemy" || other.tag == "Ally"){
			other.gameObject.SendMessage("TakeDamage", 4);
		} else if(other.tag == "Destructible"){
			dustCloud = (GameObject)Resources.Load ("Crater_Dust");
//			Debug.Log("destruction!");
			Destroy(other.gameObject);
			Destroy(Instantiate (dustCloud, transform.position, transform.rotation), 2f);
		} 
	}
}

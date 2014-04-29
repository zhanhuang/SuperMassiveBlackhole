using UnityEngine;
using System.Collections;

public class MineExplosion : MonoBehaviour {
	float countDown = 0.8f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(countDown > 0f){
			countDown -= Time.deltaTime;
			if(countDown <= 0f){
				transform.collider.enabled = false;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Enemy" || other.tag == "Ally" || other.tag == "Player"){
			other.gameObject.SendMessage("TakeDamage", 2);
		} else if(other.tag == "Destructible"){
			Debug.Log("destruction!");
			Destroy(other.gameObject);
			// TODO: dust puff
		} 
	}
}

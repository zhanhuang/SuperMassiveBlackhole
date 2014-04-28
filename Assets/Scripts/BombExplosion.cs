using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Enemy"){
			Debug.Log("enemy hit");
			other.gameObject.SendMessage("TakeDamage", 1);
		} else if(other.tag == "Ally"){
			Debug.Log("ally hit");
			other.gameObject.SendMessage("TakeDamage", 1);
		} else if(other.tag == "Destructible"){
			Debug.Log("destruction!");
			Destroy(other.gameObject);
			// TODO: dust puff
		} 
	}
}

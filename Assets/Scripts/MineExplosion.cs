using UnityEngine;
using System.Collections;

public class MineExplosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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

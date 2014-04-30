using UnityEngine;
using System.Collections;

public class EMPBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Enemy" || other.tag == "Ally"){
//			Debug.Log("enemy hit");
			other.gameObject.SendMessage("TakeDamage", 1);
		} else if(other.GetComponent<LaserBehavior>() != null && other.GetComponent<LaserBehavior>().laserOrigin != "Player"){
			Destroy(other.gameObject);
		} else if(other.GetComponent<MineMovement>() != null && other.GetComponent<MineMovement>().mineOrigin != "Player"){
			Destroy(other.gameObject);
		} 
	}
}

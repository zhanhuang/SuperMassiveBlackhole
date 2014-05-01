using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour {
	GameObject dustCloud;
	// Use this for initialization
	void Start () {
		dustCloud = (GameObject)Resources.Load ("Crater_Dust");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Enemy"){
//			Debug.Log("enemy hit");
			other.gameObject.SendMessage("TakeDamage", 1);
		} else if(other.tag == "Ally"){
//			Debug.Log("ally hit");
			other.gameObject.SendMessage("TakeDamage", 1);
		} else if(other.tag == "Destructible"){
//			Debug.Log("destruction!");
			Destroy(other.gameObject);
			Destroy(Instantiate (dustCloud, transform.position, transform.rotation), 2f);
			// TODO: dust puff
		} 
	}
}

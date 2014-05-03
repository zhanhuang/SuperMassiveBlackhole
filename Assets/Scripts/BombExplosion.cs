using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour {
	GameObject dustCloud;
	float countDown = 0.3f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		countDown -= Time.deltaTime;
		if(countDown <= 0f){
			transform.collider.enabled = false;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Enemy"){
//			Debug.Log("enemy hit");
			other.gameObject.SendMessage("TakeDamage", 1);
		} else if(other.tag == "Ally"){
//			Debug.Log("ally hit");
			other.gameObject.SendMessage("TakeDamage", 1);
		} else if(other.tag == "Destructible"){
			dustCloud = (GameObject)Resources.Load ("Crater_Dust");
//			Debug.Log("destruction!");
			Destroy(other.gameObject);
			Destroy(Instantiate (dustCloud, transform.position, transform.rotation), 2f);
		} 
	}
}

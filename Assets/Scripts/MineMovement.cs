using UnityEngine;
using System.Collections;

public class MineMovement : MonoBehaviour {
	public string mineOrigin;
	GameObject Explosion;

	// Use this for initialization
	void Start () {
		Explosion = (GameObject)Resources.Load ("Explosion_Mine");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		// explode upon hitting structure or planet surface, explosion deals damage
		if(other.tag == "Shield" && mineOrigin == "Player"){
			return;
		} else if(other.tag != mineOrigin && (other.tag == "Player" || other.tag == "Ally" || other.tag == "Enemy")){
			Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
			Destroy(gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class LaserBehavior : MonoBehaviour {
	public string laserType;
	public Vector3 gravityCenter;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		if(gravityCenter != null){
			transform.RotateAround(gravityCenter,transform.right, 1f);
		}
	}
	
	void OnTriggerEnter(Collider other) {
//		Debug.Log("trigger enter");
		if(other.tag == "Player" && laserType == "Enemy"){
			Debug.Log("player hit");
		} else if(other.tag == "Enemy" && laserType == "Player"){
			Debug.Log("enemy hit");
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}

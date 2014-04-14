using UnityEngine;
using System.Collections;

public class LaserBehavior : MonoBehaviour {
	public string laserType;
	public float laserSpeed;
	public Vector3 gravityCenter;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 2f / laserSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		if(gravityCenter != null){
			transform.RotateAround(gravityCenter,transform.right, laserSpeed);
		}
	}
	
	void OnTriggerEnter(Collider other) {
//		Debug.Log("trigger enter");
		if(other.tag == "Player"){
			if(laserType == "Enemy"){
				Debug.Log("player hit");
			}
		} else if(other.tag == "Enemy"){
			if(laserType == "Player"){
				Debug.Log("enemy hit");
				Destroy(other.gameObject);
				Destroy(gameObject);
			}
		} else{
			// disappear upon hitting structure
			if(!other.isTrigger){
				Destroy(gameObject);
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class LaserBehavior : MonoBehaviour {
	public string laserOrigin;
	public string laserPath;
	public float laserSpeed;
	public Vector3 gravityCenter;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 120f / laserSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		if(laserPath == "orbit"  &&  gravityCenter != null){
			transform.RotateAround(gravityCenter,transform.right, laserSpeed * Time.deltaTime);
		} else if(laserPath == "straight"){
			transform.Translate(transform.up.normalized * laserSpeed * Time.deltaTime);
		}
	}
	
	void OnTriggerEnter(Collider other) {
//		Debug.Log("trigger enter");
		if(other.tag == "Player"){
			if(laserOrigin == "Enemy"){
				Debug.Log("player hit");
				other.transform.GetComponent<PlayerShipController>().TakeDamage(1);
			}
		} else if(other.tag == "Enemy"){
			if(laserOrigin == "Player"){
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

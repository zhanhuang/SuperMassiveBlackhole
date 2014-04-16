using UnityEngine;
using System.Collections;

public class LaserBehavior : MonoBehaviour {
	public string laserOrigin;
	public string laserPath;
	public float laserSpeed;
	public Vector3 gravityCenter;
	GameObject Explosion;

	// Use this for initialization
	void Start () {
		Explosion = (GameObject)Resources.Load ("Explosion_Laser");
		Destroy(gameObject, 120f / laserSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		if(laserPath == "orbit"  &&  gravityCenter != null){
			transform.RotateAround(gravityCenter,transform.right, laserSpeed * Time.deltaTime);
		} else if(laserPath == "straight"){
			transform.position += transform.up.normalized * laserSpeed * Time.deltaTime;
		}
	}
	
	void OnTriggerEnter(Collider other) {
//		Debug.Log("trigger enter");
		if(other.tag == "Player"){
			if(laserOrigin == "Enemy"){
				Debug.Log("player hit");
				other.gameObject.SendMessage("TakeDamage", 1);
				Instantiate (Explosion, transform.position, transform.rotation);
			}
		} else if(other.tag == "Enemy"){
			if(laserOrigin == "Player"){
				Debug.Log("enemy hit");
				Destroy(other.gameObject);
				Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
				other.gameObject.SendMessage("TakeDamage", 1);
			}
		} else{
			// disappear upon hitting structure
			if(!other.isTrigger){
				Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
				Destroy(gameObject);
			} else if(other.transform.GetComponent<LaserBehavior>() != null && other.transform.GetComponent<LaserBehavior>().laserOrigin != laserOrigin){
				Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
				Destroy(gameObject);
			}
		}
	}
}

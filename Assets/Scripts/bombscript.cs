using UnityEngine;
using System.Collections;

public class bombscript : MonoBehaviour {
	public Vector3 gravityCenter;
	GameObject explosion;
	// Use this for initialization

	void Start () {
		explosion = (GameObject)Resources.Load ("Explosion03a");
		StartCoroutine (bombroutine ());
	}
	IEnumerator bombroutine(){
		yield return new WaitForSeconds (0.5f);
		Instantiate (explosion, transform.position, transform.rotation);
		collider.isTrigger = true;
		Destroy (gameObject);
	}
	// Update is called once per frame
	void Update () {
		if(gravityCenter != null){
			transform.RotateAround(gravityCenter,transform.right, 1f);
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy") {
				Destroy (other.gameObject);
				}
		}
}

using UnityEngine;
using System.Collections;

public class BombMovement : MonoBehaviour {
	public Vector3 gravityCenter;
	public float bombForwardSpeed = 30f;
	GameObject Explosion;
	// Use this for initialization

	void Start () {
		Explosion = (GameObject)Resources.Load ("Explosion_Bomb");
		StartCoroutine (bombroutine());
	}
	IEnumerator bombroutine(){
		yield return new WaitForSeconds (2f);
		Instantiate (Explosion, transform.position, transform.rotation);
		Destroy (gameObject);
	}
	// Update is called once per frame
	void Update () {
		if(gravityCenter != null){
			transform.position = transform.position + transform.up.normalized * Time.deltaTime * 10f;
			transform.RotateAround(gravityCenter, transform.right, Time.deltaTime * bombForwardSpeed);
		}
	}

	void OnTriggerEnter(Collider other){
		// explode upon hitting structure or planet surface, explosion deals damage
		if(other.tag != "Player" && !other.isTrigger){
			Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
			Destroy(gameObject);
		}
	}
}

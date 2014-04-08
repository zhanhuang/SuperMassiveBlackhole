using UnityEngine;
using System.Collections;

// Inherits from ShipOrbitBehavior
public class EnemyAI : ShipOrbitBehavior {
	public float speed = 10f;
	public float turnSpeed = 10f;

	// Use this for initialization
	void Start () {
		OrbitSetup();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate () {
		if(rigidbody.velocity.z < 10f){
			rigidbody.AddForce(transform.forward.normalized * Time.deltaTime * speed * Random.Range(-1f,5f), ForceMode.VelocityChange);
		}
		rigidbody.AddTorque(transform.up.normalized * Time.deltaTime * turnSpeed * Random.Range(-10f,10f), ForceMode.Force);
	}
}

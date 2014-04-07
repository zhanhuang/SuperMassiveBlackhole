using UnityEngine;
using System.Collections;

public class PlayerShipController : MonoBehaviour {
	public Planet currentPlanet;
	public float acceleration = 30f;
	public float maxSpeed = 60f;

	float turnSpeed = 2f;
	float maxTurnSpeed = 4f;

	float currentSpeed = 0f;
	float currentTurningSpeed = 0f;

	ConfigurableJoint shipJoint;

	// Use this for initialization
	void Start () {
		transform.parent.position = currentPlanet.transform.position;
		transform.position = currentPlanet.transform.position + (currentPlanet.transform.position - transform.position).normalized * currentPlanet.orbitLength;
		transform.up = transform.position - currentPlanet.transform.position;


		shipJoint = transform.GetComponent<ConfigurableJoint>();
		shipJoint.xMotion = ConfigurableJointMotion.Locked;
		shipJoint.yMotion = ConfigurableJointMotion.Locked;
		shipJoint.zMotion = ConfigurableJointMotion.Locked;
		Vector3 toCenter = -transform.localPosition;
		shipJoint.anchor = transform.InverseTransformDirection(toCenter);
	}
	
	// Update is called once per frame
	void Update () {
		// reset
		if (Input.GetKey(KeyCode.R)){
			Application.LoadLevel(0);
		}


//		// moving
//		if(Input.GetKey(KeyCode.W)){
//			if(currentSpeed < maxSpeed){
//				currentSpeed += Time.deltaTime * acceleration;
//				if(currentSpeed < 0){
//					currentSpeed += Time.deltaTime * acceleration;
//				}
//			}
//		} else if(Input.GetKey(KeyCode.S)){
//			if(currentSpeed > -maxSpeed){
//				currentSpeed -= Time.deltaTime * acceleration;
//				if(currentSpeed > 0){
//					currentSpeed -= Time.deltaTime * acceleration;
//				}
//			}
//		} else{
//			// drag = maxSpeed * 0.5
//			if(currentSpeed != 0f){
//				currentSpeed = Mathf.Lerp(currentSpeed, 0f, Time.deltaTime * maxSpeed * 0.5f / Mathf.Abs(currentSpeed));
//			}
//		}
//		transform.RotateAround(currentPlanet.transform.position, transform.right, Time.deltaTime * currentSpeed);
//		
//		
//		// turning
//		if(Input.GetKey(KeyCode.D)){
//			if(currentTurningSpeed < maxTurnSpeed){
//				currentTurningSpeed += Time.deltaTime * turnSpeed;
//				if(currentTurningSpeed < 0f){
//					currentTurningSpeed += Time.deltaTime * turnSpeed;
//				}
//			}
//		} else if(Input.GetKey(KeyCode.A)){
//			if(currentTurningSpeed > -maxTurnSpeed){
//				currentTurningSpeed -= Time.deltaTime * turnSpeed;
//				if(currentTurningSpeed > 0f){
//					currentTurningSpeed -= Time.deltaTime * turnSpeed;
//				}
//			}
//		} else{
//			// drag = maxSpeed * 0.5
//			if(currentTurningSpeed != 0f){
//				currentTurningSpeed = Mathf.Lerp(currentTurningSpeed, 0f, Time.deltaTime * maxTurnSpeed * 0.5f / Mathf.Abs(currentTurningSpeed));
//			}
//		}
//		transform.RotateAround(transform.up, Time.deltaTime * currentTurningSpeed);
	}


	void FixedUpdate () {

		if (Input.GetKey(KeyCode.W)){
			rigidbody.AddForce(transform.forward.normalized * Time.deltaTime * acceleration, ForceMode.VelocityChange);
		}
		if (Input.GetKey(KeyCode.S)){
			rigidbody.AddForce(-transform.forward.normalized * Time.deltaTime * acceleration, ForceMode.VelocityChange);
		}
		if (Input.GetKey(KeyCode.D)){
			rigidbody.AddTorque(transform.up.normalized * Time.deltaTime * turnSpeed, ForceMode.VelocityChange);
		}
		if (Input.GetKey(KeyCode.A)){
			rigidbody.AddTorque(-transform.up.normalized * Time.deltaTime * turnSpeed, ForceMode.VelocityChange);
		}
		
//		rigidbody.AddForce(-Vector3.Project(rigidbody.velocity, transform.up));
//		
//		rigidbody.MovePosition(transform.position);
//		rigidbody.MoveRotation(transform.rotation);

	}
}

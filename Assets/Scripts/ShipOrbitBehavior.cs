using UnityEngine;
using System.Collections;

public class ShipOrbitBehavior : MonoBehaviour {
	public GameObject currentPlanet;
	public Vector3 startingDirection;
	ConfigurableJoint shipJoint;

	// Use this for initialization
	void Start () {
		currentPlanet = GameObject.Find("Planet");
		OrbitSetup();
	}

	public void OrbitSetup () {
		if(startingDirection == Vector3.zero){
			Debug.Log("Missing starting direction, generating random one instead");
			startingDirection = Random.insideUnitSphere.normalized;
		}
		
		// set up ship to orbit around planet
		transform.position = currentPlanet.transform.position + startingDirection.normalized * currentPlanet.GetComponent<PlanetPopulation>().orbitLength;
		transform.up = transform.position - currentPlanet.transform.position;
		
		shipJoint = transform.GetComponent<ConfigurableJoint>();
		shipJoint.xMotion = ConfigurableJointMotion.Locked;
		shipJoint.yMotion = ConfigurableJointMotion.Locked;
		shipJoint.zMotion = ConfigurableJointMotion.Locked;
		shipJoint.anchor = transform.InverseTransformDirection(currentPlanet.transform.position - transform.position) / transform.localScale.y;
	}

	// Update is called once per frame
	void Update () {
	
	}
}

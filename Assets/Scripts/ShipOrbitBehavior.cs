using UnityEngine;
using System.Collections;

public class ShipOrbitBehavior : MonoBehaviour {
	public GameObject currentPlanet;
	ConfigurableJoint shipJoint;

	// Use this for initialization
	void Start () {
		currentPlanet = GameObject.Find("Planet");
		OrbitSetup();
	}

	public void OrbitSetup () {
		// set up ship to orbit around planet
		Vector3 startingDirection = (transform.position - currentPlanet.transform.position).normalized;
		transform.position = currentPlanet.transform.position + startingDirection.normalized * currentPlanet.GetComponent<PlanetPopulation>().orbitLength;
		transform.up = transform.position - currentPlanet.transform.position;

		shipJoint = gameObject.AddComponent<ConfigurableJoint>();
		shipJoint.xMotion = ConfigurableJointMotion.Locked;
		shipJoint.yMotion = ConfigurableJointMotion.Locked;
		shipJoint.zMotion = ConfigurableJointMotion.Locked;
		shipJoint.anchor = transform.InverseTransformDirection(currentPlanet.transform.position - transform.position) / transform.localScale.y;
	}

	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class TankCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(!other.isTrigger){
			transform.parent.SendMessage("TankAvoid");
		}
	}

//	void OnTriggerStay(Collider other) {
//		if(!other.isTrigger && other.tag != "Planet"){
//			transform.parent.SendMessage("TankAvoid");
//		}
//	}
}

using UnityEngine;
using System.Collections;

public class LightRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(10f * Time.deltaTime, 0f, 0f));
	}
}

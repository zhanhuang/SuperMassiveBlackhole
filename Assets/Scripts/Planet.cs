using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {
	public int planetType;
	public float orbitLength;

	void Awake (){
		float scale = Random.Range(20,80);
		transform.localScale = new Vector3(scale, scale, scale);
		orbitLength = transform.localScale.x / 2 + 3f;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}

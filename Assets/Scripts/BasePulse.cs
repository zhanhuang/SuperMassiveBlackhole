using UnityEngine;
using System.Collections;

public class BasePulse : MonoBehaviour {

	Material pulseMat;

	// Use this for initialization
	void Start () {
		pulseMat = transform.GetComponent<Renderer>().material;

	}
	
	// Update is called once per frame
	void Update () {
		AnimationState state = transform.GetComponent<Animation>()["Take 001"];
		float animationTime = state.time;

		Color baseColor = pulseMat.GetColor("_TintColor");
		pulseMat.SetColor("_TintColor", new Color(baseColor.r,baseColor.g, baseColor.b, Mathf.Clamp01(.85f - (animationTime % state.length)/state.length)));
	}
}

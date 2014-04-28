using UnityEngine;
using System.Collections;

public class Loot : MonoBehaviour {
	public string lootType;
	public int lootValue = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.transform.GetComponent<PlayerShipController>().GetLoot(lootType, lootValue);
			// play sound here



			lootValue = -1;
			if(renderer != null){
				renderer.enabled = false;
			}
			foreach(Renderer childRenderer in transform.GetComponentsInChildren<Renderer>()){
				childRenderer.enabled = false;
			}
			Destroy(gameObject, 2f);
		}
	}
}

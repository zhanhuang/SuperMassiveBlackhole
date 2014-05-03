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
			if(other.transform.GetComponent<PlayerShipController>().GetLoot(lootType, lootValue)){
				Destroy(gameObject);
			}
		}
	}
}

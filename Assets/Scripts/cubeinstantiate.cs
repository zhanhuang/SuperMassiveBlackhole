using UnityEngine;
using System.Collections;

public class cubeinstantiate : MonoBehaviour {
	public GameObject soundBlock;
	int blockcount = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (blockcount < 20) {
			GameObject block = (GameObject)Instantiate (soundBlock, new Vector3 (Random.Range (-10f, 10f), 1.5f, Random.Range (-10f, 10f)), Quaternion.identity);
			block.GetComponent<triggersound>().randomsound = Random.Range (1, 10);
			blockcount +=1;

				}
	}
}

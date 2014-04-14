using UnityEngine;
using System.Collections;

public class triggersound : MonoBehaviour {
	public AudioClip sound1;
	public AudioClip sound2;
	public AudioClip sound3;
	public AudioClip sound4;
	public AudioClip sound5;
	public AudioClip sound6;
	public AudioClip sound7;
	public AudioClip sound8;
	public AudioClip sound9;
	public AudioClip sound10;
	public int randomsound;
	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player"){
			if(randomsound == 1){
				audio.Stop();
				audio.PlayOneShot(sound1);
				Destroy (gameObject, sound1.length);
			}
			if(randomsound == 2){
				audio.Stop();
				audio.PlayOneShot(sound2);
				Destroy (gameObject, sound2.length);
			}
			if(randomsound == 3){
				audio.Stop();
				audio.PlayOneShot(sound3);
				Destroy (gameObject, sound3.length);
			}
			if(randomsound == 4){
				audio.Stop();
				audio.PlayOneShot(sound4);
				Destroy (gameObject, sound4.length);
			}
			if(randomsound == 5){
				audio.Stop();
				audio.PlayOneShot(sound5);
				Destroy (gameObject, sound5.length);

			}
			if(randomsound == 6){
				audio.Stop();
				audio.PlayOneShot(sound6);
				Destroy (gameObject, sound6.length);
			}
			if(randomsound == 7){
				audio.Stop();
				audio.PlayOneShot(sound7);
				Destroy (gameObject, sound7.length);
			}
			if(randomsound == 8){
				audio.Stop();
				audio.PlayOneShot(sound8);
				Destroy (gameObject, sound8.length);
			}
			if(randomsound == 9){
				audio.Stop();
				audio.PlayOneShot(sound9);
				Destroy (gameObject, sound9.length);
			}
			if(randomsound == 10){
				audio.Stop();
				audio.PlayOneShot(sound10);
				Destroy (gameObject, sound10.length);
			}
			GetComponent<SphereCollider>().enabled = false;
			GetComponent<MeshRenderer>().enabled = false;

		}
	}
}

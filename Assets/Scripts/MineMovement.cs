using UnityEngine;
using System.Collections;

public class MineMovement : MonoBehaviour {
	public string mineOrigin;
	GameObject Explosion;

	Transform trackingTarget;
	bool tracking = false;
	float trackingRange = 0f;

	Material targetMat;
	Color origColor;

	// Use this for initialization
	void Start () {
		Explosion = (GameObject)Resources.Load ("Explosion_Mine");
		trackingRange = transform.GetComponent<SphereCollider>().radius * 2f;
		targetMat = transform.FindChild("Mine").renderer.material;
		origColor = targetMat.color;
	}
	
	// Update is called once per frame
	void Update () {
		if(tracking && trackingTarget != null){
			float dist = Vector3.Distance(trackingTarget.position, transform.position);
			if(dist < 1f){
				StopCoroutine("TrackingFlash");
				Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
				Destroy(gameObject);
			} else if(dist > trackingRange){
				StopCoroutine("TrackingFlash");
				tracking = false;
				trackingTarget = null;
				targetMat.color = origColor;
			} else{
				// track down enemy
				transform.position += (trackingTarget.position - transform.position).normalized * Time.deltaTime * 10f;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if(tracking && trackingTarget != null){
			return;
		}
		// explode upon hitting structure or planet surface, explosion deals damage
		if(other.tag == "Shield" && mineOrigin == "Player"){
			return;
		} else if(mineOrigin == "Player" && other.tag == "Enemy"){
			if(other.transform.GetComponent<EnemyShipAI>() != null){
				// enemy ship found. start tracking
				tracking = true;
				trackingTarget = other.transform;
				StartCoroutine("TrackingFlash");
			}
		} else if(mineOrigin == "Enemy" && (other.tag == "Player" || other.tag == "Ally")){
			Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
			Destroy(gameObject);
		} else if(other.transform.GetComponent<LaserBehavior>() != null && other.transform.GetComponent<LaserBehavior>().laserOrigin == "Player" && mineOrigin == "Enemy"){
			// player can shoot down enemy mines
			Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
			Destroy(gameObject);
		} else if(other.transform.GetComponent<MineExplosion>() != null){
			// chain explosion for mines
			Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
			Destroy(gameObject);
		}
	}
	
	
	IEnumerator TrackingFlash(){
		while(true){
			targetMat.color = Color.red;
			yield return new WaitForSeconds(0.2f);
			targetMat.color = origColor;
			yield return new WaitForSeconds(0.2f);
		}
	}
}

using UnityEngine;
using System.Collections;

public class PortalPower : MonoBehaviour {
	bool flashing;
	int health = 10;

	public PortalScript portal1;
	public PortalScript portal2;
	
	GameObject Explosion;

	// Use this for initialization
	void Start () {
		Explosion = (GameObject)Resources.Load("Explosion_Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage(int damage){
		if(health <= 0){
			return;
		}
		health -= damage;
		if(health <= 0){
			portal1.LosePower();
			portal2.LosePower();

			Destroy(Instantiate (Explosion, transform.position, transform.rotation), 2f);
			Destroy(gameObject);
		} else{
			if(!flashing){
				flashing = true;
				StartCoroutine(DamageFlash());
			}
		}
	}
	
	
	IEnumerator DamageFlash(){
		Material targetMat = transform.FindChild("pCylinder1").renderer.materials[0];
		Color origColor = targetMat.color;
		targetMat.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		targetMat.color = origColor;
		yield return new WaitForSeconds(0.05f);
		targetMat.color = Color.white;
		yield return new WaitForSeconds(0.1f);
		targetMat.color = origColor;
		flashing = false;
	}
}

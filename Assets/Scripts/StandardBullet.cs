using UnityEngine;
using System.Collections;

public class StandardBullet : MonoBehaviour {

	private bool active; //Can hurt tanks when active
	public float damage;
	public float decay;

	// Use this for initialization
	void Start () {
		active = true;
		gameObject.GetComponent<TrailRenderer>().material.SetColor("_Color", Color.yellow);
	}

	void OnEnable() {
		tag = "Bullet";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider Target){
		if (Target.collider.tag == "Tank" && active) {
			Transform tank = Target.transform.parent;
			while(tank.parent != null){
				tank = tank.parent;
			}
			tank.GetComponent<Tank>().Hurt(damage);
			active = false;
		}
		if (Target.collider.tag == "Ground") {
			damage -= decay;
			if (damage<0f){
				damage = 0f;
			}
		}
	}
}

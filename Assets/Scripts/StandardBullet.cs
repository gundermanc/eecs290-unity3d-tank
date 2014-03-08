using UnityEngine;
using System.Collections;

public class StandardBullet : MonoBehaviour {

	private bool active; //Can hurt tanks when active

	// Use this for initialization
	void Start () {
		active = true;
		gameObject.GetComponent<TrailRenderer>().material.SetColor("_Color", Color.yellow);
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
			tank.GetComponent<Tank>().Hurt(10);
			active = false;
		}
		if (Target.collider.tag == "Ground") {
			active = false;
		}
	}
}

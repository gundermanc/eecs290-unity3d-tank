using UnityEngine;
using System.Collections;

public class ClusterBomb : MonoBehaviour {

	private bool active; //Can hurt tanks when active
	public GameObject bullet;
	public int numberOfBullets;

	// Use this for initialization
	void Start () {
		active = true;
		gameObject.GetComponent<TrailRenderer>().material.SetColor("_Color", Color.yellow);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision collision) {
		Vector3 dir;
		if (collision.collider.tag == "Ground") {
			dir = new Vector3 (0, 1, 0);
		} else {
			ContactPoint contact = collision.contacts[0];
			dir = contact.normal.normalized;
		}
		for (int shot = 0; shot < numberOfBullets; shot++) {
			Vector3 randdir = new Vector3(dir.x + Random.Range(-100, 100)/1000f, dir.y + Random.Range(-100, 100)/1000f, dir.z + Random.Range(-100, 100)/1000f).normalized;
			GameObject b = Instantiate (bullet, gameObject.transform.position + randdir*0.5f, Quaternion.identity) as GameObject;
			b.rigidbody.AddForce (randdir * 300);
		}
		Destroy(gameObject);
	}
}

using UnityEngine;
using System.Collections;

public class CameraStabilizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerpos = GameObject.Find ("TankPlayer").GetComponent<Transform>().position;
		Vector3 playerbackwards = -GameObject.Find ("TankPlayer").GetComponent<Transform> ().forward;
		playerbackwards.y = 0;
		playerbackwards.Normalize ();
		playerpos += 5*playerbackwards;
		playerpos.y += 2;
		transform.position = playerpos;
		transform.rotation = Quaternion.Euler (10,
		                                       GameObject.Find ("TankPlayer").GetComponent<Transform> ().eulerAngles.y,
		                                       GameObject.Find ("TankPlayer").GetComponent<Transform> ().eulerAngles.z);	
	}
}

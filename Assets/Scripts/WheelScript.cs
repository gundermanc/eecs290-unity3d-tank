using UnityEngine;
using System.Collections;

public class WheelScript : MonoBehaviour {

	void OnTriggerEnter(){
		transform.parent.parent.GetComponent<PlayerScript>().TouchingGround(true);
	}

	void OnTriggerStay(){
		transform.parent.parent.GetComponent<PlayerScript>().TouchingGround(true);
	}

	void OnTriggerExit(){
		transform.parent.parent.GetComponent<PlayerScript>().TouchingGround(false);
	}
}

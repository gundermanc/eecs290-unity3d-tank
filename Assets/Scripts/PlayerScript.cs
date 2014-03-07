using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float VerticalSpeed; // This is the movement speed that will be applied forward and backward to the tank
	public float RotationalSpeed; // This is the rotation speed that will be applied to turn the tank left and right
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/**
		 * Checking the forward/backward input axis to drive the tank forward or backwards
		 * Adds a simple force to the tank in the desired direction
		 * If the Vertical axis is positive that means the tank should forwards
		 * Else if it is nevative then the tank should move backwards
		 */
		if(Input.GetAxis("Vertical") > 0){
				rigidbody.AddForce(transform.forward*VerticalSpeed);
		} else if(Input.GetAxis("Vertical") < 0) {
			rigidbody.AddForce(transform.forward*(-1*VerticalSpeed));
		}

		/**
		 * Checking the left/right input axis to turn the tank in the desired direction
		 * Adds a torque to the tank in the desired direction
		 * If the axis is positive then we turn the tank right
		 * If the axis is negative then we turn the tank left
		 */
		if(Input.GetAxis("Horizontal") > 0){
			rigidbody.AddTorque((new Vector3(0f, 1f, 0f))*RotationalSpeed);
		} else if(Input.GetAxis("Horizontal") < 0){
			rigidbody.AddTorque((new Vector3(0f,-1f, 0f))*RotationalSpeed);
		}
	}
}

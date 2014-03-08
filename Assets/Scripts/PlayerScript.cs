using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float VerticalSpeed; // This is the movement speed that will be applied forward and backward to the tank
	public float RotationalSpeed; // This is the rotation speed that will be applied to turn the tank left and right
	// Use this for initialization
	void Start () {
		rigidbody.mass = 1f;
		rigidbody.maxAngularVelocity  = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		/**
		 * Checking the forward/backward input axis to drive the tank forward or backwards
		 * Adds a simple force to the tank in the desired direction
		 * If the Vertical axis is positive that means the tank should forwards
		 * Else if it is nevative then the tank should move backwards
		 */
		if (Input.GetAxis ("Vertical") > 0) {
			rigidbody.drag = 0f;
			rigidbody.AddForce (transform.forward * VerticalSpeed);
		} else if (Input.GetAxis ("Vertical") < 0) {
			rigidbody.drag = 0f;
			rigidbody.AddForce (transform.forward * (-1 * VerticalSpeed));
		} else {
			rigidbody.drag = 3f;
		}

		/**
		 * Checking the left/right input axis to turn the tank in the desired direction
		 * Adds a torque to the tank in the desired direction
		 * If the axis is positive then we turn the tank right
		 * If the axis is negative then we turn the tank left
		 */
		if (Input.GetAxis ("Horizontal") > 0) {
			rigidbody.angularDrag = 0.05f;
			rigidbody.AddTorque ((new Vector3 (0f, 1f, 0f)) * RotationalSpeed);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			rigidbody.angularDrag = 0.05f;
			rigidbody.AddTorque ((new Vector3 (0f, -1f, 0f)) * RotationalSpeed);
		} else {
			rigidbody.angularDrag = 10f;
		}
	}
}

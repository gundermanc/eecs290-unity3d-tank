﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float VerticalSpeed; // This is the movement speed that will be applied forward and backward to the tank
	public float RotationalSpeed; // This is the rotation speed that will be applied to turn the tank left and right
	public GameObject normalProjectile; // Basic weapon. Infinite ammo.
	public GameObject specialProjectile; // Special weapon. Limited ammo.
	public int specialProjectileAmmo; // Amount of special weapon shots.
	public bool IsTouchingGround;
	
	private Vector3 RotationVector;
	private Quaternion RotationQuaternion;
	private bool ThirdPersonMode;
	
	// Use this for initialization
	void Start () {
		//rigidbody.mass = 1f;
		//rigidbody.maxAngularVelocity  = 5f;
		ThirdPersonMode = true;
	}
	
	// Update is called once per frame
	void Update () {
		/**
		 * Checking the forward/backward input axis to drive the tank forward or backwards
		 * Adds a simple force to the tank in the desired direction
		 * If the Vertical axis is positive that means the tank should forwards
		 * Else if it is nevative then the tank should move backwards
		 */
		if(IsTouchingGround){
			if (Input.GetAxis ("Vertical") > 0) {
				// Changed from addForce to velocity, there is 0 acceleration but it kinda works nicer for now
				rigidbody.velocity = (transform.forward * VerticalSpeed);
			} else if (Input.GetAxis ("Vertical") < 0) {
				rigidbody.velocity = (transform.forward * (-1 * VerticalSpeed));
			} else {
				rigidbody.velocity = (transform.forward * 0f);
			}
		}
		
		/**
		 * Checking the left/right input axis to turn the tank in the desired direction
		 * Adds a torque to the tank in the desired direction
		 * If the axis is positive then we turn the tank right
		 * If the axis is negative then we turn the tank left
		 */
		if (Input.GetAxis ("Horizontal") > 0) {
			//rigidbody.angularDrag = 0.05f;
			// Going to change this to a slerp and see how that goes
			
			
			// This will be the position before the rotation, plus a small added rotation around the y axis
			RotationVector = new Vector3(transform.eulerAngles.x, (transform.eulerAngles.y + RotationalSpeed), transform.eulerAngles.z);
			RotationQuaternion = Quaternion.Euler(RotationVector);
			transform.localRotation = (RotationQuaternion);
			
			
		} else if (Input.GetAxis ("Horizontal") < 0) {
			//rigidbody.angularDrag = 0.05f;

			// This is basically just a copy/paste but with a negative rotation for the opposite turn
			RotationVector = new Vector3(transform.eulerAngles.x, (transform.eulerAngles.y - RotationalSpeed), transform.eulerAngles.z);
			RotationQuaternion = Quaternion.Euler(RotationVector);
			transform.localRotation = (RotationQuaternion);
			
			
		} else {
			Vector3 RotationVector = new Vector3(0f,0f,0f);
			transform.Rotate(RotationVector);// * Time.deltaTime);
		}
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			Shoot (normalProjectile, 1000f);
		} else if (Input.GetKeyDown (KeyCode.Tab) && specialProjectileAmmo > 0) {
			Shoot(specialProjectile, 1000f);
			specialProjectileAmmo--;
		}
		
		if (Input.GetMouseButtonDown (0)) {
			Shoot (normalProjectile, 1000f);		
		} else if (Input.GetMouseButtonDown (1) && specialProjectileAmmo > 0) {
			Shoot (specialProjectile, 1000f);
			specialProjectileAmmo--;
		}

		if(Input.GetKeyDown(KeyCode.LeftShift)){
			// This means going to first person mode
			if(ThirdPersonMode){
				GameObject.Find("BarrelCamera").GetComponent<Camera>().depth = -1;
				ThirdPersonMode = false;
				// This means going to thrid person mode
			} else {
				GameObject.Find("BarrelCamera").GetComponent<Camera>().depth = -2;
				ThirdPersonMode = true;
			}
		}
	}
	
	/**
	 * Launches a projectile.
	 * @param projectileType: which prefab to shoot. Allows for multiple projectile types.
	 * @param power: how far the projectile should be launched.
	 */
	private void Shoot(GameObject projectileType, float power){
		Transform barrel = gameObject.transform.GetChild(3).GetChild(0).GetChild(0);
		GameObject projectile = Instantiate (projectileType, barrel.position + barrel.up.normalized * -2f, Quaternion.identity) as GameObject;
		projectile.rigidbody.AddForce ((-barrel.up).normalized * power);
	}

	public void TouchingGround(bool Correct){
		IsTouchingGround = Correct;
	}
}

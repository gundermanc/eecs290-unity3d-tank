using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CombatComponent : AIComponent {
	private EntityMemory memory;
	private float viewingAngleDegrees;
	private float viewingDistance;
	private float pursueSpeed;
	private AIResources resources;
	private GameObject bullet;
	private float firepower;
	private DateTime lastFireTime;
	private int reloadMillis;

	public CombatComponent (AIResources resources, float viewingAngleDegrees, float viewingDistance,
	                        float pursueSpeed, GameObject bullet, float firepower, int reloadMillis) {
		this.resources = resources;
		this.memory = new EntityMemory ();
		this.viewingAngleDegrees = viewingAngleDegrees;
		this.viewingDistance = viewingDistance;
		this.pursueSpeed = pursueSpeed;
		this.bullet = bullet;
		this.firepower = firepower;
		this.lastFireTime = DateTime.Now;
		this.reloadMillis = reloadMillis;
	}

	/** Work in progress */
	public void Think(EntityInterface npcInterface) {
		return;
	}

	public static bool EntitySeen(Vector3 observerPos, float observerRotation, Vector3 observeePos, 
	                              float viewingAngle, float viewingDistance) {
		// get direction from one to another
		Vector3 direction = (observeePos - observerPos).normalized;
		
		// calculate angle between NPC "eyes" and player location
		float npcAngle = Vector3.Angle (direction, 
		                                Quaternion.AngleAxis(observerRotation, Vector3.up) * new Vector3 (0, 0, -1));
		
		// is player in front and within viewing range
		if(GenericAI.Distance(observerPos, observeePos) <= viewingDistance
		   && npcAngle <= (viewingAngle / 2)) {
			return true;
		}

		// is really really close, regardless of the direction (if someone is RIGHT behind you, you should know.
		if(GenericAI.Distance(observerPos, observeePos) <= 7.0f) {
			return true;
		}

		return false;
	}

	private void Fire(EntityInterface npcInterface) {
		if(DateTime.Now.Subtract(this.lastFireTime).TotalMilliseconds >= reloadMillis) {

			npcInterface.SetEntityRotation(npcInterface.GetPlayerLocation());
			// fire bullets
			GameObject projectile = MonoBehaviour.Instantiate (bullet, npcInterface.GetEntityLocation() - npcInterface.GetEntityForward() * 2f + Vector3.up * .8f, Quaternion.identity) as GameObject;
			//Accelerate bullet in the proper direction
			projectile.rigidbody.AddForce ((npcInterface.GetEntityForward() + Vector3.up * .1f).normalized * -firepower);
			this.lastFireTime = DateTime.Now;
		}
	}

	public bool Act(EntityInterface npcInterface) {
		Vector3 playerLocation = npcInterface.GetPlayerLocation ();
		Vector3 npcLocation = npcInterface.GetEntityLocation();
		float npcRotation = npcInterface.GetEntityRotation ();


		if(EntitySeen(npcLocation, npcRotation, playerLocation, 
		              viewingAngleDegrees, viewingDistance)) {

			// check if opponent is far away, if so, get closer, don't fire yet
			if(GenericAI.Distance(npcLocation, playerLocation) > 15) {
				npcInterface.SetEntityLocation(GenericAI
			          .MovementVector(npcLocation, playerLocation, pursueSpeed));
				Debug.Log(pursueSpeed);
			} else {
				Fire (npcInterface);
			}
			return true;
		}

		return false;
	}
}
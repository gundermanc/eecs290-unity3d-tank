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
	private float maxFireDistance;

	public CombatComponent (AIResources resources, float viewingAngleDegrees, float viewingDistance,
	                        float pursueSpeed, GameObject bullet, float firepower, int reloadMillis,
	                        float maxFireDistance) {
		this.resources = resources;
		this.memory = new EntityMemory ();
		this.viewingAngleDegrees = viewingAngleDegrees;
		this.viewingDistance = viewingDistance;
		this.pursueSpeed = pursueSpeed;
		this.bullet = bullet;
		this.firepower = firepower;
		this.lastFireTime = DateTime.Now;
		this.reloadMillis = reloadMillis;
		this.maxFireDistance = maxFireDistance;
	}

	public void Think(EntityInterface npcInterface) {
		return;
	}

	private void Fire(EntityInterface npcInterface) {
		if(DateTime.Now.Subtract(this.lastFireTime).TotalMilliseconds >= reloadMillis) {

			npcInterface.SetEntityRotation(npcInterface.GetPlayerLocation());
			// fire bullets
			Transform barrel = npcInterface.GetEntityTransform().GetChild(2).GetChild(0);
			GameObject projectile = MonoBehaviour.Instantiate (bullet, barrel.position + barrel.up.normalized * -2f, Quaternion.identity) as GameObject;
			projectile.rigidbody.AddForce ((-barrel.up).normalized * firepower);
			this.lastFireTime = DateTime.Now;
		}
	}

	public bool Act(EntityInterface npcInterface) {
		Vector3 playerLocation = npcInterface.GetPlayerLocation ();
		Vector3 npcLocation = npcInterface.GetEntityLocation();
		float npcRotation = npcInterface.GetEntityRotation ();

		// if player is in sight, move in for attack
		if(GenericAI.EntitySeen(npcLocation, npcRotation, playerLocation, 
		              viewingAngleDegrees, viewingDistance)) {

			// check if opponent is far away, if so, get closer, don't fire yet
			if(GenericAI.Distance(npcLocation, playerLocation) > maxFireDistance) {
				npcInterface.SetEntityLocation(playerLocation, pursueSpeed);
			} else {
				Fire (npcInterface);
			}
			return true;
		}

		return false;
	}
}
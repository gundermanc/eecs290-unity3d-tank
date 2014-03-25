using UnityEngine;
using System;

/**
 * Manages enemy AI's awareness of the player. Keeps track of whether or not
 * they have seen the player. If so, the AI approaches the player. Once close
 * enough, the CombatComponent takes over and begins attack. Also, player last seen
 * position is STATIC so one one sees you, they all know where you were sighted last.
 * @author Christian Gunderman
 */
public class PursueComponent : AIComponent {
	private static bool playerLastPosKnown;
	private static Vector3 playerLastKnownLocation;
	private DateTime playerLastEncounterTime;
	private float viewingDistance;
	private float viewingAngle;
	private float maxAttackDistance;
	private float pursueSpeed;
	private float wanderAndPatrolSpeed;

	public PursueComponent(float viewingDistance, float viewingAngle, float maxAttackDistance,
	                       float pursueSpeed, float wanderAndPatrolSpeed) {
		playerLastPosKnown = false;
		this.viewingDistance = viewingDistance;
		this.viewingAngle = viewingAngle;
		this.maxAttackDistance = maxAttackDistance;
		this.pursueSpeed = pursueSpeed;
		this.wanderAndPatrolSpeed = wanderAndPatrolSpeed;
	}
	
	public void Think(EntityInterface npcInterface) {
		Vector3 npcLocation = npcInterface.GetEntityLocation ();
		Vector3 playerLocation = npcInterface.GetPlayerLocation ();
		float npcRotation = npcInterface.GetEntityRotation ();

		/* if player is in visual range of NPC */
		if(GenericAI.EntitySeen(npcLocation, npcRotation, playerLocation, 
			                       this.viewingAngle, this.viewingDistance)) {

			/* save encounter details */
			playerLastPosKnown = true;
			playerLastKnownLocation = playerLocation;
			this.playerLastEncounterTime = DateTime.Now;
		} else if(DateTime.Now.Subtract(playerLastEncounterTime).TotalSeconds > 10) {

			/* it has been 10 seconds, forget about player */
			playerLastPosKnown = false;
		}
	}



	public bool Act(EntityInterface npcInterface) {
		Vector3 npcLocation = npcInterface.GetEntityLocation ();
		Vector3 playerLocation = npcInterface.GetPlayerLocation ();
		float npcRotation = npcInterface.GetEntityRotation ();

		/* if player is in visual range of NPC */
		if (GenericAI.EntitySeen(npcLocation, npcRotation, playerLocation, 
		                        this.viewingAngle, this.viewingDistance)) {

			/* if we are close enough, let the next component handle the situation */
			if(GenericAI.Distance(playerLocation, npcLocation) <= this.maxAttackDistance) {
				return false;
			} else {
				/* too far away, get closer to the player */
				npcInterface.SetEntityLocation(playerLocation, pursueSpeed);
				return true; // this component handled the situation
			}
		} else if(playerLastPosKnown) {
			// we have a previous lock on the target:
			// are we there yet? if not, approach that point.
			if(GenericAI.Distance(npcLocation, playerLastKnownLocation) > 1) {
				npcInterface.SetEntityLocation(playerLastKnownLocation, wanderAndPatrolSpeed);
				return true; // this component handled the situation
			} else {
				// we are to the player's last known location, look around till we find player
				npcInterface.SetEntityRotation (1);
				return true;
			}
		}
		return false;
	}
}

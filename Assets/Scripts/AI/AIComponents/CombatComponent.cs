using UnityEngine;
using System.Collections;

public class CombatComponent : MonoBehaviour, AIComponent {
	private EntityMemory memory;
	private float viewingAngleDegrees;
	private float viewingDistance;
	private float purseSpeed;
	private AIResources resources;
	private GameObject bullet;
	private float firepower;

	public CombatComponent (AIResources resources, float viewingAngleDegrees, float viewingDistance,
	                        float pursueSpeed, GameObject bullet, float firepower) {
		this.resources = resources;
		this.memory = new EntityMemory ();
		this.viewingAngleDegrees = viewingAngleDegrees;
		this.viewingDistance = viewingDistance;
		this.purseSpeed = purseSpeed;
		this.bullet = bullet;
		this.firepower = firepower;
	}

	/** Work in progress */
	public void Think(EntityInterface npcInterface) {
		Vector3 playerLocation = npcInterface.GetPlayerLocation ();
		Vector3 npcLocation = npcInterface.GetEntityLocation();
		float npcRotation = npcInterface.GetEntityRotation ();

		// check if player seen
		if(EntitySeen(npcLocation, npcRotation, playerLocation, 
		              viewingAngleDegrees, viewingDistance)) {

			// we saw the player, save its location so we can decide what to do in the Act() function.
			this.memory.ObservedEntity("player", playerLocation);
			Debug.Log("Enemy saw you.");
		}
	}

	public static bool EntitySeen(Vector3 observerPos, float observerRotation, Vector3 observeePos, 
	                              float viewingAngle, float viewingDistance) {
		// get direction from one to another
		Vector3 direction = (observeePos - observerPos).normalized;
		
		// calculate angle between NPC "eyes" and player location
		float npcAngle = Mathf.Abs (Vector3.Angle (direction, new Vector3 (0, 0, -1))
		                            - observerRotation);
		
		// was player seen?
		if(GenericAI.Distance(observerPos, observeePos) <= viewingDistance
		   && npcAngle <= (viewingAngle / 2)) {
			return true;
		}

		return false;
	}

	public bool Act(EntityInterface npcInterface) {
		EntityMemory.Encounter encounter = null;
		float prevDistance = float.MaxValue;
		Vector3 opponentLocation = Vector3.zero;

		// find the closest opponent
		// SHOULD iterate through list of items seen and pick the closest but not working :(
		foreach (DictionaryEntry e in this.memory.encounters) {
			EntityMemory.Encounter e2 = (EntityMemory.Encounter)e.Value;
			float distance = GenericAI.Distance(e2.lastLocation, npcInterface.GetEntityLocation());
			if(distance < prevDistance) {
				encounter = e2;
				opponentLocation = e2.lastLocation;
			}
		}

		// if there was an item seen, do some stuff
		if(encounter != null) {
			Debug.Log("Enemy Acting.");
			// check if opponent is far away, if so, get closer
			if(GenericAI.Distance(npcInterface.GetEntityLocation(), opponentLocation) > 30) {
				npcInterface.SetEntityLocation (GenericAI
				       .MovementVector(npcInterface.GetEntityLocation(), opponentLocation, purseSpeed));
			//opponent is close
			} else {
				//Face enemy
				npcInterface.SetEntityRotation(opponentLocation);
				//Create bullet GameObject
				GameObject projectile = Instantiate (bullet, npcInterface.GetEntityLocation() - npcInterface.GetEntityForward() * 2f + Vector3.up * .8f, Quaternion.identity) as GameObject;
				//Accelerate bullet in the proper direction
				projectile.rigidbody.AddForce ((npcInterface.GetEntityForward() + Vector3.up * .1f).normalized * -firepower);
			}
		}
		return false;
	}

}
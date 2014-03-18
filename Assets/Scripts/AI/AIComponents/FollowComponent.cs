using UnityEngine;
using System.Collections;

/**
 * AI Component that causes the NPC to follow the player. This is useful for both
 * friendlies and enemies since you want friends to have your back and enemies
 * to get in your face.
 * @author Christian Gunderman
 * @author cdg46
 */
public class FollowComponent : AIComponent {

	private float stoppingDistance;
	private float speed;

	/**
	 * Initializes component.
	 * @param stoppingDistance NPC stops approaching when they are this distance
	 * from the player.
	 * @param speed The rate at which the NPC approaches the player.
	 */
	public FollowComponent(float stoppingDistance, float speed) {
		this.stoppingDistance = stoppingDistance;
		this.speed = speed;
	}

	/**
	 * None required.
	 */
	public void Think(EntityInterface npcInterface) {
		return;
	}

	/**
	 * If the player is outside of the stopping distance zone, head toward him.
	 * @param npcInterface An interface containing the NPC controls and the 
	 * player position.
	 */
	public bool Act(EntityInterface npcInterface) {
		Vector3 oldPos = npcInterface.GetEntityLocation ();
		Vector3 playerPos = npcInterface.GetPlayerLocation ();
		if(GenericAI.Distance(oldPos, playerPos) 
		   > this.stoppingDistance) {

			npcInterface.SetEntityLocation (GenericAI.MovementVector(oldPos, playerPos, speed));

			// end component cascade here
			return true;
		}

		// pass control onto next component
		return false;
	}
}

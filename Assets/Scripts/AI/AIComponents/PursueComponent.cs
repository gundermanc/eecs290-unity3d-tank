using UnityEngine;
using System.Collections;

/**
 * AI Component that causes the NPC to purse the player. This is useful for both
 * friendlies and enemies since you want friends to have your back and enemies
 * to get in your face.
 * @author Christian Gunderman
 * @author cdg46
 */
public class PursueComponent : AIComponent {

	private float stoppingDistance;
	private float speed;

	/**
	 * Initializes component.
	 * @param stoppingDistance NPC stops approaching when they are this distance
	 * from the player.
	 * @param speed The rate at which the NPC approaches the player.
	 */
	public PursueComponent(float stoppingDistance, float speed) {
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
		Vector3 oldPos = npcInterface.GetPointLocation ();
		Vector3 playerPos = npcInterface.GetPlayerLocation ();
		if(GenericAI.Distance(oldPos, playerPos) 
		   > this.stoppingDistance) {

			Vector3 newPos = new Vector3 (oldPos.x, oldPos.y, oldPos.z);
			if(Mathf.Abs(newPos.x - playerPos.x) > 0.5f) {
				if(newPos.x < playerPos.x) {
					newPos.x+=.05f*speed;
				} else if(newPos.x > playerPos.x) {
					newPos.x-=.05f*speed;
				}
			}
			
			if(Mathf.Abs(newPos.z - playerPos.z) > 0.5f) {
				if(newPos.z < playerPos.z) {
					newPos.z+=.05f*speed;
				} else if(newPos.z > playerPos.z) {
					newPos.z-=.05f*speed;
				}
			}
			npcInterface.SetPointLocation (newPos);

			// we were too far away and got closer
			return true;
		}

		// pass control onto next component
		return false;
	}
}

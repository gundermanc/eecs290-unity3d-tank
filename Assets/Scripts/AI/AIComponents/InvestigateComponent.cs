using UnityEngine;
using System.Collections;

/**
 * An AI component that causes the NPC to investigate a point that it thinks the player might be by.
 * @author Kai Smith
 * @author kjs108
 */
public class InvestigateComponent : AIComponent {
	
	/** Place where the tank will check out. */
	private Vector3 target;
	private float speed;
	
	/**
	 * Instantiates component.
	 * @param territory Series of points that the tank will patrol through.
	 * @param startIndex First point to visit.
	 */
	public InvestigateComponent(Vector3 target, float speed) {
		this.target = target;
		this.speed = speed;
	}
	
	/**
	 * Check if we reached our current goal. If so, progess to next one.
	 * @param npcInterface The controls for the NPC.
	 */
	public void Think(EntityInterface npcInterface) {

		return;
	}

	/**
	 * Update for this frame. Check if we are near our destination. If not, 
	 * move closer.
	 */
	public bool Act(EntityInterface npcInterface) {
		//npcInterface.SetEntityLocation (GenericAI.MovementVector(npcInterface.GetEntityLocation (),
		//	                                                         territory[target], this.speed));
		
		return true;
	}
}

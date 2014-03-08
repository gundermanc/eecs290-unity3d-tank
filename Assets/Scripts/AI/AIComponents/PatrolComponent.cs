using UnityEngine;
using System.Collections;

/**
 * An AI component that causes the NPC to patrol points that it considers
 * to be its territory.
 * @author Christian Gunderman
 * @author cdg46
 */
public class PatrolComponent : AIComponent {
	
	/** Series of "spots of interest" between which the Tank will patrol. */
	private Vector3[] territory;
	/** The index of the current point being pursued */
	private int target;
	private float speed;
	
	/**
	 * Instantiates component.
	 * @param territory Series of points that the tank will patrol through.
	 * @param startIndex First point to visit.
	 */
	public PatrolComponent(Vector3[] territory, int startIndex, float speed) {
		this.territory = territory;
		this.speed = speed;
		target = startIndex;
		NextTarget ();
	}
	
	/**
	 * Check if we reached our current goal. If so, progess to next one.
	 * @param npcInterface The controls for the NPC.
	 */
	public void Think(EntityInterface npcInterface) {
		/* if we have reached our target, generate a new target */
		if(GenericAI.Distance(npcInterface.GetEntityLocation(), territory[target]) <= 1.0f) {
			NextTarget();
		}
		return;
	}
	
	/**
	 * Advance to next desired location.
	 */
	private void NextTarget() {
		target++;
		if(target == territory.Length) {
			target = 0;
		}
	}
	
	/**
	 * Update for this frame. Check if we are near our destination. If not, 
	 * move closer.
	 */
	public bool Act(EntityInterface npcInterface) {
		npcInterface.SetEntityLocation (GenericAI.MovementVector(npcInterface.GetEntityLocation (),
		                                                        territory[target], this.speed));
		
		return true;
	}
}
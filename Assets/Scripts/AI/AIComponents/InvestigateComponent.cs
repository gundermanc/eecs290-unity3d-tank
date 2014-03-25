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
	private int lasthealth;
	private int currhealth;
	private float timehit;
	
	/**
	 * Instantiates component.
	 * @param territory Series of points that the tank will patrol through.
	 * @param startIndex First point to visit.
	 */
	public InvestigateComponent(float speed) {
		this.target = new Vector3(0,0,0);
		this.speed = speed;
		timehit = -100f;
	}
	
	/**
	 * Check if we reached our current goal. If so, progess to next one.
	 * @param npcInterface The controls for the NPC.
	 */
	public void Think(EntityInterface npcInterface) {
		if (npcInterface.GetEntityHealth () != currhealth) {
			currhealth = npcInterface.GetEntityHealth();
			timehit = Time.timeSinceLevelLoad;
			target = npcInterface.GetPlayerLocation();
		}
		return;
	}

	/**
	 * Update for this frame. Check if we are near our destination. If not, 
	 * move closer.
	 */
	public bool Act(EntityInterface npcInterface) {
		if (Time.timeSinceLevelLoad - timehit < 10f) {
			npcInterface.SetEntityLocation (target, this.speed);
			return true;
		}
		return false;
	}
}

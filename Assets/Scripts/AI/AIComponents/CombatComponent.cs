using UnityEngine;

public class CombatComponent : AIComponent {
	private EntityMemory memory;
	private float viewingAngleDegrees;
	private float viewingDistance;

	public CombatComponent (float viewingAngleDegrees, float viewingDistance) {
		this.memory = new EntityMemory ();
		this.viewingAngleDegrees = viewingAngleDegrees;
		this.viewingDistance = viewingDistance;
	}

	/** Work in progress */
	public void Think(EntityInterface npcInterface) {
		Vector3 playerLocation = npcInterface.GetPlayerLocation ();
		Vector3 npcLocation = npcInterface.GetPointLocation ();
		Transform t;

	}

	public bool Act(EntityInterface npcInterface) {
		return false;
	}
}
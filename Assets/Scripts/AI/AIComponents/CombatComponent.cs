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
		Vector3 npcLocation = npcInterface.GetEntityLocation ();
		Vector3 direction = (playerLocation - npcLocation).normalized;

		Vector3 npcOrientation = new Vector3 (0, 0, -1);

		//Debug.LogWarning (Mathf.Abs (Vector3.Angle (direction, npcOrientation)) + Mathf.Abs(npcInterface.GetEntityRotation()));
	}

	public bool Act(EntityInterface npcInterface) {
		return false;
	}
}
using UnityEngine;
using System.Collections;

/**
 * An AI component that causes the NPC to "wander" to random points within the 
 * rectangles that it considers to be its territory.
 * @author Christian Gunderman
 * @author cdg46
 */
public class WanderComponent : AIComponent {

	private Rect territory;
	private Vector3 target = new Vector3();
	private float speed;

	public WanderComponent(Rect territory, float speed) {
		this.territory = territory;
		this.speed = speed;
		PickTarget ();
	}

	public void Sense() {
		return;
	}

	public void Think(EntityInterface npcInterface) {
		/* if we have reached our target, generate a new target */
		if(GenericAI.Distance(npcInterface.GetPointLocation(), target) <= 1.0f) {
			PickTarget();
		}
		return;
	}

	private void PickTarget() {
		Vector3 newTarget = new Vector3();
		do {
			/* select a random point within */
			newTarget.x = Random.Range (territory.x, territory.x + territory.width);
			newTarget.z = Random.Range (territory.y, territory.y + territory.height);
			Debug.LogWarning ("Picked (" + target.x + ", " + target.z + ")");
		} while (GenericAI.Distance(target, newTarget) < 5);

		target = newTarget;
	}

	public bool Act(EntityInterface npcInterface) {
		Vector3 oldPos = npcInterface.GetPointLocation ();
		Vector3 newPos = new Vector3 (oldPos.x, oldPos.y, oldPos.z);
		//Debug.LogWarning (Distance(target, oldPos));
		if(Mathf.Abs(newPos.x - target.x) > 0.5f) {
			if(newPos.x < target.x) {
				newPos.x += .05f * speed;
			} else if(newPos.x > target.x) {
				newPos.x -= .05f * speed;
			}
		}

		if(Mathf.Abs(newPos.z - target.z) > 0.5f) {
			if(newPos.z < target.z) {
				newPos.z += .05f * speed;
			} else if(newPos.z > target.z) {
				newPos.z -= .05f * speed;
			}
		}
		npcInterface.SetPointLocation (newPos);

		return true;
	}
}

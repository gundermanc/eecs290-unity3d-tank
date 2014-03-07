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

	public WanderComponent(Rect territory) {
		this.territory = territory;
		PickTarget ();
	}

	public void Sense() {
		return;
	}

	public void Think(EntityInterface npcInterface) {
		/* if we have reached our target, generate a new target */
		if(Distance(npcInterface.GetPointLocation(), target) <= 3) {
			PickTarget();
		}
		return;
	}

	private void PickTarget() {

		/* select a random point within */
		target.x = Random.Range (territory.x, territory.x + territory.width);
		target.z = Random.Range (territory.y, territory.y + territory.height);
		Debug.LogWarning ("Picked (" + target.x + ", " + target.z + ")");
	}

	private float Distance(Vector3 v1, Vector3 v2) {
		return Mathf.Sqrt (Mathf.Pow ((v1.x - v2.x), 2) + Mathf.Pow ((v1.y - v2.y), 2) + Mathf.Pow ((v1.z - v2.z), 2));
	}

	public bool Act(EntityInterface npcInterface) {
		Vector3 oldPos = npcInterface.GetPointLocation ();
		Vector3 newPos = new Vector3 (oldPos.x, oldPos.y, oldPos.z);
		//Debug.LogWarning (Distance(target, oldPos));
		if(newPos.x < target.x) {
			newPos.x+=.05f;
		} else if(newPos.x > target.x) {
			newPos.x-=.05f;
		}
		if(newPos.z < target.z) {
			newPos.z+=.05f;
		} else if(newPos.z > target.z) {
			newPos.z-=.05f;
		}
		npcInterface.SetPointLocation (newPos);

		return true;
	}
}

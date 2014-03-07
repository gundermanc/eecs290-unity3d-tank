using UnityEngine;
using System.Collections;

/**
 * Interface that defines functions that the AI will use to manipulate the
 * NPC that it is controlling.
 * @author Christian Gunderman
 * @author cdg46
 */
public interface EntityInterface {

	/**
	 * Calls to this function should make the entity in question move to
	 * location XY in its natural way (driving, walking, etc).
	 */
	void GoToXYNatural (float x, float z);

	void SetPointLocation(Vector3 location);
	Vector3 GetPointLocation();
}

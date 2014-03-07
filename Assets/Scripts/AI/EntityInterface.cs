using UnityEngine;
using System.Collections;

/**
 * Interface that defines functions that the AI will use to manipulate the
 * NPC that it is controlling.
 * @author Christian Gunderman
 * @author cdg46
 */
public interface EntityInterface {
	void SetPointLocation(Vector3 location);
	Vector3 GetPointLocation();
	Vector3 GetPlayerLocation();
}

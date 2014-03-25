using UnityEngine;
using System.Collections;

/**
 * Interface that defines functions that the AI will use to manipulate the
 * NPC that it is controlling.
 * @author Christian Gunderman
 * @author cdg46
 */
public interface EntityInterface {
	void SetEntityLocation(Vector3 location);
	Vector3 GetEntityLocation();
	float GetEntityRotation();
	Vector3 GetPlayerLocation();
	Vector3 GetEntityForward();
	void SetEntityRotation(Vector3 location);
	void SetEntityRotation(float rotation);
	Transform GetEntityTransform ();
	int GetEntityHealth();
}

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
	 * Sets the Point location of the tank.
	 */
	void SetPointLocation(Vector3 location);

	/**
	 * Gets the location of the tank.
	 */
	Vector3 GetPointLocation();
}

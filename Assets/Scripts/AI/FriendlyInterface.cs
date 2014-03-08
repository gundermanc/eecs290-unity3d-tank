using UnityEngine;
using System.Collections;

/**
 * Defines a series of interfaces that friendly game NPCs and characters
 * must implement to allow interaction by enemy AIs.
 * @author Christian Gunderman
 * @author cdg46
 */
public interface FriendlyInterface {
	Vector3 GetLocation();
	int GetID();
}

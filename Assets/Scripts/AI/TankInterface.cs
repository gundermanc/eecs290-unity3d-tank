using UnityEngine;

/**
 * Defines how the AI controls the tank.
 */
public class TankController : EntityInterface {
	private Transform transform;
	private Transform playerTransform;
	
	public TankController(Transform transform, Transform playerTransform) {
		this.transform = transform;
		this.playerTransform = playerTransform;
	}
	
	public void SetPointLocation(Vector3 location) {                
		this.transform.LookAt (2 * this.transform.position - location);
		this.transform.position = location;
	}
	
	public Vector3 GetPointLocation() {
		return this.transform.position;
	}
	
	public Vector3 GetPlayerLocation() {
		return playerTransform.position;
	}
}
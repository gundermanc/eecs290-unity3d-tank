using UnityEngine;
using System.Collections;

/**
 * The enemy tank AI. This class implements the GenericAI class and conforms
 * to its prototypes.
 * @author Christian Gunderman
 * @author cdg46
 */
public class EnemyTankAI : MonoBehaviour {

	public Rect bounds;
	public float wanderAndPatrolSpeed = 1.5f;
	public GameObject player;
	
	/* the GenericAI manager */
	private GenericAI ai;
	/* Controls the NPC and allows the AI to interface with it */
	private NPCInterface npcInterface;
	
	// Use this for initialization
	void Start () {
		this.npcInterface = new NPCInterface (transform, player.transform);

		/* the components for this AI module */
		this.ai = new GenericAI(new AIComponent[] {
			//new WanderComponent(bounds, wanderAndPatrolSpeed),
			new PursueComponent(10, 1.5f)
		}, this.npcInterface);
	}
	
	// Update is called once per frame
	void Update () {
		this.ai.Think ();
		this.ai.Act ();
	}

	/**
	 * Defines how the AI controls the tank
	 */
	private class NPCInterface : EntityInterface {
		private Transform transform;
		private Transform playerTransform;

		public NPCInterface(Transform transform, Transform playerTransform) {
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
}

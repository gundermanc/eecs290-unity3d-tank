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
	
	/* the GenericAI manager */
	private GenericAI ai;
	/* Controls the NPC and allows the AI to interface with it */
	private NPCInterface npcInterface;
	
	// Use this for initialization
	void Start () {
		this.npcInterface = new NPCInterface (transform);

		/* the components for this AI module */
		this.ai = new GenericAI(new WanderComponent[] {
			new WanderComponent(new Rect(bounds))
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

		public NPCInterface(Transform transform) {
			this.transform = transform;
		}

		public void SetPointLocation(Vector3 location) {                
			this.transform.LookAt (2 * this.transform.position - location);
			this.transform.position = location;
		}

		public Vector3 GetPointLocation() {
			return this.transform.position;
		}

		public void GoToXYNatural(float x, float z) {
			// = new Vector3 (x, transform.position.y, z);
		}
	}
}

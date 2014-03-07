using UnityEngine;
using System.Collections;

/**
 * The enemy tank AI. This class implements the GenericAI class and conforms
 * to its prototypes.
 * @author Christian Gunderman
 * @author cdg46
 */
public class EnemyTankAI : MonoBehaviour {

	/* PUBLIC PARAMS: */
	/* The bounds for this tank's territory. He can patrol in here when not aware of player */
	public Rect territory;
	
	/* the GenericAI manager */
	private GenericAI ai;
	/* Controls the NPC and allows the AI to interface with it */
	private NPCInterface npcInterface;
	
	// Use this for initialization
	void Start () {
		this.npcInterface = new NPCInterface (transform);

		/* the components for this AI module. order defines precedence */
		this.ai = new GenericAI(new AIComponent[] {
			new WanderComponent(new Rect(territory))
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
		/* stores the transform */
		private Transform transform;

		/**
		 * Creates an instance of the Tank controller
		 * @param transform The transform used to control the tank.
		 */
		public NPCInterface(Transform transform) {
			this.transform = transform;
		}

		/**
		 * Sets the Location of the tank, without animations. This should be called
		 * every Act method to perform the frame-by-frame update.
		 */
		public void SetPointLocation(Vector3 location) {

			// look where we are going
			this.transform.LookAt (2 * this.transform.position - location);

			// move
			this.transform.position = location;
		}

		/**
		 * Gets the tank's location
		 * @return The tank's location.
		 */
		public Vector3 GetPointLocation() {
			return this.transform.position;
		}
	}
}

using UnityEngine;
using System.Collections;

/**
 * The friendly tank AI. This class implements the GenericAI class and conforms
 * to its prototypes.
 * @author Christian Gunderman
 * @author cdg46
 */
public class FriendlyTankAI : MonoBehaviour, FriendlyInterface {

	public Rect bounds;
	public float wanderAndPatrolSpeed = 1.0f;
	public float pursuitSpeed = 2.0f;
	public GameObject player;
	
	/* the GenericAI manager */
	private GenericAI ai;
	/* Controls the NPC and allows the AI to interface with it */
	private TankController npcInterface;
	
	// Use this for initialization
	void Start () {
		this.npcInterface = new TankController (transform, player.transform);

		/* the components for this AI module */
		this.ai = new GenericAI(new AIComponent[] {
			//new WanderComponent(bounds, wanderAndPatrolSpeed),
			new PursueComponent(10, pursuitSpeed)
		}, this.npcInterface);
	}
	
	// Update is called once per frame
	void Update () {
		this.ai.Think ();
		this.ai.Act ();
	}

	public Vector3 GetLocation() {
		return transform.position;
	}

	public int GetID() {
		return transform.GetInstanceID ();
	}
}

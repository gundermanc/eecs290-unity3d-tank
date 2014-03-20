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
	public float wanderAndPatrolSpeed = 1.0f;
	public float pursuitSpeed = 2.0f;
	public GameObject player;
	public GameObject bullet;
	public float firepower;
	public float viewingAngle = 90;
	public float viewingDistance = 25;
	public int reloadTimeMillis = 1000;
	public float maxAttackDistance = 15;
	
	/* the GenericAI manager */
	private GenericAI ai;
	/* Controls the NPC and allows the AI to interface with it */
	private TankController npcInterface;

	// Use this for initialization
	void Start () {
		this.npcInterface = new TankController (transform, player.transform);

		/* the stats for this AI */
		AIResources resources = new AIResources (100, 50, 10, 1);

		/* the components for this AI module */
		this.ai = new GenericAI(new AIComponent[] {
			/**
			 * Check for the player in viewDistance. If in viewDistance, get within
			 * maxAttackDistance and shoot bullets every reloadTimeMillis milliseconds.
			 */
			new CombatComponent(resources, viewingAngle, viewingDistance
			                    , wanderAndPatrolSpeed, bullet, firepower, 
			                    reloadTimeMillis, maxAttackDistance),
			/**
			 * Player is out of eye sight of this tank. Check to see if we remember seeing
			 * the player before. If so, go there and rotate around 360 degrees and look for it.
			 */
			new PursueComponent(viewingDistance, viewingAngle, 
			                    maxAttackDistance, pursuitSpeed, wanderAndPatrolSpeed),
			/**
			 * Player is out of sight. Patrol random points within my "territory" rectangle.
			 */
			new WanderComponent(bounds, wanderAndPatrolSpeed), 
		}, resources, this.npcInterface);
	}
	
	// Update is called once per frame
	void Update () {
		this.ai.Think ();
		this.ai.Act ();
	}

	public AIResources GetAIStats() {
		return ai.GetAIStats ();
	}
}

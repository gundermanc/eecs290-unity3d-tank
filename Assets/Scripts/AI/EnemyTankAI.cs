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
	
	/* the GenericAI manager */
	private GenericAI ai;
	/* Controls the NPC and allows the AI to interface with it */
	private TankController npcInterface;
	/* Handles this AI's health, ammo, and armor */
	private AIResources resources;

	// Use this for initialization
	void Start () {
		this.npcInterface = new TankController (transform, player.transform);
		this.resources = new AIResources (100, 50, 10, 1);

		/* the components for this AI module */
		this.ai = new GenericAI(new AIComponent[] {
			//new WanderComponent(bounds, wanderAndPatrolSpeed),
			new PursueComponent(10, pursuitSpeed),
			new CombatComponent(resources, 45, 25, pursuitSpeed, bullet, firepower)
		}, this.npcInterface);
	}
	
	// Update is called once per frame
	void Update () {
		this.ai.Think ();
		this.ai.Act ();
	}
}

﻿using UnityEngine;
using System.Collections;

/**
 * A Generic AI structure which all other AI classes must implement.
 * @author Christian Gunderman
 * @author cdg46
 */
public class GenericAI {

	/* an array of AI components, which define the behavior of this entity */
	private AIComponent[] components = null;
	/* holds the controls for the entity */
	private EntityInterface npcInterface;

	/**
	 * Instantiates the GenericAI with the specified components.
	 * @param An array of AI Components that define the AI's behavior in
	 * different circumstances. Each component should evaluate the situation,
	 * try to respond, and return true if it can handle the situation, and false
	 * if not.
	 */
	public GenericAI(AIComponent[] components, EntityInterface npcInterface) {
		this.components = components;
		this.npcInterface = npcInterface;
	}

	public void Think() {
		for(int i = 0; i < this.components.Length; i++) {

			/* try the current component, if it handles the situation (true), end loop */
			this.components[i].Think(npcInterface);
		}
	}

	public void Act() {
		for(int i = 0; i < this.components.Length; i++) {
			/* try the current component, if it handles the situation (true), end loop */
			if(this.components[i].Act(npcInterface)) {
				return;
			}
		}
	}

	public static float Distance(Vector3 v1, Vector3 v2) {
		return Mathf.Sqrt (Mathf.Pow ((v1.x - v2.x), 2) + Mathf.Pow ((v1.y - v2.y), 2) + Mathf.Pow ((v1.z - v2.z), 2));
	}
}

using UnityEngine;
using System.Collections;
using System;

/** 
 * Handles the persistent memory of an NPC in the game, its observations,
 * what other entities (the player or NPC) that it is aware of, and their
 * last positions.
 * @author Christian Gunderman
 * @author cdg46
 */
public class EntityMemory {
	private Hashtable encounters;

	public EntityMemory() {
		this.encounters = new Hashtable ();
	}

	public void ObservedEntity(FriendlyInterface friendly, Vector3 lastLocation) {
		encounters.Add(friendly, lastLocation);
	}

	public void ForgotEntity(FriendlyInterface friendly) {
		encounters.Remove (friendly);
	}

	public Encounter GetLastEncounter(FriendlyInterface friendly) {
		return (Encounter)encounters[friendly];
	}

	public struct Encounter {
		public DateTime lastEncounterTime;
		public int id;
		public Vector3 lastLocation;
	}
}
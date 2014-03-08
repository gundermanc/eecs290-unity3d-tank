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
	// should be private but too lazy to declare this class iterable
	public Hashtable encounters;

	public EntityMemory() {
		this.encounters = new Hashtable ();
	}

	public void ObservedEntity(object friendly, Vector3 lastLocation) {
		Encounter encounter = new Encounter ();
		encounter.lastEncounterTime = DateTime.Now;
		encounter.lastLocation = lastLocation;

		if(encounters.Contains(friendly)) {
			encounters.Remove(friendly);
		}
		encounters.Add(friendly, encounter);
	}

	public void ForgotEntity(object friendly) {
		encounters.Remove (friendly);
	}

	// CAUTION: this method is broken.
	public Encounter GetLastEncounter(object friendly) {
		return (Encounter)encounters[friendly];
	}

	public class Encounter {
		public DateTime lastEncounterTime;
		public Vector3 lastLocation;
	}
}
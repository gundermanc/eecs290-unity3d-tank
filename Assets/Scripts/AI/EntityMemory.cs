using UnityEngine;
using System.Collections.Generic;
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
	public Dictionary<object, Encounter> encounters;

	public EntityMemory() {
		this.encounters = new Dictionary<object, Encounter> ();
	}

	public void ObservedEntity(object entity, Vector3 lastLocation) {
		Encounter encounter = new Encounter ();
		encounter.lastEncounterTime = DateTime.Now;
		encounter.lastLocation = lastLocation;

		if(encounters.ContainsKey(entity)) {
			encounters.Remove(entity);
		}
		encounters.Add(entity, encounter);
	}

	public void ForgetEntity(object entity) {
		encounters.Remove (entity);
	}

	// CAUTION: this method is broken.
	public Encounter GetLastEncounter(object entity) {
		return (Encounter)encounters[entity];
	}

	public class Encounter {
		public DateTime lastEncounterTime;
		public Vector3 lastLocation;
	}
}
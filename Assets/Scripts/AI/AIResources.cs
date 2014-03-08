using UnityEngine;

/**
 * Handles Health, Ammo, and Armor values for an AI entity.
 * @author Christian Gunderman
 * @author cdg46
 */
public class AIResources {
	private int healthPoints;
	private int ammo;
	private int armor;
	private int armorDeteriorationRate;

	/**
	 * Initializes the Resources counters for this AI.
	 * @param healthPoints: Initial health percentage.
	 * @param ammo Initial ammo.
	 * @param armor Initial armor percentage.
	 * @param armorDeteriorationRate How many points armor is reduced with each
	 * shot.
	 */
	public AIResources (int healthPoints, int ammo, int armor, 
	                    int armorDeteriorationRate) {
		this.healthPoints = healthPoints;
		this.ammo = ammo;
		this.armor = armor;
		this.armorDeteriorationRate = armorDeteriorationRate;
	}

	public void SetHealthPoints(int healthPoints) {
		if(healthPoints > 100) {
			this.healthPoints = 100;
		} else if(healthPoints < 0) {
			this.healthPoints = 0;
		} else {
			this.healthPoints = healthPoints;
		}
	}

	public int GetHealthPoints() {
		return this.healthPoints;
	}

	public void SetAmmo(int ammo) {
		if(ammo > 100) {
			this.ammo = 100;
		} else if(ammo < 10) {
			this.ammo = 0;
		} else {
			this.ammo = healthPoints;
		}
	}
	
	public int GetAmmo() {
		return this.ammo;
	}

	public void SetArmor(int armor) {
		if(armor > 10) {
			this.armor = 10;
		} else if(armor < 0) {
			this.armor = 0;
		} else {
			this.armor = armor;
		}
	}
	
	public int GetArmor() {
		return this.armor;
	}

	public void Damage() {
		this.healthPoints -= (int)Mathf.Ceil (10.0f / (float)armor);
		this.armor -= armorDeteriorationRate;

		if(this.healthPoints < 0) {
			this.healthPoints = 0;
		}

		if(this.armor < 0) {
			this.armor = 0;
		}
	}
}
using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {

	private int health; //Tank's health points (out of 100)
	private HealthDisplay showhealth; //Object that displays the health of the tank

	// Use this for initialization
	void Start () {
		health = 100;
		showhealth = gameObject.transform.GetComponentsInChildren<HealthDisplay> ()[0];
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.tag != "Player") {
			showhealth.UpdateHealth(health);
		}
	}

	/**
	 * Decreases the tank's health and kills the tank if the health hits 0.
	 * @param amount: How much the tank is hurt
	 */
	public void Hurt (int amount){
		health -= amount;
		if (health <= 0)
			Die ();
	}

	/**
	 * Destroys the tank.
	 */
	private void Die(){
		Destroy (gameObject);
	}
}

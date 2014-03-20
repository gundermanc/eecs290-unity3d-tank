using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {

	private HealthDisplay showhealth; //Object that displays the health of the tank

	// Use this for initialization
	void Start () {
		showhealth = gameObject.transform.GetComponentsInChildren<HealthDisplay> ()[0];
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.tag != "Player") {
			showhealth.UpdateHealth(gameObject.GetComponent<EnemyTankAI> ().GetAIStats ().GetHealthPoints());
		}
	}

	/**
	 * Decreases the tank's health and kills the tank if the health hits 0.
	 * @param amount: How much the tank is hurt
	 */
	public void Hurt (float amount){
		EnemyTankAI ai = gameObject.GetComponent<EnemyTankAI> ();
		if(ai != null) {
			ai.GetAIStats ().Damage (amount);
		}
	}

	/**
	 * Destroys the tank.
	 */
	private void Die(){
		Destroy (gameObject);
	}
}

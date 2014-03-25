using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float maxHealth = 100f;
	public float currentHealth = 100f;

	private int updater = 0;
	private float healthBarLength;

	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width / 4;
	}

	void OnGUI() {
		GUI.backgroundColor = Color.green;
		if (currentHealth <= 10) {
			GUI.Button(new Rect(20,20,healthBarLength,30),"");
			GUI.Label (new Rect(20,30 + healthBarLength,20,30),currentHealth.ToString ());
		} else {
			GUI.Button(new Rect(20,20,healthBarLength,30),currentHealth.ToString());
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth == 0) {
			Application.LoadLevel(0);
		}
		adjustHealth(currentHealth);
	}

	public void adjustHealth(float newHealth) {
		currentHealth = newHealth;
		if (currentHealth < 0) {
			currentHealth = 0;
		}
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
		healthBarLength = (Screen.width / 4) * (currentHealth / maxHealth);
	}

	void OnCollisionEnter(Collision bulletCollision) {
		if (bulletCollision.gameObject.tag.Equals("Bullet")) {
			currentHealth--;
		}
	}

}

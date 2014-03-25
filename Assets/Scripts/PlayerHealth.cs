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
		GUI.Button(new Rect(20,20,healthBarLength,30),currentHealth.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth == 0) {
			Destroy(gameObject);
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
			Debug.LogError ("COLLISION!!!!!!!!!!!!");
			currentHealth--;
		}
	}

}

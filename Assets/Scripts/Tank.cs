using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {

	private int health;

	// Use this for initialization
	void Start () {
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Hurt (int amount){
		health -= amount;
		if (health <= 0)
			Die ();
	}

	private void Die(){
		Destroy (gameObject);
	}
}

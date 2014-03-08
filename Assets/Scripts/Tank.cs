using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {

	private int health;
	private TextMesh showhealth;

	// Use this for initialization
	void Start () {
		health = 100;
		showhealth = gameObject.GetComponent(typeof(TextMesh)) as TextMesh;
		//showhealth.transform.position += Vector3.up;
		showhealth.anchor = TextAnchor.MiddleCenter;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.tag != "Player") {
			showhealth.text = health.ToString () + "\n\n\n";
		}
		showhealth.color = Color.Lerp(Color.red, Color.green, health/100f);
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

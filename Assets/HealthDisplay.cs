using UnityEngine;
using System.Collections;
/**
 * Object which displays a tanks health status floating above it.
 */
public class HealthDisplay : MonoBehaviour {

	private TextMesh showhealth;
	private GameObject cam;
	
	// Use this for initialization
	void Start () {
		showhealth = gameObject.GetComponent<TextMesh>();
		cam = GameObject.Find("Main Camera") as GameObject;
	}
	
	/** 
	 * Update is called once per frame
	 * Rotates the text towards the main camera
	 */
	void Update () {
		transform.rotation = cam.transform.rotation;
	}

	/**
	 * Updates the display's value and color.
	 * @param health: tank's current health
	 */
	public void UpdateHealth(int health){
		showhealth.text = health.ToString ();
		showhealth.color = Color.Lerp(Color.red, Color.green, health/100f);
	}
}

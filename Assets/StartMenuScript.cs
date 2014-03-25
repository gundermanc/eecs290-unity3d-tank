using UnityEngine;
using System.Collections;

public class StartMenuScript : MonoBehaviour {

	private float buttonPosX = Screen.width * 3 / 8;
	private float buttonPosY = Screen.height / 4;
	private float buttonWidth = Screen.width / 4;
	private float buttonHeight = Screen.height / 20;

	// Use this for initialization
	void Start () {
		guiText.alignment = TextAlignment.Center;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.skin.label.alignment = TextAnchor.UpperCenter;
		GUI.Label(new Rect(0,Screen.height / 8,Screen.width,Screen.height),"<size=40><b>TANK GAME</b></size>");
		if (GUI.Button (new Rect(buttonPosX,buttonPosY,buttonWidth,buttonHeight),"Start Game")) {
			Application.LoadLevel(1);
		}
	}
}

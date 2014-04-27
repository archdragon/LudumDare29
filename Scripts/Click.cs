using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

	void OnMouseDown() {
		Application.OpenURL("http://indiesquid.com");
	}

	void OnMouseOver() {
		guiTexture.color = new Color(0.5f,0.5f,0.5f,1.0f);
	}

	void OnMouseExit() {
		guiTexture.color = new Color(0.5f,0.5f,0.5f,0.0f);
	}

	// Use this for initialization
	void Start () {
		guiTexture.color = new Color(0,0,0,0);
	}
	
	// Update is called once per frame
	void Update () {

	}
}

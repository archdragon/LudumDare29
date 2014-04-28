using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	public Color startColor;
	public bool isActive;
	public float speed = 0.5f;
	public Color finalColor;
	private Color currentColor;
	private float timer = 0;
	
	// Use this for initialization
	void Start () {
		currentColor = startColor;
	}
	
	// Update is called once per frame
	void Update () {
		if(isActive) {		
			timer += Time.deltaTime*speed;
			if(currentColor != finalColor) {
				guiTexture.color = Color.Lerp(currentColor,finalColor, timer);
			}
		}
	}

	void StartFade() {
		isActive = true;
	}

}

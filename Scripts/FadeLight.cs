using UnityEngine;
using System.Collections;

public class FadeLight : MonoBehaviour {

	private Color randomColor;
	private Color currentColor;
	private float timer = 0;

	// Use this for initialization
	void Start () {
		InvokeRepeating("GenerateColor", 0f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		renderer.material.color = Color.Lerp(currentColor,randomColor, timer);
	}

	void GenerateColor() {
		timer = 0;
		currentColor = renderer.material.color;

		float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

		if(distance > 500) {
			randomColor = new Color(1f, 1f, 1f, Random.Range(0f, 0.01f));
		} else {

			randomColor = new Color(1f, 1f, 1f, Random.Range(0.1f, 0.5f));
		}
	}

}

using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public int maxTime = 600;
	private int currentTime = 0;

	private GameObject timeBg;


	// Use this for initialization
	void Start () {
		currentTime = maxTime;
		InvokeRepeating("CountDown", 0, 1.0F);
		timeBg = GameObject.Find("/GUI/TimeBg");
	}
	
	// Update is called once per frame
	void Update () {
		float timeBgSize = (((float)currentTime)/(float)maxTime)*256.0f;
		Debug.Log(timeBgSize);

		Rect pixelInset = timeBg.guiTexture.pixelInset;
		pixelInset.width = timeBgSize;
		timeBg.guiTexture.pixelInset = pixelInset;

		if(currentTime <= 0) {
			Application.LoadLevel("failed");
		}
	}

	void CountDown() {
		currentTime -= 1;
	}
}

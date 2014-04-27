using UnityEngine;
using System.Collections;

public class WatchClosest : MonoBehaviour {
	
	private GameObject targets;
	private GameObject distanceMarker;

	private Transform closestTransform;
	
	// Use this for initialization
	void Start () {
		targets = GameObject.Find("Targets");
		distanceMarker = GameObject.Find("/GUI/DistanceMarker");
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(DistanceToClosest());
		float distance = (DistanceToClosest()/1000.0f)*230.0f;
		distance = Mathf.Clamp(distance, 0.0f, 230.0f);
		//distanceMarker.guiTexture.pixelInset = new Rect(-70 - (230.0f-distance), distanceMarker.guiTexture.pixelInset.y, 64, 64);

		if(closestTransform != null)
			transform.LookAt(closestTransform);

	}
	
	float DistanceToClosest() {
		float closestDistance = 999999;
		float currentDistance = 0;
		foreach(Transform child in targets.transform) {
			currentDistance = Vector3.Distance(child.position, transform.position);
			if(currentDistance < closestDistance) {
				closestDistance = currentDistance;
				closestTransform = child;
			}
		}
		
		return closestDistance;
	}


	
	
}

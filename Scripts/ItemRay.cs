using UnityEngine;
using System.Collections;

public class ItemRay : MonoBehaviour {

	private Transform mainCam;
	private int layerTarget;
	private GameObject targets;

	private GameObject basicCrosshair;
	private GameObject targetCrosshair;
	private GameObject helperCrosshair;

	private GameObject arrow;

	public GameObject[] ideasArray;
		
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;

		arrow = GameObject.Find("/Arrow");

		ideasArray = new GameObject[6];

		targets = GameObject.Find("Targets");
		mainCam = Camera.main.transform;
		layerTarget = LayerMask.NameToLayer("Target");

		targetCrosshair = GameObject.Find("GUI/Crosshair/Texture Active");
		basicCrosshair = GameObject.Find("GUI/Crosshair/Texture Normal");
		helperCrosshair = GameObject.Find("GUI/Crosshair/Texture Helper");

		for(int n=0; n<=5; n++) {
			ideasArray[n] = GameObject.Find("Idea"+n);
		}

		UpdateTargetCounter();
	}
	
	// Update is called once per frame
	void Update () {
		targetCrosshair.SetActive(false);
		helperCrosshair.SetActive(false);
		basicCrosshair.SetActive(true);

		Ray ray = new Ray(mainCam.position,  transform.TransformDirection(Vector3.forward));
		RaycastHit hit;
		Debug.DrawRay(mainCam.position,  transform.TransformDirection(Vector3.forward), Color.green);
		if(Physics.Raycast (ray, out hit, 21)) {
			if(hit.transform.gameObject.layer == layerTarget) {
				targetCrosshair.SetActive(true);
				basicCrosshair.SetActive(false);
				if(Input.GetMouseButtonDown(0)) {
					GameObject instance = (GameObject)Instantiate(Resources.Load("Absorb Explosion", typeof(GameObject)), hit.transform.gameObject.transform.position, hit.transform.gameObject.transform.rotation);
					Destroy(hit.transform.parent.transform.parent.transform.gameObject);
				}


			} else if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Helper")) {
				targetCrosshair.SetActive(false);
				basicCrosshair.SetActive(false);
				helperCrosshair.SetActive(true);
				if(Input.GetMouseButtonDown(0)) {
					arrow.transform.position = hit.transform.parent.Find("ArrowPosition").position;
				}
			}
		}

		if(Input.GetMouseButtonUp(0)) {
			UpdateTargetCounter();
		}
	}
	
	void UpdateTargetCounter() {
		
		// Hide all of them first
		for(int n=0; n<=5; n++) {
			ideasArray[n].SetActive(false);
		}
		
		int count = targets.transform.childCount;

		if(count == 0) {
			//GameObject.Find("Fade Out").SendMessage("StartFade");
			//yield return new WaitForSeconds(2);
			Application.LoadLevel("won");
		}

		count = 5 - count;
		ideasArray[count].SetActive(true);
		Debug.Log ("Update target count: "+count);


		
	}
}

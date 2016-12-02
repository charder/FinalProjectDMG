using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {
	public GameObject currentObject;
	public GameObject objectHoldPosition; //where the object should be held on this object when moving
	public bool grabObj = false; //whether to attempt to grab an object within OnTriggerStay or not
	float clickTimer; //buffer timer for a mouse click (accounts for skips in OnTriggerStay
	float currentTimer;
	// Use this for initialization
	void Start () {
		clickTimer = 0.2f;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (grabObj) {
			currentTimer += Time.deltaTime;
			if (currentTimer >= clickTimer) {
				grabObj = false;
				currentTimer = 0;
			}
		}
		if (currentObject != null) {
			currentObject.transform.position = objectHoldPosition.transform.position;
			currentObject.transform.rotation = this.transform.rotation;
		}
		if (Input.GetMouseButtonDown (0)) {
			if (currentObject != null) {
				Rigidbody tmp = currentObject.GetComponent<Rigidbody> ();
				tmp.useGravity = true;
				currentObject.GetComponent<BoxCollider> ().enabled = true;
				currentObject = null;
			} else {
				grabObj = true;
			}
		}
	}

	void OnTriggerStay (Collider other) {
		if (other.tag != "Grab") {
			return;
		}
		if (currentObject == null && grabObj) {
			currentObject = other.gameObject;
			Rigidbody tmp = currentObject.GetComponent<Rigidbody> ();
			tmp.useGravity = false;
			currentObject.GetComponent<BoxCollider> ().enabled = false;
			grabObj = false;
		}
	}
}

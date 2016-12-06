using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {
	public GameObject currentObject;
	public GameObject objectHoldPosition; //where the object should be held on this object when moving
	public bool grabObj = false; //whether to attempt to grab an object within OnTriggerStay or not
	public Material oh;
	float clickTimer; //buffer timer for a mouse click (accounts for skips in OnTriggerStay
	float currentTimer;
	Vector3 currentObjectBoxSize;
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
				currentObject.GetComponent<Rigidbody> ().useGravity = true;
				BoxCollider tmp = currentObject.GetComponent<BoxCollider> ();
				tmp.size = currentObjectBoxSize;
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
			currentObject.GetComponent<Rigidbody> ().useGravity = false;
			Shader tmpColor = currentObject.GetComponent<Shader> ();

			BoxCollider tmp = currentObject.GetComponent<BoxCollider> ();
			currentObjectBoxSize = tmp.size;
			tmp.size = new Vector3 (0, 0, 0);
			grabObj = false;
		}
	}
}

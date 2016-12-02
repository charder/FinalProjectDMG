using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	public string keyName; //name of the gameObject that can unlock this 
	public Lock myLock; //reference to the script this key location unlocks
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == keyName) {
			myLock.updateDoor (true);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.name == keyName) {
			myLock.updateDoor (false);
		}
	}
}

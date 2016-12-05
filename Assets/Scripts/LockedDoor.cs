using UnityEngine;
using System.Collections;

public class LockedDoor : MonoBehaviour {
	public Lock[] locks; //references to the visual locks
	bool[] lockBool; //whether unlocked or locked
	bool doorUnlocked = false;
	public MeshRenderer myMesh; //door's mesh for uses with unlocking/locking
	public Collider myCollider; //door's collider for use with unlocking/locking
	// Use this for initialization
	void Start () {
		lockBool = new bool[locks.Length];
		for (int i = 0; i < lockBool.Length; i++) { //set all locks to false
			lockBool[i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Run a check every frame for each lock to see if it's unlocked now
		bool checkUnlocked = true;
		for (int i = 0; i < locks.Length; i++) {
			lockBool [i] = locks [i].unlocked;
			if (lockBool [i] == false) {
				checkUnlocked = false;
			}
		}
		if (!doorUnlocked && checkUnlocked) {
			doorUnlocked = true;
			myMesh.enabled = false;
			myCollider.enabled = false;
		} else if (doorUnlocked && !checkUnlocked) {
			doorUnlocked = false;
			myMesh.enabled = true;
			myCollider.enabled = true;
		}
	
	}
}

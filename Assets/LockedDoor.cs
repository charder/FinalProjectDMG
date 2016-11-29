using UnityEngine;
using System.Collections;

public class LockedDoor : MonoBehaviour {
	public GameObject[] locks; //references to the visual locks
	bool[] lockBool; //whether unlocked or locked
	// Use this for initialization
	void Start () {
		lockBool = new bool[locks.Length];
		for (int i = 0; i < lockBool.Length; i++) { //set all locks to false
			lockBool[i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

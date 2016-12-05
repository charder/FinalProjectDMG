using UnityEngine;
using System.Collections;

public class Lock : MonoBehaviour {
	public Material lockedMat;
	public Material unlockedMat;
	public MeshRenderer meshRef;
	public bool unlocked;
	// Use this for initialization
	void Start () {
		unlocked = false;
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void updateDoor (bool unlockStatus) { //false = locked, true = unlocked
		if (unlockStatus) {
			unlocked = true;
			meshRef.material = unlockedMat;
		} else {
			unlocked = false;
			meshRef.material = lockedMat;
		}

	}
}

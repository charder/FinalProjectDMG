using UnityEngine;
using System.Collections;
using System;

public class SyncAudio : MonoBehaviour {
	public float beats; //bpm
	public int indColor; //color array index
	public Color[] colorA; //array of colors
	public float timeChange;
	public UnityStandardAssets.ImageEffects.EdgeDetectionColor colorChange;
	// Use this for initialization
	void Start () {
		colorChange.edgesColor = colorA [indColor];
	
	}
	
	// Update is called once per frame
	void Update () {
		timeChange += Time.deltaTime;
		if (timeChange >= 60 / beats) {
			timeChange -= (60/beats);
			indColor++;
			if (indColor >= colorA.Length) {
				indColor = 0;
			}
			colorChange.edgesColor = colorA [indColor];
		}
	
	}
}

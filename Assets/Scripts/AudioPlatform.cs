using UnityEngine;
using System.Collections;

public class AudioPlatform : MonoBehaviour {
	float timeChange;
	public float offset; //time off-set from beats (measured in beats)
	public int beatMult; //how many beats go per change
	float beats; //bpm
	public bool visible;
	public SyncAudio syncAudio;
	public MeshRenderer myMesh;
	public Collider myCollider;
	// Use this for initialization
	void Start () {
		beats = syncAudio.beats;
		timeChange = offset * beatMult * (60 / beats); //set offset in local beats

	}
	
	// Update is called once per frame
	void Update () {
		timeChange += Time.deltaTime;
		if (timeChange >= beatMult * (60 / beats)) {
			timeChange -= beatMult * (60 / beats);
			ChangeVisibility ();
		}
	}

	void ChangeVisibility() {
		if (visible) {
			visible = false;
			myMesh.enabled = false;
			myCollider.enabled = false;
		} else {
			visible = true;
			myMesh.enabled = true;
			myCollider.enabled = true;
		}
	}
}

using UnityEngine;
using System.Collections;

public class AudioPlatform : MonoBehaviour {
	float timeChange;
	public float offset; //time off-set from beats (measured in beats)
	public int beatMultOn; //how many beats go while it's on
	public int beatMultOff; //how many beats go while it's off
	float beats; //bpm
	public bool visible;
	public SyncAudio syncAudio;
	public MeshRenderer myMesh;
	public Collider myCollider;
	// Use this for initialization
	void Start () {
		visible = !visible;
		ChangeVisibility ();
		beats = syncAudio.beats;
		if (visible) {
			timeChange = offset * (60 / beats);
		} else {
			timeChange = offset * (60 / beats);
		}

	}
	
	// Update is called once per frame
	void Update () {
		timeChange += Time.deltaTime;
		if (visible && timeChange >= beatMultOn * (60 / beats)) {
			timeChange -= beatMultOn * (60 / beats);
			ChangeVisibility ();
		} else if (!visible && timeChange >= beatMultOff * (60 / beats)) {
			timeChange -= beatMultOff * (60 / beats);
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

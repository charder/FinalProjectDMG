using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public int levelNum;
	public string[] levels;
	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
		SceneManager.LoadScene (levels [0]);
	}
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void RestartLevel() {
		SceneManager.LoadScene (levels [levelNum]);
	}

	public void LoadNextLevel() {
		levelNum++;
		if (levelNum >= levels.Length) {
			levelNum = 0;
		}
		SceneManager.LoadScene (levels [levelNum]);
	}
}

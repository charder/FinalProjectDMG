using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public int levelNum;
	public string[] levels;
	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
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
		SceneManager.LoadScene (levels [levelNum]);
	}
}

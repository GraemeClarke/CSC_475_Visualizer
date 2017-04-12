using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneModify : MonoBehaviour {

	public bool autoSwap;
	public int autoSwapCount = 300;
	int autoSwapCount0;

	public Text vizText;
	bool hideText = false;
	float wait;
	int timer = 0;

	void Awake() {
		Application.targetFrameRate = 30;
	}

	// Use this for initialization
	void Start () {
		autoSwapCount0 = autoSwapCount;
	}
	
	// Update is called once per frame
	void Update () {

		timer++;

		int sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		int sceneTotal = SceneManager.sceneCountInBuildSettings;

		if (Input.GetKeyDown ("up")) {

			if (sceneIndex == sceneTotal - 1) {
				sceneIndex = 0;
			} else {
				sceneIndex += 1;
			}

			SceneManager.LoadScene(sceneIndex);
		}
		else if (Input.GetKeyDown ("down")) {

			if (sceneIndex == 0) {
				sceneIndex = sceneTotal - 1;
			} else {
				sceneIndex -= 1;
			}

			SceneManager.LoadScene(sceneIndex);

		}


		if (autoSwap) {
			autoSwapCount--;
		}

		if (autoSwapCount <= 0) {
			if (sceneIndex == sceneTotal - 1) {
				sceneIndex = 0;
			} else {
				sceneIndex += 1;
			}

			autoSwapCount = autoSwapCount0; 
			SceneManager.LoadScene(sceneIndex);
		}



		if (Input.GetKeyDown ("j") && autoSwap == true && timer>5) {
			autoSwap = false;
			timer = 0;
		}
		if (Input.GetKeyDown ("j") && autoSwap == false && timer>5) {
			autoSwap = true;
			autoSwapCount = autoSwapCount0;
			timer = 0;
		}

		if (Input.GetKeyDown ("h")) {
			if (hideText == true) {
				hideText = false;
			} else {
				hideText = true;
			}
		}

		if (hideText) {
			vizText.text = "";
		} else {
			if (autoSwap) {
				vizText.text = SceneManager.GetActiveScene ().name + " (Auto-Swap on)";
			} else {
				vizText.text = SceneManager.GetActiveScene ().name + " (Auto-Swap off)";
			}

		}

		
	}
}

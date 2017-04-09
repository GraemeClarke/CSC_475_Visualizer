using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioModify : MonoBehaviour {

	AudioSource audio;
	Object[] myMusic;

	public Text songText;
	bool hideText = false;

	bool isPlaying;
	bool musicStarted = false;
	int timer = 0;
	int audioIndex = 0;
	float wait;

	private static audioModify instance = null;
	public static audioModify Instance {
		get { return instance; }
	}


	void Start () {

		isPlaying = true;

		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);


	}
		
	void Update () {

		timer++;

		AudioSource audio = GetComponent<AudioSource>();

		myMusic = Resources.LoadAll("audio",typeof(AudioClip));
		audio.clip = myMusic[audioIndex] as AudioClip;

		string str1 = audio.clip.ToString ();
		string str2 = "(UnityEngine.AudioClip)";
		string result = str1.Replace (str2, "");

		if (!hideText) {
			songText.text = result;
		} else {
			songText.text = "";
		}

		if (Input.GetKeyDown ("h")) {
			if (hideText == true) {
				hideText = false;
			} else {
				hideText = true;
			}
		}




		if (!musicStarted) {

			musicStarted = true;
			wait = audio.clip.length;
			audio.Play ();
		}
			
		wait-=Time.deltaTime;


		if (Input.GetKeyDown("space") && timer > 5 && !isPlaying) {
			audio.Play ();
			isPlaying = true;
			timer = 0;
		}

		if (Input.GetKeyDown("space") && timer > 5 && isPlaying) {
			audio.Pause ();
			isPlaying = false;
			timer = 0;
		}

		if(Input.GetKeyDown("left")) {
			if (audioIndex != 0) {
				audioIndex--;
				audio.clip = myMusic [audioIndex] as AudioClip;
				wait = audio.clip.length;
				isPlaying = true;
				audio.Play ();
			} else {
				audioIndex = myMusic.Length-1;
				audio.clip = myMusic [audioIndex] as AudioClip;
				wait = audio.clip.length;
				isPlaying = true;
				audio.Play ();
			}
		}

		if(Input.GetKeyDown("right") || (wait<0f)) {

			if (audioIndex != myMusic.Length - 1) {
				audioIndex++;
				audio.clip = myMusic [audioIndex] as AudioClip;
				wait = audio.clip.length;
				isPlaying = true;
				audio.Play ();
			} else {
				audioIndex = 0;
				audio.clip = myMusic [audioIndex] as AudioClip;
				wait = audio.clip.length;
				isPlaying = true;
				audio.Play ();
			}

		}


		
	}


}

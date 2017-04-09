using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioModify : MonoBehaviour {

	AudioSource audio;
	Object[] myMusic;

	bool isPlaying;
	bool musicStarted = false;
	int timer = 0;
	int audioIndex = 0;
	float wait;
	bool check;

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

		check = false;

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
				audio.Play ();
			} else {
				audioIndex = myMusic.Length-1;
				audio.clip = myMusic [audioIndex] as AudioClip;
				wait = audio.clip.length;
				audio.Play ();
			}
		}

		if(Input.GetKeyDown("right") || (wait<0f)) {

			if (audioIndex != myMusic.Length - 1) {
				audioIndex++;
				audio.clip = myMusic [audioIndex] as AudioClip;
				wait = audio.clip.length;
				audio.Play ();
			} else {
				audioIndex = 0;
				audio.clip = myMusic [audioIndex] as AudioClip;
				wait = audio.clip.length;
				audio.Play ();
			}

		}


		
	}


}

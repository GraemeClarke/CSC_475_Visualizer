using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioModify : MonoBehaviour {

	AudioSource audioSourceMusic;
	AudioClip clip;
	bool isPlaying;
	int timer = 0;

	// Use this for initialization
	void Start () {
		AudioSource audioSourceMusic = GetComponent<AudioSource>();

		audioSourceMusic.Play();

		clip = audioSourceMusic.clip;


		isPlaying = true;
		
	}

	public void PlaySong()
	{        
		if (clip != null  || audioSourceMusic!= null)
		{
			audioSourceMusic.loop = true;
			audioSourceMusic.volume = 1;
			audioSourceMusic.clip = clip;
			audioSourceMusic.Play();
		}
	}
	

	void Update () {

		timer++;

		AudioSource audioSourceMusic = GetComponent<AudioSource>();

		if (Input.GetKeyUp("space") && timer > 5 && !isPlaying) {
			audioSourceMusic.Play ();
			isPlaying = true;
			timer = 0;
		}

		if (Input.GetKeyUp("space") && timer > 5 && isPlaying) {
			audioSourceMusic.Pause ();
			isPlaying = false;
			timer = 0;
		}


		
	}


}

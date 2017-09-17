using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eq_flow : MonoBehaviour {

	private GameObject prefab;

	public int numberOfObjects;

	GameObject [] cubes;


	// Initialize scene

	void Start () {

		GameObject cam = GameObject.FindGameObjectWithTag ("MainCamera");

		prefab = Resources.Load("objects/Cube") as GameObject;

		Renderer rend = GetComponent<Renderer>();
	}
	
	// Update scene (called once per frame)

	void Update () {

		GameObject audioObject = GameObject.FindGameObjectWithTag ("audio");
		AudioSource audio = audioObject.GetComponent<AudioSource> ();
		
		float[] spectrum = audio.GetSpectrumData (1024, 0, FFTWindow.BlackmanHarris);

		GameObject cam = GameObject.FindGameObjectWithTag ("MainCamera");

		float lineLength = 20;
		float intialLinePos = 0 - lineLength / 2;

		// Collect all cubes
		cubes = GameObject.FindGameObjectsWithTag ("cubes");

		// Move cubes away from the viewer

		for (int i = 0; i < cubes.Length; i++) {

			if (cubes [i].transform.position.z < 10) {
				cubes [i].transform.Translate(Vector3.forward * Time.deltaTime * 4);
			} else {
				Destroy (cubes [i]);
			}
		}

		// Generate new cubes, and set them to the current spectrum 

		for (int i = 0; i < numberOfObjects; i++) {

			float spectrum_height = spectrum[i] * 40;
			int spectrum_max = 5;

			if (spectrum_height >= spectrum_max) {
				spectrum_height = spectrum_height* 0.5f;
			}

			Vector3 linePos = new Vector3(intialLinePos + i*lineLength/numberOfObjects, 0, 0);

			prefab.transform.localScale = new Vector3 (prefab.transform.localScale.x, spectrum_height, prefab.transform.localScale.z);
			linePos += new Vector3 (0, spectrum_height/2, 0);

			Instantiate(prefab, linePos, Quaternion.identity);
		}
	}
}

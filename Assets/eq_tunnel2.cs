using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eq_tunnel2 : MonoBehaviour {

	private GameObject prefab;

	public int numberOfObjects;
	public float radius;

	int cubeWait = 0;

	GameObject [] cubes;
	GameObject[] placedCubes;

	Color altColor = Color.white;


	// Initialize scene

	void Start () {

		GameObject cam = GameObject.FindGameObjectWithTag ("MainCamera");

		prefab = Resources.Load("objects/Cube 4") as GameObject;

		Renderer rend = GetComponent<Renderer>();


	}
	
	// Update scene (called once per frame)

	void Update () {

		GameObject audioObject = GameObject.FindGameObjectWithTag ("audio");
		AudioSource audio = audioObject.GetComponent<AudioSource> ();
		
		float[] spectrum = audio.GetSpectrumData (1024, 0, FFTWindow.BlackmanHarris);

		placedCubes = GameObject.FindGameObjectsWithTag ("placedcube");


		for (int i = 0; i < placedCubes.Length; i++) {

			if (placedCubes [i].transform.position.y > 20) {
				Destroy (placedCubes [i]);
			} else {
				placedCubes [i].transform.position += new Vector3 (0, 12 * Time.deltaTime, 0);
			}
		}

		for (int i = 0; i < numberOfObjects; i++) {

			float spectrum_height = spectrum[i] * 20;
			float spectrum_max = 1f;

			if (spectrum_height >= spectrum_max) {
				spectrum_height *= 0.1f;
			}

			if (cubeWait == 0) {

				float angle = i * Mathf.PI * 2 / numberOfObjects;
				Vector3 circPos = new Vector3 (Mathf.Cos (angle), 0, Mathf.Sin (angle)) * radius;

				//prefab.transform.localScale = new Vector3(spectrum_height,1,spectrum_height);
				prefab.transform.localScale = new Vector3(0.8f,0.8f,0.8f);
				circPos = Vector3.MoveTowards(circPos, new Vector3(0,circPos.y,0), spectrum_height*2);
				prefab.tag = "placedcube";
				
				Instantiate (prefab, circPos, Quaternion.identity);

				if (i == numberOfObjects - 1) {
					cubeWait = 0;
				}


			} else if (i == numberOfObjects - 1) {
				cubeWait--;
			}

				
		}


		GameObject cam = GameObject.FindGameObjectWithTag ("MainCamera");
		cam.transform.RotateAround (Vector3.zero, new Vector3(0,1,0), 10*Time.deltaTime);

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eq_spectrum : MonoBehaviour {


	private GameObject prefab;
	private GameObject prefab2;
	public enum DrawMode {Circle, Line};
	public DrawMode drawmode; 
	public int numberOfObjects;
	public float radius;
	GameObject [] cubes;
	GameObject [] cubes2;
	Renderer rend;
	Color altColor = Color.white;


	// Initialize scene
	void Start () {

		GameObject cam = GameObject.FindGameObjectWithTag ("MainCamera");

		prefab = Resources.Load("objects/Cube") as GameObject;
		prefab2 = Resources.Load ("objects/Cube 2") as GameObject;

		rend = GetComponent<Renderer>();

		float lineLength = 20;
		float intialLinePos = 0 - lineLength / 2;

		for (int i = 0; i < numberOfObjects; i++) {
			
			float angle = i * Mathf.PI * 2 / numberOfObjects;
			Vector3 circPos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
			Vector3 linePos = new Vector3(intialLinePos + i*lineLength/numberOfObjects, 0, 0);

			if (drawmode == DrawMode.Circle) {
				Instantiate(prefab, circPos, Quaternion.identity);
				Instantiate(prefab2, circPos, Quaternion.identity);
				cam.transform.position += new Vector3(0,1/(float)numberOfObjects,-0.5f/(float)numberOfObjects);

			} else if (drawmode == DrawMode.Line) {
				Instantiate(prefab, linePos, Quaternion.identity);
				Instantiate(prefab2, linePos, Quaternion.identity);
			}

		}
		cubes = GameObject.FindGameObjectsWithTag ("cubes");
		cubes2 = GameObject.FindGameObjectsWithTag("cubes2");
	}
	
	// Update scene (called once per frame)
	void Update () {
		
		float[] spectrum = AudioListener.GetSpectrumData (1024, 0, FFTWindow.BlackmanHarris);

		GameObject cam = GameObject.FindGameObjectWithTag ("MainCamera");

		for (int i = 0; i < numberOfObjects; i++) {
			
			Vector3 scale = cubes [i].transform.localScale;
			Vector3 cubePos = cubes[i].transform.position;

			float spectrum_height = spectrum[i] * 40;
			int spectrum_max = 5;

			if (spectrum_height >= spectrum_max) {
				spectrum_height = spectrum_height* 0.5f;
			}

			scale.y = Mathf.Lerp(scale.y, spectrum_height, Time.deltaTime * 30);

			Vector3 modPos = new Vector3(cubes[i].transform.position.x,scale.y/2,cubes[i].transform.position.z);
			Vector3 modPos2 = new Vector3(cubes[i].transform.position.x,spectrum_height,cubes[i].transform.position.z);

			cubes [i].GetComponent<Renderer> ().material.color = altColor;
			cubes [i].transform.position = modPos;
			cubes [i].transform.localScale = scale;

			if (spectrum_height > cubes2 [i].transform.position.y) {
				cubes2[i].transform.position = modPos2;
			}
		}

		if (drawmode == DrawMode.Circle) {
			cam.transform.RotateAround (Vector3.zero, new Vector3(0,1,0), 5*Time.deltaTime);
		}
			
	}
}

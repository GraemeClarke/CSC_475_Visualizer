using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOnSphere : MonoBehaviour {

	public GameObject prefab;
	
	public int numberOfObjects;
	Light redLight;
	bool lightGlow = false;
	public float size = 20;
	public bool transformBool = false;
	
	GameObject [] cubes;
	Renderer rend;

	int sphereScale = 500;

	
	// Create cubes

	void Create () {
		Vector3[] points = UniformPointsOnSphere(numberOfObjects, sphereScale);
		for(var i=0; i<numberOfObjects; i++) {
			Instantiate(prefab, points[i], Quaternion.identity);
		}
	}

	// Determine the position of each cube

	Vector3[] UniformPointsOnSphere(int numberOfObjects, float scale) {
		Vector3[] spherePoints_0 = new Vector3[numberOfObjects];
		var i = Mathf.PI * (3 - Mathf.Sqrt(5));
		var o = 2 / (float)numberOfObjects;

		for(var k=0; k<numberOfObjects; k++) {
			var y = k * o - 1 + (o / 2);
			var r = Mathf.Sqrt(1 - y*y);
			var phi = k * i;
			spherePoints_0[k] = new Vector3(Mathf.Cos(phi)*r, y, Mathf.Sin(phi)*r) * scale;
		}
		return spherePoints_0;
	}

	// Initialize scene

	void Start () {
		//prefab = Resources.Load("objects/Cube 3") as GameObject;

		Create ();

		GameObject redlightObject = GameObject.FindGameObjectWithTag("redlight");
		redLight = redlightObject.GetComponent<Light>();
	}

	// Update scene (called once per frame)

	void Update () {

		float[] spectrum = AudioListener.GetSpectrumData (1024, 0, FFTWindow.BlackmanHarris);

		GameObject cam = GameObject.FindGameObjectWithTag ("MainCamera");

		cubes = GameObject.FindGameObjectsWithTag ("cubes");

		//int jumpSamples = 0; Not being used, possible to reference multiple samples but who knows
		float maxSample = 0;
		float sampleAverage = 0;

		for (int n = 0; n < numberOfObjects; n++) {
			maxSample = Mathf.Max (maxSample, spectrum [n]);
			sampleAverage = sampleAverage + spectrum[n];
		}
		sampleAverage = sampleAverage / 1024;
		sampleAverage *= 1000;
		maxSample *= 1000;


		// Messing with the light

		if (redLight.intensity >= 7) {
			lightGlow = true;

		} else if(redLight.intensity <= 1){
			lightGlow = false;
		}

		if (!lightGlow) {
			redLight.intensity += Time.deltaTime;
			redLight.bounceIntensity += Time.deltaTime;
		} else if(lightGlow) {
			redLight.intensity -= Time.deltaTime;
			redLight.bounceIntensity -= Time.deltaTime;
		}

		// Iterate through all cubes, distort, etc;

		for (int i = 0; i < numberOfObjects; i++) {

			float spectrum_height = spectrum[i] * 40;
			int spectrum_max = 10;
			float spectrum_min = 0.01f;

			if (spectrum_height >= spectrum_max) {
				spectrum_height = spectrum_max;
			}
				
			Vector3 origPos = cubes [i].transform.position;
			Vector3 modPos;

			//float distanceToZero = Vector3.Distance(cubes[i].transform.position, Vector3.zero);

			if (Vector3.Distance (Vector3.zero, cubes [i].transform.position) > sphereScale) {
				modPos = Vector3.MoveTowards (cubes [i].transform.position, Vector3.zero, 400*Time.deltaTime);
				cubes [i].transform.position = modPos;
			
			} else if (Vector3.Distance (Vector3.zero, cubes [i].transform.position) <= sphereScale) {
				
				modPos = Vector3.MoveTowards(origPos, Vector3.zero, -spectrum_height* maxSample*100*Time.deltaTime);
				cubes [i].transform.position = modPos;
			}
				
			//cubes [i].GetComponent<Renderer> ().material.color = altColor;

		}

		cam.transform.RotateAround (Vector3.zero, new Vector3(1,1,1), -10*Time.deltaTime);

	}
}
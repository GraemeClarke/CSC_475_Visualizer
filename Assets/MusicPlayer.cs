using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine.UI;


public class MusicPlayer : MonoBehaviour
{
	public enum SeekDirection { Forward, Backward }

	public AudioSource source;
	public List<AudioClip> clips = new List<AudioClip>();

	public Text songText;
	bool hideText = false;
	bool isPlaying;

	[SerializeField] [HideInInspector] private int currentIndex = 0;

	private FileInfo[] soundFiles;
	private List<string> validExtensions = new List<string> { ".ogg", ".wav", ".flac" }; // Don't forget the "." i.e. "ogg" won't work - cause Path.GetExtension(filePath) will return .ext, not just ext.
	private string absolutePath = "./"; // relative path to where the app is running

	private static MusicPlayer instance = null;
	public static MusicPlayer Instance {
		get { return instance; }
	}

	void Start()
	{
		//being able to test in unity
		if (Application.isEditor) absolutePath = "Assets/Resources/audio";

		if (source == null) source = gameObject.AddComponent<AudioSource>();

		ReloadSounds();

		isPlaying = true;

		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);

	}





	void Update()
	{
		if(Input.GetKeyDown("left")) {
			Seek(SeekDirection.Backward);
			PlayCurrent();
		}
		if (Input.GetKeyDown("space")) {
			PlayCurrent();
		}
		if (Input.GetKeyDown("right")) {
			Seek(SeekDirection.Forward);
			PlayCurrent();
		}
			
		string str1 = source.clip.ToString ();
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
	}

	void Seek(SeekDirection d)
	{
		if (d == SeekDirection.Forward)
			currentIndex = (currentIndex + 1) % clips.Count;
		else {
			currentIndex--;
			if (currentIndex < 0) currentIndex = clips.Count - 1;
		}
	}

	void PlayCurrent()
	{
		source.clip = clips[currentIndex];
		source.Play();
	}

	void ReloadSounds()
	{
		clips.Clear();
		// get all valid files
		var info = new DirectoryInfo(absolutePath);
		soundFiles = info.GetFiles()
			.Where(f => IsValidFileType(f.Name))
			.ToArray();

		// and load them
		foreach (var s in soundFiles)
			StartCoroutine(LoadFile(s.FullName));
	}

	bool IsValidFileType(string fileName)
	{
		return validExtensions.Contains(Path.GetExtension(fileName));
		// Alternatively, you could go fileName.SubString(fileName.LastIndexOf('.') + 1); that way you don't need the '.' when you add your extensions
	}

	IEnumerator LoadFile(string path)
	{
		WWW www = new WWW("file://" + path);
		print("loading " + path);

		AudioClip clip = www.GetAudioClip(false);
		while(!clip.isReadyToPlay)
			yield return www;

		print("done loading");
		clip.name = Path.GetFileName(path);
		clips.Add(clip);
	}
}
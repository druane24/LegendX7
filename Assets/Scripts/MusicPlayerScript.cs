using UnityEngine;
using System.Collections;

public class MusicPlayerScript : MonoBehaviour {

	//Stores the AudioClip we want to play
	AudioSource myAudioSource;


	// Use this for initialization
	void Start () {
		//Load the AudioSource...
		myAudioSource = GetComponent<AudioSource> ();

		//...and make sure it doesn't start right away
		myAudioSource.playOnAwake = false;
	}

	// Update is called once per frame
	void Update () {
		//If no song is playing, loop it for us
		if (!myAudioSource.isPlaying) {
			myAudioSource.Play ();
		}
	}
}
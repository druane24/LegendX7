using UnityEngine;
using System.Collections;

public class ToggleSound : MonoBehaviour {

	private bool playing;
	public GameObject audioObject;
	// Use this for initialization
	void Start () {
		playing = true;
	}

	public void toggle() {
		playing = !playing;
	}
	// Update is called once per frame
	void Update () {
		if (playing) {
			audioObject.SetActive (true);
		} else {
			audioObject.SetActive (false);
		}
	}
}

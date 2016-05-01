using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public static bool pauseGame;
	private bool showGUI;
	public GameObject myCanvas;
	public GameObject player;
	public GameObject pauseCamera;

	void Start () {
		pauseGame = false;
		showGUI = false;
	}
	void Update()
	{
		if (Input.GetKeyDown ("p")) {
			pauseGame = true;

			if (pauseGame == true) {
				Time.timeScale = 0;
				showGUI = true;

			}
		}

		if (pauseGame == false) {
			Time.timeScale = 1;
			showGUI = false;
		}

		if (showGUI == true) {
			myCanvas.SetActive (true);
			player.SetActive (false);
			pauseCamera.SetActive (true);
			UnityEngine.Cursor.visible = true;
		} else {
			myCanvas.SetActive (false);
			player.SetActive (true);
			pauseCamera.SetActive (false);
			UnityEngine.Cursor.visible = false;
		}
	}
}

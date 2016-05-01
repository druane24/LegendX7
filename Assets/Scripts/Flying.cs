using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Flying : MonoBehaviour {
	public Image Flyingbar; 
	public static double flying;
	// Use this for initialization
	void Start () {
		flying = 100;
	}

	// Update is called once per frame
	void Update () {
		Flyingbar.fillAmount = (float)(flying/100);
	}
}

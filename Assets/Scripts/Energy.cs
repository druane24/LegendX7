using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
	public Image Energybar; 
	public static double energy;
	// Use this for initialization
	void Start () {
		energy = 100;
	}

	// Update is called once per frame
	void Update () {
		Energybar.fillAmount = (float)(energy/100);
	}
}

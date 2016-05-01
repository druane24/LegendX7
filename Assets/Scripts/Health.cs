using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public Image Healthbar; 
	public static double health;
	// Use this for initialization
	void Start () {
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		Healthbar.fillAmount = (float)(health/100);
	}
}

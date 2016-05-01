using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Potion : MonoBehaviour {
	public Text PotionText;
	public static int potions;
	// Use this for initialization
	void Start () {
		potions = 0;
	}
	
	// Update is called once per frame
	void Update () {
		PotionText.text = "" +potions;
	}
}

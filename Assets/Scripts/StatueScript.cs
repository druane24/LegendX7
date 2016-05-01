using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatueScript : MonoBehaviour {
	public Rigidbody coin;
	private int coinCount = 5;
	public Text text;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionStay(Collision other) {
		Animator ZeroAnim = other.gameObject.GetComponent<Animator> ();
		if (other.gameObject.name.StartsWith ("Zero") && ZeroAnim.GetBool("Attack") == true) {  // isAttacking is the variable for animation state changing
			// Coins start below map -> Change position to on map
			//GameObject aCoin = GameObject.Find("frameball1");
			//Vector3 newPosition = aCoin.transform.position;
			//newPosition.y = 5;
			//aCoin.transform.position = newPosition; 
			text.text = "Now try a block (X)";
		}
	}
}
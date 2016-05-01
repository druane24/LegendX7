using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Attack : MonoBehaviour {
	//Reference to animator to change parameters
	private Animator myAnimator;
	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			myAnimator.SetBool("Attack",true);
			myAnimator.Play("Attack!");
			Invoke ("stopAttack", 0.01f);
		}

		if (Input.GetKeyUp(KeyCode.Q))
		{
			myAnimator.SetBool("Roll",true);
			myAnimator.Play("Roll!");
			Invoke ("stopRoll", 0.01f);
		}

		if (Input.GetKeyUp(KeyCode.X))
		{
			myAnimator.SetBool("Block",true);
			myAnimator.Play ("Block!");
			Invoke ("stopBlock", 0.01f);
		}
	}

	void stopBlock(){
		myAnimator.SetBool ("Block", false);
	}

	void stopAttack() {
		myAnimator.SetBool ("Attack", false);
	}

	void stopRoll() {
		myAnimator.SetBool ("Roll", false);
	}



}
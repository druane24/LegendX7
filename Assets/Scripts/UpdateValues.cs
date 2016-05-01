using UnityEngine;
using System.Collections;

public class UpdateValues : MonoBehaviour {

	private Animator myAnimator;
	Rigidbody myRigidbody;
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();
		myAnimator = GetComponent<Animator> ();
		UnityEngine.Cursor.visible = false;
	}
		
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("e") && Energy.energy > 0) {
			Energy.energy = Energy.energy - 1;
		}

		if (Input.GetKey ("2") && Potion.potions > 0) {
			Potion.potions = Potion.potions - 1;
			Health.health = Health.health + 30;
		}
		if (Input.GetKey ("f") && Flying.flying > 0) {
			myRigidbody.AddForce (new Vector2 (0, 90f));
			Flying.flying = Flying.flying - 0.5;
			myAnimator.SetBool("Fly",true);
			myAnimator.Play("Fly!");
		}
		if (Input.GetKeyUp (KeyCode.F) || Flying.flying <= 0) {
			Invoke ("stopFlying", 0.01f);
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name.StartsWith ("potion")) {
			Destroy (other.gameObject);
			Potion.potions = Potion.potions + 1;
		}
	}

	void stopFlying() {
		myAnimator.SetBool ("Fly", false);
	}


}

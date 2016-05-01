using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossScript2 : MonoBehaviour {

	private Animator myAnim;
	private int timer;
	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator>();
		timer = 0;
		myAnim.SetBool ("walking", walking );

		if (path != null && path.Count > 1) {
			currentPathIndex = 0;
			nextPathIndex = 1;
			walkVector = path [nextPathIndex].position - path [currentPathIndex].position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newWalkVector = path [nextPathIndex].position - gameObject.transform.position;

		if (Vector3.Dot(walkVector, newWalkVector) < 0) { //We've gone past the next waypoint
			if (walking) {
				walking = false;
				myAnim.SetBool ("walking", walking );
				Invoke ("WalkToNext", 5.0f);
			}
		}
	}
	void Attack() {
		myAnim.SetBool ("Attack", true);
		myAnim.Play ("Attack!");
		Invoke ("stopAttack", 0.01f);
	}

	void Block() {
		myAnim.SetBool("Block",true);
		myAnim.Play ("Block!");
		Invoke ("stopBlock", 0.01f);
	}
	//The path the guard walks along
	public List<Transform> path;

	//The vector the guard is currently walking along
	private Vector3 walkVector;

	//The current and next spots on the path the guard will visit
	private int currentPathIndex;
	private int nextPathIndex;

	//Reference to animator to change parameters
	private Animator myAnimator;

	//Whether we're walking or not
	private bool walking = true;


	// Update is called once per frame

	//Creates a ring out of our path list
	//Once you reach the end of the list, the next index is the first
	int getNextIndex() {
		int nextIndex = nextPathIndex + 1;
		if (nextIndex >= path.Count) {
			nextIndex = 0;
		}
		return nextIndex;
	}

	//Turn the character so it's pointing in our new direction
	void RotateToNext() {
		Vector3 currentPosition = path[nextPathIndex].position;
		Vector3 nextPosition = path [getNextIndex ()].position;
		Vector3 newLookDirection = (nextPosition - currentPosition).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(newLookDirection);
		gameObject.transform.rotation = lookRotation;
	}

	//Walk to the next point on the path (the walking animation also translates, so we don't need to move the guard)
	void WalkToNext() {
		RotateToNext ();
		walking = true;
		myAnim.SetBool ("walking", walking );
		currentPathIndex = nextPathIndex;
		nextPathIndex = getNextIndex ();
		walkVector = path [nextPathIndex].position - path [currentPathIndex].position;
	}

}

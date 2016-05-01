using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollideScript : MonoBehaviour {

	//public GameObject ethan;
	public float rayLength;
	public bool hitStatue = false;
	public Text text;
	private Animator ZeroAnim;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Vector3 myVector = new Vector3 (0, 3, 0);
		Ray myRay = new Ray(transform.position + myVector , transform.forward);
		ZeroAnim = GetComponent<Animator> ();
		// This is supposed to show the actual ray collider in Unity - Doesn't affect functionality
		Debug.DrawRay(transform.position, transform.forward * rayLength);

		if(Physics.Raycast(myRay, out hit, rayLength))
		{
			if (Input.GetKeyUp(KeyCode.Mouse0) && hit.collider.name == "angelStatue" && !hitStatue ) {
				print("HIT THE STATUE");
				hitStatue = true;
				text.text = "Now try a block (X)";
				GameObject aCoin = GameObject.Find("potion");
				Vector3 newPosition = aCoin.transform.position;
				newPosition.y = 5;
				aCoin.transform.position = newPosition; 
			}
			if (Input.GetKeyUp (KeyCode.Mouse0) && hit.collider.name == "boss") {
				Destroy(GameObject.Find("boss"));
				text.text = "Congrats!  You beat the tutorial!";
			}
		}
	}
}
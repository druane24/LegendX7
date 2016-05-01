using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(NavMeshAgent))]
public class BossScript : MonoBehaviour {
	//beyond this point will be an attempt to implement a state handler for the bosss

	//our variables
	public Text text; 
	public float movespeed = 2.0f; 
	public float patrolspeed = 5.0f;
	private GameObject player;
	private Animator myAnim; //the actual boss model
	private int currFrame;
	private int BossHealth;
	private int timer = 0;
	private float[] times = { 0.0f, 5.0f, 10.0f, 15.0f, 20.0f, 25.0f };
	//Variables for the State Handler
	private NavMeshAgent meshAgent;


	public enum BossActionType
	{
		Idle,
		Follow, //may want to break this into MoveDirL, MoveDirR, etc...
		Chase, // speed up frame rate of follow script
		Retreat, //opposite of follow script
		Block, //call block animation. maybe do a probabiliy for whent he player attacks..
		Attack,// call attack animation
		TakeDamage// call hurt animation and recoil
	}

	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator>();
		meshAgent = GetComponent<NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");
		timer++; // start the event timer
		meshAgent.destination = player.transform.position; // taken from follow script to make boss track character's location
		//Call this with: StartCoroutine(StartBlock()); //this is Otto
		int rand = (int)(Random.value*7);
	}
	IEnumerator Block()// we will need this for each state
	{
		//yield return WaitForSeconds(5.0f);
		//isBlocking = false;
		// Every 5 seconds, block
		// change to block on the probability that character is within a certain distance or starts an attack..?
		myAnim.SetBool("Block!", true);
		myAnim.Play("Block!");

		Invoke("stopBlock", 0.01f);
		//isBlocking = false;
		return null;
	}
	/*
    IEnumerator Idle()// we will need this for each state
    {
        yield return WaitForSeconds(5.0f);
        Block();
    }
    IEnumerator Follow()// we will need this for each state
    {
        yield return WaitForSeconds(5.0f);
        Block();
    }

    IEnumerator Chase ()// we will need this for each state
    {
        yield return WaitForSeconds(5.0f);
        Block();
    }

    IEnumerator Attack()// we will need this for each state
    {
        yield return WaitForSeconds(5.0f);
        Block();
    }
    */



	//below are the scraps

	/* void Follow()
    {
        [RequireComponent (typeof(NavMeshAgent))]
	// Use this for initialization
	void Update () {
			//Just get the distance between the player and the enemy without obstacles. It's a good enough (and fast) proxy
			float thisDistance = Vector3.Distance (player.transform.position, this.transform.position);
			if (thisDistance < closestDistance) {
				closestDistance = thisDistance;
				closestPlayer = player;
			}
		}	
        //this is meant for multiplayer the vector equation may help for the retreat() function

		//This is what actually sets the enemy moving. (may or may not need this
		if (closestPlayer != null) {}
	}
}
        */
}
/*void Attack() //trying to make this based off proximity to character..
    {
            myAnim.SetBool("Attack!", true);
            //myAnim.Play("Attack!");

            //Invoke("stopAttack", 0.01f);
        isAttacking = false;
    }
    void Block()
    {
        //isBlocking = false;
        // Every 5 seconds, block
        // change to block on the probability that character is within a certain distance or starts an attack..?
            myAnim.SetBool("Block!", true);
            myAnim.Play("Block!");

            Invoke("stopBlock", 0.01f);
        //isBlocking = false;
    }

	}
}

/*
   private float idletimer;
   private float followtimer;
   private float chasetimer;
   private float retreattimer;
   private int stateindex; //to ssing a flag to each state held in the array
   */

/*we may need booelans for each class
private bool isAttacking = false;
private bool isFollowing = false;
private bool isChasing = false;
private bool isBlocking = false;
private bool isRetreating = false;
private bool isIdle = false;
*/
/*
//initial update script with timers and booleans
if (timer % 50 == 0 && !isAttacking && !isFollowing && !isChasing && !isBlocking &&
	!isRetreating &&
	!isIdle)
{
	Attack();
}
else if (timer % 100 == 0 && !isAttacking && !isFollowing && !isChasing && !isBlocking &&
	!isRetreating &&
	!isIdle)
{
	Block();
}
else if (timer % 20 == 0 && !isAttacking && !isFollowing && !isChasing && !isBlocking &&
	!isRetreating &&
	!isIdle)
{
	Retreat();
}
else if (timer % 100 == 0 && !isAttacking && !isFollowing && !isChasing && !isBlocking &&
	!isRetreating &&
	!isIdle)
{
	Follow();
}
else if (timer % 100 == 0 && !isAttacking && !isFollowing && !isChasing && !isBlocking &&
	!isRetreating &&
	!isIdle)
{
	Chase();
}
else if (timer % 100 == 0 && !isAttacking && !isFollowing && !isChasing && !isBlocking &&
	!isRetreating &&
	!isIdle)
	*/
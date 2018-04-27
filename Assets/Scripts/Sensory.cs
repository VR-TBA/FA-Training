using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensory : MonoBehaviour {

	public float speed;
	Animator anim;
	Rigidbody kidRigid;
	private float waitTime;
	public float startWaitTime;
	public AudioClip whining;
	public AudioSource soundSource;

	public static bool triggered = false;

	public Transform[] moveSpots;
	private int randomSpot;

	float currTime;
	float delayTime;
	float endTime;
	public float startTime;
	float delay;
	bool delayReached = true;
	bool alreadyTriggered = false;
	public TextPrompts textPrompts;
	private bool ending = true;

	// Use this for initialization
	void Start () 
	{
		endTime = Random.Range (30f, 60f);
		anim = GetComponent<Animator> ();
		waitTime = startWaitTime;
		randomSpot = Random.Range (0, moveSpots.Length);
		transform.LookAt(moveSpots[randomSpot].position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		currTime = Time.time;

		if (currTime >= startTime && currTime <= endTime) {
			if (delayReached == true) {
				Debug.Log ("Start SIB");
				if (!alreadyTriggered) {
					triggered = true;
					alreadyTriggered = true;
				}
				SIB ();
				soundSource.PlayOneShot (whining);
				delayReached = false;
				delay = currTime + Random.Range (1f, 5f);
				Debug.Log (delay);
			}
				
			if (currTime >= delay) {
				delayReached = true;
			}
		}

		else if (currTime >= endTime && ending) 
		{
			ending = false;
			textPrompts.EndSim ();
		}

		anim.SetBool ("IsWalking", true);
		transform.position = Vector3.MoveTowards (transform.position, moveSpots [randomSpot].position, speed = Time.deltaTime);

		if(Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
		{
			anim.SetBool ("IsWalking", false);

			if (waitTime <= 0) {
				randomSpot = Random.Range (0, moveSpots.Length);
				transform.LookAt(moveSpots[randomSpot].position);
				waitTime = startWaitTime;
			} else {
				waitTime -= Time.deltaTime;
			}
		}
	}

	void SIB()
	{
		anim.SetTrigger ("SIB");
	}
}

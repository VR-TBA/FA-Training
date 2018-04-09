using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensory : MonoBehaviour {

	public float speed;
	Animator anim;
	Rigidbody kidRigid;
	private float waitTime;
	public float startWaitTime;

	public Transform[] moveSpots;
	private int randomSpot;

	int	currTime;
	int delayTime;
	bool targetTimeSet = false;
	bool SIBTargetTimeSet = false;
	int endTime;
	public int startTime;
	int delay;
	bool delayReached = true;

	// Use this for initialization
	void Start () 
	{
		endTime = Random.Range (30, 60);
		anim = GetComponent<Animator> ();
		waitTime = startWaitTime;
		randomSpot = Random.Range (0, moveSpots.Length);
		transform.LookAt(moveSpots[randomSpot].position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		currTime = (int)Time.time;
		int startTime = 15;

		if (currTime >= startTime && currTime <= endTime) {
			if (delayReached == true) {
				Debug.Log("Start SIB");
				SIB ();
				delayReached = false;
				delay = currTime + Random.Range (1, 3);
				Debug.Log (delay);
			}
				
			if (currTime >= delay) {
				delayReached = true;
			}
		}
//		if (targetTimeSet == false) {
//			targetTimeSet = true;
//			targetTime = (int)Time.time;
//		}

//		if ((currTime - targetTime) == Random.Range(15, 45)) {
//			Debug.Log("Starting SIB possibility");
//			targetTime = (int)Time.time;
//
//			if (SIBTargetTimeSet == false) {
//				SIBTargetTimeSet = true;
//				SIBTargetTime = (int)Time.time - targetTime;
//			}
//
//			if ((SIBTargetTime - currTime) <= Random.Range (1, 3)) {
//				Debug.Log("starting SIB");
//				SIB ();
//				//SIBTargetTime = (int)Time.time;
//			}

		//}
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
		//Debug.Log ("First text prompt should appear now.");
		//Debug.Log (x);
		//int gametime = Time.time;


		//if(gametime <= time3) {
			anim.SetTrigger ("SIB");
			//Debug.Log (x);
			//i
		//}
	}
}

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

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		waitTime = startWaitTime;
		randomSpot = Random.Range (0, moveSpots.Length);
		transform.LookAt(moveSpots[randomSpot].position);
		StartCoroutine (SIB ());
	}
	
	// Update is called once per frame
	void Update () 
	{
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

	IEnumerator SIB()
	{
		yield return new WaitForSeconds (Random.Range(3, 15));
		Debug.Log ("First text prompt should appear now.");

		for (int i = 0; i < 15; i++) {
			yield return new WaitForSeconds (Random.Range(3, 15));
			anim.SetTrigger ("SIB");
		}

		Debug.Log ("Second text prompt should appear now. SIB will stop in 15 seconds.");

		for (int i = 0; i < 15; i++) {
			yield return new WaitForSeconds (Random.Range(3, 15));
			anim.SetTrigger ("SIB");
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeKidAni : MonoBehaviour {


	//public float speed;
	Animator anim;
	//Rigidbody kidRigid;
	//private float waitTime;
	//public float startWaitTime;

	//public Transform[] moveSpots;
	//private int randomSpot;
	bool sibBool = false;

	//int jumpHash = Animator.StringToHash("Jump");

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		//waitTime = startWaitTime;
		//randomSpot = Random.Range (0, moveSpots.Length);
		//transform.LookAt(moveSpots[randomSpot].position);
	}
	
	// Update is called once per frame
	public void SIB(){
		sibBool = true;
		
	}

	public void stopSIB(){
		sibBool = false;
	}
	void Update () 
	{
		if(sibBool == true){
			//anim.Play("Land");
			anim.SetTrigger ("SIB");
			//anim.SetTrigger ("Land");
		}else{
			anim.SetTrigger("Grounded");
		}
		
	}

	

}

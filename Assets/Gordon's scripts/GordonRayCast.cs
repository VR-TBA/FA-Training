using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GordonRayCast : MonoBehaviour {

	public float maxRayDist = 15;

	public SubjectHead SubjectHead1;
	public HomeworkAni HomeworkAni1;
	public BearAni BearAni1;
	public CandyAni CandyAni1;
	public bool hwMoved = false;
	public bool bearMoved = false;
	public bool candyMoved = false;

	public float targetTime = 6.0f;

	void timerEnded()
				 {
				    Debug.Log ("timer ended");
				 }

	public void FixedUpdate(){

		Ray myRay = new Ray (transform.position, transform.forward*maxRayDist);
		RaycastHit myHit;

		Debug.DrawRay(transform.position, transform.forward*maxRayDist);


		if (Physics.Raycast(myRay, out myHit, maxRayDist) ){

			//Debug.Log ("hit " + myHit.collider.tag);

			if (myHit.collider.tag == "Subject") {
				Debug.Log ("hit " + myHit.collider.tag);
				//SubjectHead1.headRed ();
				//Debug.Log ("Time machine hit!");
				//transform.position = new Vector3 (-1, 4, 34);
				//SceneManager.LoadScene ("timeMachine",  LoadSceneMode.Single);

			}
			if (myHit.collider.tag == "Homework") {
				Debug.Log ("hit " + myHit.collider.tag);
				if (hwMoved == false) {
					HomeworkAni1.moveHW ();
					hwMoved = true;
				} 

				else {
					HomeworkAni1.removeHW ();
					SubjectHead1.fixHead ();
					hwMoved = false;
				}
					
				
				//Debug.Log ("Time machine hit!");
				//transform.position = new Vector3 (-1, 4, 34);
				//SceneManager.LoadScene ("timeMachine",  LoadSceneMode.Single);

			}
			if(hwMoved == true && ChangeScene.function == "Escape"){
				SubjectHead1.headRed ();
			}

			if (myHit.collider.tag == "Bear") {
				if (bearMoved == false) {
					BearAni1.moveBear ();
					bearMoved = true;
				} else {
					BearAni1.removeBear ();
					bearMoved = false;
				}

			}
			if (myHit.collider.tag == "Candy") {
				if (candyMoved == false) {
					CandyAni1.moveCandy ();
					candyMoved = true;
				} else {
					CandyAni1.removeCandy ();
					candyMoved = false;
				}

			}
			if ( (myHit.collider.tag == "rightWall") || (myHit.collider.tag == "leftWall") ) {
				
				 
				 targetTime -= Time.deltaTime;
				 
				 if (targetTime <= 0.0f)
				 {
				    timerEnded();
				 }else{
				 	Debug.Log ("timer not ended");

				 }
				 
				 
				 
				 

			}
		}

	}

}

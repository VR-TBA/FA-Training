using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GordonRayCast : MonoBehaviour {

	public float maxRayDist = 15;

	public SubjectHead SubjectHead;
	public HomeworkAni HomeworkAni;
	public BearAni BearAni;
	public CandyAni CandyAni;
	public bool hwMoved = false;
	public bool hwMovedFirst = false;
	public bool waitedEnough = false;
	public bool bearMoved = false;
	public bool bearMovedFirst = false;
	public bool candyMovedFirst = false;
	public bool candyMoved = false;
	public bool turnedAround = false;
	public bool startTimeSet = false;

	int time1 = 0;
	int time2 = 0;

	//public float targetTime = 6.0f;

	 public static System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);

 	int cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;

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
					HomeworkAni.moveHW ();
					hwMoved = true;
				} else {

					HomeworkAni.removeHW ();
					
					hwMoved = false;
				}
					
				
				//Debug.Log ("Time machine hit!");
				//transform.position = new Vector3 (-1, 4, 34);
				//SceneManager.LoadScene ("timeMachine",  LoadSceneMode.Single);

			}
			if( (hwMovedFirst == false) && (hwMoved == true) && (ChangeScene.function == "Escape") ){

				SubjectHead.headRed ();
				hwMovedFirst = true;
			}

			if (myHit.collider.tag == "Bear") {
				if (bearMoved == false) {
					BearAni.moveBear ();
					bearMoved = true;
				} else {
					BearAni.removeBear ();
					bearMoved = false;
				}

			}
			if (myHit.collider.tag == "Candy") {
				if (candyMoved == false) {
					CandyAni.moveCandy ();
					candyMoved = true;
				} else {
					CandyAni.removeCandy ();
					candyMoved = false;
				}

			}
			if ( (myHit.collider.tag == "rightWall") || (myHit.collider.tag == "leftWall") ) {
				cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
				
				

				time2 = cur_time; //set time to current time when entering turn-around;
				//Debug.Log ("time2 = " + time2);

				if(startTimeSet == false){
					turnedAround = true;
					startTimeSet = true;
					time1 = time2;
					Debug.Log ("time1 = " + time1);
				}


				if( ((time2-time1) > 9) && (turnedAround == true) ){
					Debug.Log ("waited 10s: " + (time2-time1));
					waitedEnough = true;
					SubjectHead.fixHead ();

				}
				 
				 

			}else{
				turnedAround = false;
			}			
		}

			// Access function
			if (ChangeScene.function == "Access") {

				if ((hwMovedFirst == true) && (hwMoved == true) /*&& (ChangeScene.function == "Escape")*/) {
						hwMovedFirst = true;
				}

				if (myHit.collider.tag == "Bear") {
					if (bearMoved == false) {
						BearAni.moveBear ();
						bearMovedFirst = true;

						if (bearMovedFirst == true) {	// give bear back
							SubjectHead.fixHead ();
						}

					} else {
						BearAni.removeBear ();
						bearMoved = true;

						if (bearMoved == true && bearMovedFirst == true) {	// take bear
							SubjectHead.headRed ();
							bearMovedFirst = false;
						}
					}

				}
				if (myHit.collider.tag == "Candy") {
					if (candyMoved == false) {
						CandyAni.moveCandy ();
						candyMovedFirst = true;

						if (candyMovedFirst == true) {	// give candy
							SubjectHead.fixHead ();
						}

					} else {
						CandyAni.removeCandy ();
						candyMoved = true;

						if (candyMoved == true && candyMovedFirst == true) {	// take candy
							SubjectHead.headRed ();
							candyMovedFirst = false;
						}
						
					}
				}
			} // end access function
		}
	}

}

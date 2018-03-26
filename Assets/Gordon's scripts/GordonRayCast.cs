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
	public bool hwMovedFirst = false;
	public bool waitedEnough = false;
	public bool bearMoved = false;
	public bool candyMoved = false;
	public bool turnedAround = true;
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
					HomeworkAni1.moveHW ();
					hwMoved = true;
					hwMovedFirst = true;
				} else {

					HomeworkAni1.removeHW ();
					
					hwMoved = false;
				}
					
				
				//Debug.Log ("Time machine hit!");
				//transform.position = new Vector3 (-1, 4, 34);
				//SceneManager.LoadScene ("timeMachine",  LoadSceneMode.Single);

			}
			if(hwMovedFirst == true){
<<<<<<< HEAD

=======
>>>>>>> master
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
				cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
				turnedAround = true;
				

				time2 = cur_time; //set time to current time when entering turn-around;
				//Debug.Log ("time2 = " + time2);

				if(startTimeSet == false){
					startTimeSet = true;
					time1 = time2;
					Debug.Log ("time1 = " + time1);
				}


				if( ((time2-time1) > 9) && (turnedAround == true) ){
					Debug.Log ("waited 10s: " + (time2-time1));
					waitedEnough = true;
					SubjectHead1.fixHead ();

				}
				 
				 

			}else{
				turnedAround = false;
				startTimeSet = false;
			}
			
			
		}

	}

}

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
	public bool waitedEnough = false;
	public int waitCounter = 0;

	public bool onWall = false;

	public IEnumerator checkWait() {
		Debug.Log ("in coroutine " );
		waitedEnough = false;
		yield return new WaitForSeconds(3f); // waits 10 seconds
		Debug.Log ("waiting " );
		waitedEnough = true; // will make the update method pick up
		Debug.Log ("waitedEnough: " + waitedEnough.ToString());
	}
	void Update(){
		if (waitedEnough == true) {
			Debug.Log ("waited long enough");
		} else {
			Debug.Log ("didn't wait long enough");
		}
	}

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
				} else {
					HomeworkAni1.removeHW ();
					SubjectHead1.fixHead ();
					hwMoved = false;
				}
					
				
				//Debug.Log ("Time machine hit!");
				//transform.position = new Vector3 (-1, 4, 34);
				//SceneManager.LoadScene ("timeMachine",  LoadSceneMode.Single);

			}
			if(hwMoved == true){
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
<<<<<<< HEAD

			if ((hwMoved == false )) { //check for after they take the hw back
				
				if ((myHit.collider.tag == "rightWall") || (myHit.collider.tag == "leftWall")) {
					onWall = true;
					Debug.Log ("hit" + myHit.collider.tag);
					StartCoroutine (checkWait ());

				} else {
					onWall = false;
				}
			}

=======
			if ( (myHit.collider.tag == "rightWall") || (myHit.collider.tag == "leftWall") ) {
				
				 
				 targetTime -= Time.deltaTime;
				 
				 if (targetTime <= 0.0f)
				 {
				    timerEnded();
				 }else{
				 	Debug.Log ("timer not ended");

				 }
				 
				 
				 
				 

			}
>>>>>>> upstream/master
		}

	}

}

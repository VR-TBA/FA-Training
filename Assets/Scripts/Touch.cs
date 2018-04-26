using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Touch : MonoBehaviour {

	public float maxRayDist = 15;

	public HomeworkAni HomeworkAni;
	public BearAni BearAni;
	public CandyAni CandyAni;
	public EscapeKidAni escapeAni;
	public static bool hwMoved = false;
	public static bool hwMovedFirst = false;
	public static bool waitedEnough = false;
	public static bool bearMoved = false;
	public static bool bearMovedFirst = false;
	public static bool candyMovedFirst = false;
	public static bool candyMoved = false;
	public static bool turnedAround = false;
	public static bool startTimeSet = false;
	public static bool wallHit = false;
	public AudioSource mySource;
	public AudioClip whining;
	public AudioClip groan;

	private SphereCollider collider;
	private string itemTag;
	private bool touchedItem = false;

	int time1 = 0;
	int time2 = 0;

	//public float targetTime = 6.0f;

	public static System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);

	int cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;

	void Start()
	{
		collider = GetComponent<SphereCollider> ();
	}

	void OnTriggerEnter(Collider other)
	{
		itemTag = other.tag;
		touchedItem = true;
	}

	public void FixedUpdate(){

		if (touchedItem){

			//Debug.Log ("hit " + itemTag);

			if (itemTag == "Homework") {

				Debug.Log ("hit " + itemTag);
				if (hwMoved == false) {
					HomeworkAni.moveHW ();
					hwMoved = true;
				} else {

					HomeworkAni.removeHW ();

					hwMoved = false;
				}


			}
			if( (hwMovedFirst == false) && (hwMoved == true) && (ChangeScene.behavior == "Escape") ){
				//if( (hwMovedFirst == false) && (hwMoved == true)  ){

				//SubjectHead.headRed ();
				//Debug.Log("calling nonSensory SIB ");
				escapeAni.SIB();
				mySource.PlayOneShot (groan);

				hwMovedFirst = true;
			}

			if (itemTag == "Bear") {
				if (bearMoved == false) {
					BearAni.moveBear ();
					bearMoved = true;
				} else {
					BearAni.removeBear ();
					bearMoved = false;
				}

			}
			if (itemTag == "Candy") {
				if (candyMoved == false) {
					CandyAni.moveCandy ();
					candyMoved = true;
				} else {
					CandyAni.removeCandy ();
					candyMoved = false;
				}

			}
			if ( (itemTag == "rightWall") || (itemTag == "leftWall") ) {
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
					//SubjectHead.fixHead ();
					escapeAni.stopSIB();

				}



			}else{
				turnedAround = false;
			}			
		}

		// Access function
		if (ChangeScene.behavior == "Access") {

			if ((hwMovedFirst == true) && (hwMoved == true) /*&& (ChangeScene.behavior == "Escape")*/) {
				hwMovedFirst = true;
			}

			if (itemTag == "Bear") {
				if (bearMoved == false) {
					BearAni.moveBear ();
					bearMovedFirst = true;

					if (bearMovedFirst == true) {	// give bear back
						//SubjectHead.fixHead ();
						escapeAni.stopSIB();
					}

				} else {
					BearAni.removeBear ();
					bearMoved = true;

					if (bearMoved == true && bearMovedFirst == true) {	// take bear
						//SubjectHead.headRed ();
						escapeAni.SIB();
						mySource.PlayOneShot (whining);
						bearMovedFirst = false;
					}
				}

			}
			if (itemTag == "Candy") {
				if (candyMoved == false) {
					CandyAni.moveCandy ();
					candyMovedFirst = true;

					if (candyMovedFirst == true) {	// give candy
						//SubjectHead.fixHead ();
						escapeAni.stopSIB();
					}

				} else {
					CandyAni.removeCandy ();
					candyMoved = true;

					if (candyMoved == true && candyMovedFirst == true) {	// take candy
						//SubjectHead.headRed ();
						escapeAni.SIB();
						mySource.PlayOneShot (whining);
						candyMovedFirst = false;
					}

				}
			}
		} // end access function

		touchedItem = false;
	}
}


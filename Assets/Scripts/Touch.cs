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
	public TextPrompts textPrompts;
	private bool hwMoved = false;
	private bool hwMovedFirst = false;
	private bool waitedEnough = false;
	private bool bearMoved = false;
	private bool bearMovedFirst = false;
	private bool candyMovedFirst = false;
	private bool candyMoved = false;
	private bool turnedAround = false;
	private bool startTimeSet = false;
	private bool wallHit = false;
	public AudioSource mySource;
	public AudioClip whining;
	public AudioClip groan;

	public static bool triggered = false;

	private SphereCollider collider;
	private string itemTag;
	private bool touchedItem = false;

	bool accessBearSIBstarted = false;
	bool accessCandySIBstarted = false;

	int time1 = 0;
	int time2 = 0;

	//public float targetTime = 6.0f;

	public static System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);

	int cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;

	void Start()
	{
		collider = GetComponent<SphereCollider> ();
		triggered = false;
	}

	void OnTriggerEnter(Collider other)
	{
		itemTag = other.tag;
		touchedItem = true;
	}

	public void FixedUpdate(){
		if (ChangeScene.behavior == "Escape") {
			

			if (touchedItem) {

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
				if ((hwMovedFirst == false) && (hwMoved == true)) {
					//if( (hwMovedFirst == false) && (hwMoved == true)  ){

					//SubjectHead.headRed ();
					//Debug.Log("calling nonSensory SIB ");
					escapeAni.SIB ();
					mySource.PlayOneShot (groan);

					hwMovedFirst = true;
					triggered = true;
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
			}
		}
		if (ChangeScene.behavior == "Attention") {


			if (touchedItem) {

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
			}
		}

		// Access function
		if (ChangeScene.behavior == "Access") {

		  if (touchedItem) {

			if (itemTag == "Homework") {

				if (hwMoved == false) {
					HomeworkAni.moveHW ();
					hwMoved = true;
				} else {

					HomeworkAni.removeHW ();
					hwMoved = false;
				}
			}

			if (itemTag == "Bear") {
				if (bearMoved == false) {
					BearAni.moveBear ();
					bearMoved = true;

				} else {
					BearAni.removeBear ();
					bearMoved = false;
					bearMovedFirst = true;
				}
			}

			if( (bearMovedFirst == true) && (bearMoved == false)){
				escapeAni.SIB();
				mySource.PlayOneShot (whining);
					accessBearSIBstarted = true;
				bearMovedFirst = true;
				triggered = true;
			}
				if ( (bearMoved == true) && (accessBearSIBstarted == true) ) {	// give bear back
				escapeAni.stopSIB();
					accessBearSIBstarted = false;
				textPrompts.EndSim ();
			}

			if (itemTag == "Candy") {
					if (candyMoved == false) {
						CandyAni.moveCandy ();
						candyMoved = true;

				} else {
						CandyAni.removeCandy ();
						candyMoved = false;
						candyMovedFirst = true;
				}
			}

				if( (candyMovedFirst == true) && (candyMoved == false)){
				escapeAni.SIB();
				mySource.PlayOneShot (whining);
					accessCandySIBstarted = true;
					candyMovedFirst = true;
				triggered = true;
			}
				if ( (candyMoved == true) && (accessCandySIBstarted == true) ) {	// give bear back
				escapeAni.stopSIB();
					accessCandySIBstarted = false;
				textPrompts.EndSim ();
			}

//			if ((hwMovedFirst == true) && (hwMoved == true) /*&& (ChangeScene.behavior == "Escape")*/) {
//				hwMovedFirst = true;
//			}

//			if (itemTag == "Bear") {
//				if (bearMoved == false) {
//					BearAni.moveBear ();
//
//					if ( (bearMovedFirst == true) && (accessSIBstarted == true) ) {	// give bear back
//						escapeAni.stopSIB();
//						accessSIBstarted = false;
//						textPrompts.EndSim ();
//					}
//
//					bearMovedFirst = true;
//
//				} else {
//					BearAni.removeBear ();
//					bearMoved = true;
//
//					if (bearMoved == true && bearMovedFirst == true) {	// take bear
//						escapeAni.SIB();
//						accessSIBstarted = true;
//						mySource.PlayOneShot (whining);
//						bearMovedFirst = false;
//						triggered = true;
//					}
//				}
//
//			}
//			if (itemTag == "Candy") {
//				if (candyMoved == false) {
//					CandyAni.moveCandy ();
//
//					if ( (candyMovedFirst == true) && (accessSIBstarted == true) ) {	// give candy
//						//SubjectHead.fixHead ();
//						escapeAni.stopSIB();
//						accessSIBstarted = false;
//						textPrompts.EndSim ();
//					}
//
//					candyMovedFirst = true;
//
//				} else {
//					CandyAni.removeCandy ();
//					candyMoved = true;
//
//					if (candyMoved == true && candyMovedFirst == true) {	// take candy
//						//SubjectHead.headRed ();
//						escapeAni.SIB();
//						accessSIBstarted = true;
//						mySource.PlayOneShot (whining);
//						candyMovedFirst = false;
//						triggered = true;
//					}
//
//				}
//			}
			}
		} // end access function

		touchedItem = false;
	}
}
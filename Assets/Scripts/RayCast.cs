using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour {

	public float maxRayDist = 15;
	public EscapeKidAni escapeAni;

	public bool waitedEnough = false;
	public bool turnedAround = false;
	public bool startTimeSet = false;
	public bool wallHit = false;

	public AudioSource mySource;
	public AudioClip whining;
	public AudioClip groan;

	public Text timer;
	public TextPrompts textPrompts;
	public static bool triggered = false;

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

			if ( ((myHit.collider.tag == "rightWall") || (myHit.collider.tag == "leftWall")) && ChangeScene.behavior == "Escape") {
				cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
				
				

				time2 = cur_time; //set time to current time when entering turn-around;

				if(startTimeSet == false){
					turnedAround = true;
					startTimeSet = true;
					time1 = time2;
					timer.text = "Timer: " + ((int)time1 - cur_time);
				}

				if( ((time2-time1) > 29) && (turnedAround == true) ){
					Debug.Log ("waited 10s: " + (time2-time1));
					waitedEnough = true;
					escapeAni.stopSIB();
					textPrompts.EndSim ();
				}

				timer.text = "Timer: " + (cur_time - (int)time1);
			}

			else{
				turnedAround = false;
			}			
		}

		// Start Attention Function
		if (ChangeScene.behavior == "Attention") {
			//mySource = GetComponent<AudioSource>();

			// Start Wall

			if (wallHit == false){
				switch(myHit.collider.tag){
				case "rightWall":
					wallHit = true;
					//SubjectHead.headRed ();
					escapeAni.SIB ();
					mySource.PlayOneShot (whining);
					triggered = true;
					break;
				case "leftWall":
					wallHit = true;
					//SubjectHead.headRed ();
					escapeAni.SIB ();
					mySource.PlayOneShot (whining);
					triggered = true;
					break;
				default:
					break;
				}
			}
			if (wallHit == true) {
				switch(myHit.collider.tag){
				case "Subject":
					//SubjectHead.fixHead ();
					escapeAni.stopSIB();
					textPrompts.EndSim ();
					break;
				default:
					break;
				}
			}


		}// End Future Attention Scene

		}
	}


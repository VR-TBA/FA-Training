using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoPlay : MonoBehaviour {
	public GameObject AccessVid;
	public GameObject SensoryVid;
	public GameObject EscapeVid;
	public GameObject AttentionVid;

	// Use this for initialization
	void Start () {
		if (ChangeScene.behavior == "AccessVid")
			AccessVid.SetActive (true);
		else if (ChangeScene.behavior == "AttentionVid")
			AttentionVid.SetActive (true);
		else if (ChangeScene.behavior == "EscapeVid")
			EscapeVid.SetActive (true);
		else
			SensoryVid.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {

		if (OVRInput.GetDown (OVRInput.Button.One)) {
			SceneManager.LoadScene ("Menu");
		}
	}
}

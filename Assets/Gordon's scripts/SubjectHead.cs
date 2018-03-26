using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectHead : MonoBehaviour {
	float theta = 2.5f;
	public float speed = 10f;

	// void update(){
	// 	transform.Rotate(Vector3.up, speed * Time.deltaTime);
	// }

	

	public void headRed(){
		//Debug.Log ("headRed Called ");

		//transform.Rotate(new Vector3(-7.415785f,7.79672f,-9.136469f), theta);
		transform.Rotate(new Vector3(-7.415785f,7.79672f,-9.136469f), Space.Self);



	}
	public void fixHead(){
		transform.localRotation = Quaternion.Euler( new Vector3(0, 0,0) );


	}
}

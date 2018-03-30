using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagAni : MonoBehaviour {

	public void moveBag(){
		transform.localPosition = new Vector3(10f, 0f,7f);
		transform.localRotation = Quaternion.Euler( new Vector3(0f, 50f,0f) );

	}
	public void removeBag(){
		transform.localPosition = new Vector3(8.37f, 0f,2.92f);
		transform.localRotation = Quaternion.Euler( new Vector3(-90f, 0f,0f) );

	}
}

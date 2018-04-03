using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAni : MonoBehaviour {

	public void moveBear(){
		transform.localPosition = new Vector3(-5.6f, 4f,-4.1f);
		transform.localRotation = Quaternion.Euler( new Vector3(0f, 200f,0f) );

	}
	public void removeBear(){
		transform.localPosition = new Vector3(-2.61f, 4f,-0.11f);
		transform.localRotation = Quaternion.Euler( new Vector3(0f, 65.2f,0f) );

	}
}

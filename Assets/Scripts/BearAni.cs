using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAni : MonoBehaviour {

	private Transform startPos;
	private Transform movedPos;

	void Start()
	{
		startPos = this.GetComponent<Transform> ();
	}		

	public void moveBear(){
		transform.localPosition = new Vector3(-5.6f, 4f,-4.1f);
		transform.localRotation = Quaternion.Euler( new Vector3(-90f, -171.8f,0f) );

	}
	public void removeBear(){
		transform.localPosition = new Vector3(-4.3f, 4f, 0.86f);
		transform.localRotation = Quaternion.Euler( new Vector3(-90f, 65.2f,0f) );

	}
}

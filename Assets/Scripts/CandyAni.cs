using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyAni : MonoBehaviour {

	public void moveCandy(){
		transform.localPosition = new Vector3(-3.4f, 4.14f,-4.1f);
		//transform.localRotation = Quaternion.Euler( new Vector3(0f, -408.76f,-180f) );

	}
	public void removeCandy(){
		transform.localPosition = new Vector3(-2.71f, 4.06f,1.64f);
		transform.localRotation = Quaternion.Euler( new Vector3(0f, 0f,0f) );

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeworkAni : MonoBehaviour {



	public void moveHW(){
		transform.localPosition = new Vector3(-3.4f, 4.14f,-4.1f);
		transform.localRotation = Quaternion.Euler( new Vector3(0f, -408.76f,-180f) );

	}
	public void removeHW(){
		transform.localPosition = new Vector3(1.71f, 4.14f,-0.14f);
		transform.localRotation = Quaternion.Euler( new Vector3(0f, -96.21f,-180f) );

	}
}

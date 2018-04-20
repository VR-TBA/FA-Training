using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuNav : MonoBehaviour {

	private Button[] buttons;
	private int index = 0;
	private int numButtons;
	private Button newButton;


	// Use this for initialization
	void Start () 
	{
		buttons = this.GetComponentsInChildren<Button> ();
		numButtons = buttons.Length;
		newButton = buttons [0];
	}
	
	// Update is called once per frame
	void Update () 
	{
		newButton.Select ();

		if(OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown))
		{
			//If last button in array
			if (index == numButtons - 1) {
				newButton = buttons [0];
				index = 0;
			} 
			else {
				index++;
				newButton = buttons [index];
			}

			newButton.OnSelect (null);
			Debug.Log(newButton.ToString());
		}			
	}
}

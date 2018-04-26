using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public static string behavior;
	public static bool text;

	public GameObject prevMenu;
	public GameObject currMenu;
	public GameObject newMenu;


	public void ChangeTheScene()
	{
		string sceneChange;

		if (behavior == "Sensory")
			sceneChange = "Sensory Simulation";

		else 
			sceneChange = "Simulation";
	
		SceneManager.LoadScene (sceneChange);
	}

	public void nextMenu(){
		currMenu.SetActive(false);
		newMenu.SetActive(true);

	}

	public void backMenu()
	{
		currMenu.SetActive(false);
		prevMenu.SetActive(true);
	}

	public void Escape()
	{
		behavior = "Escape";
		nextMenu ();
	}

	public void Access()
	{
		behavior = "Access";
		nextMenu ();
	}

	public void Attention()
	{
		behavior = "Attention";
		nextMenu ();
	}

	public void Sensory()
	{
		behavior = "Sensory";
		nextMenu ();
	}

	public void TextOn()
	{
		text = true;
		ChangeTheScene ();
	}

	public void TextOff()
	{
		text = false;
		ChangeTheScene ();
	}
}

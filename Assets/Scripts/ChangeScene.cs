using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public static string behavior;
	public static bool text = false;

	public GameObject prevMenu;
	public GameObject currMenu;
	public GameObject newMenu;
	public GameObject videoMenu;
	public GameObject litMenu;


	public void ChangeTheScene()
	{
		string sceneChange;

		if (behavior == "Sensory")
			sceneChange = "Sensory Simulation";
		else if (behavior == "Access" || behavior == "Escape" || behavior == "Attention")
			sceneChange = "Simulation";
		else
			sceneChange = "Video";

	
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

	public void vidMenu()
	{
		currMenu.SetActive (false);
		videoMenu.SetActive (true);
	}

	public void literatureMenu()
	{
		currMenu.SetActive (false);
		litMenu.SetActive (true);
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

	public void AccessVid(){
		behavior = "AccessVid";
		ChangeTheScene ();
	}

	public void EscapeVid(){
		behavior = "EscapeVid";
		ChangeTheScene ();
	}

	public void SensoryVid(){
		behavior = "SensoryVid";
		ChangeTheScene ();
	}

	public void AttentionVid(){
		behavior = "AttentionVid";
		ChangeTheScene ();
	}
	public void Quit()
	{
		Application.Quit ();
	}
}

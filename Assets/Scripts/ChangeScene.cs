using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public static string behavior;

	public GameObject intro;
	public GameObject menu;

	bool nextMenuB= false;



	void Start()
	{
		Debug.Log (behavior);

		behavior = "Attention";

		if(nextMenuB == false){
			intro.SetActive(true);
			menu.SetActive(false);
			
		}

		
		

		
	}

	public void ChangeTheScene(string sceneChange)
	{
		SceneManager.LoadScene (sceneChange);
	}

	public void nextMenu(){
		intro.SetActive(false);
		menu.SetActive(true);
		nextMenuB = true;

	}

	public void Escape()
	{
		behavior = "Escape";
		ChangeTheScene ("Simulation");
	}

	public void Access()
	{
		behavior = "Access";
		ChangeTheScene ("Simulation");
	}

	public void Attention()
	{
		behavior = "Attention";
		ChangeTheScene ("Simulation");
	}

	public void Sensory()
	{
		behavior = "Sensory";
		ChangeTheScene ("Sensory Simulation");
	}
}

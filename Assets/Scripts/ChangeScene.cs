using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public static string behavior;

	void Start()
	{
		Debug.Log (behavior);
	}

	public void ChangeTheScene(int sceneChange)
	{
		SceneManager.LoadScene (sceneChange);
	}

	public void Escape()
	{
		behavior = "Escape";
		ChangeTheScene (2);
	}

	public void Access()
	{
		behavior = "Access";
		ChangeTheScene (2);
	}

	public void Attention()
	{
		behavior = "Attention";
		ChangeTheScene (2);
	}

	public void Sensory()
	{
		behavior = "Sensory";
		ChangeTheScene (3);
	}
}

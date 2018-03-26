using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public static string function;

	void Start()
	{
		Debug.Log (function);
	}

	public void ChangeTheScene(int sceneChange)
	{
		SceneManager.LoadScene (sceneChange);
	}

	public void Escape()
	{
		function = "Escape";
		ChangeTheScene (1);
	}

	public void Access()
	{
		function = "Access";
		ChangeTheScene (1);
	}

	public void Attention()
	{
		function = "Attention";
		ChangeTheScene (1);
	}

	public void Sensory()
	{
		function = "Sensory";
		ChangeTheScene (1);
	}
}

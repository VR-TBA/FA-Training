using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactPrompts : MonoBehaviour {

	public GameObject textCanvas;
	public Text question;
	public Button AccessButton;
	public Button SensoryButton;
	public Button EscapeButton;
	public Button AttentionButton;

	private bool textOn = ChangeScene.text;
	private string behavior = ChangeScene.behavior;

	// Use this for initialization
	void Update () 
	{

		if (textOn && (Touch.triggered == true || RayCast.triggered == true || Sensory.triggered == true)) 
		{

			if (ChangeScene.text = true) {
				Touch.triggered = false;
				RayCast.triggered = false;
				Sensory.triggered = false;
				StartCoroutine (reactToTantrum ());
			}

		}
	}

	public void AccessAnswer()
	{
		if (behavior != "Access") {
			AccessButton.GetComponent<Image> ().color = Color.red;
			question.text = "Incorrect. This is how you react to the \"Access\" condition";
		}
		else {
			AccessButton.GetComponent<Image> ().color = Color.green;
			StartCoroutine (correctAnswer());
		}
	}

	public void SensoryAnswer()
	{
		if (behavior != "Sensory") {
			SensoryButton.GetComponent<Image> ().color = Color.red;
			question.text = "Incorrect. This is how you react to the \"Sensory\" condition";
		}
		else {
			SensoryButton.GetComponent<Image> ().color = Color.green;
			StartCoroutine (correctAnswer());
		}
	}

	public void EscapeAnswer()
	{
		if (behavior != "Escape") {
			EscapeButton.GetComponent<Image> ().color = Color.red;
			question.text = "Incorrect. This is how you react to the \"Escape\" condition";
		}
		else {
			EscapeButton.GetComponent<Image> ().color = Color.green;
			StartCoroutine (correctAnswer());
		}
	}

	public void AttentionAnswer()
	{
		if (behavior != "Attention") {
			AttentionButton.GetComponent<Image> ().color = Color.red;
			question.text = "Incorrect. This is how you react to the \"Attention\" condition";
		}
		else {
			AttentionButton.GetComponent<Image> ().color = Color.green;
			StartCoroutine (correctAnswer());
		}
	}

	IEnumerator reactToTantrum()
	{
		yield return new WaitForSeconds (3);
		textCanvas.SetActive (true);
		Time.timeScale = 0;
		question.text = "The patient is having a tantrum! What should you do to stop it?";
	}

	IEnumerator correctAnswer()
	{
		question.text = "Correct! Please, demonstrate this technique...";
		Time.timeScale = 1f;
		yield return new WaitForSeconds (3);
		textCanvas.SetActive (false);

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextPrompts : MonoBehaviour {

	public GameObject textCanvas;
	public GameObject helpCanvas;
	public GameObject finishCanvas;
	public Text question;
	public Text function;
	public Text finish;
	public Button AccessButton;
	public Button SensoryButton;
	public Button EscapeButton;
	public Button AttentionButton;

	private bool textOn = ChangeScene.text;
	private string behavior = ChangeScene.behavior;

	// Use this for initialization
	void Start () 
	{
		if (textOn) 
		{
			textCanvas.SetActive (true);
			helpCanvas.SetActive (true);
			Debug.Log ("Text is on");
			Time.timeScale = 0;
			question.text = "What should you do to probe for the " + behavior + " condition?";
			function.text = behavior;
		}
		
	}

	IEnumerator ReturnToMenu()
	{
		yield return new WaitForSeconds (4);

		finish.text = "Taking you back to the main menu...";

		yield return new WaitForSeconds (4);

		SceneManager.LoadScene ("Menu");
	}

	public void EndSim()
	{
		helpCanvas.SetActive (false);
		finishCanvas.SetActive (true);
		StartCoroutine (ReturnToMenu());
	}

	public void AccessAnswer()
	{
		if (behavior != "Access") {
			AccessButton.GetComponent<Image> ().color = Color.red;
			question.text = "Incorrect. This is how you probe for the \"Access\" condition.";
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
			question.text = "Incorrect. This is how you probe for the \"Sensory\" condition.";
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
			question.text = "Incorrect. This is how you probe for the \"Escape\" condition.";
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
			question.text = "Incorrect. This is how you probe for the \"Attention\" condition.";
		}
		else {
			AttentionButton.GetComponent<Image> ().color = Color.green;
			StartCoroutine (correctAnswer());
		}
	}

	IEnumerator correctAnswer()
	{
		question.text = "Correct! Please demonstrate this technique...";
		Time.timeScale = 1f;
		yield return new WaitForSeconds (4);
		textCanvas.SetActive (false);
	}
}

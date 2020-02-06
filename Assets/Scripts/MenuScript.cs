using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ObjectForm{Teapot, Elephant, Fortytwo, Globe};

public class MenuScript : MonoBehaviour
{
	public ObjectForm objectForm;
	public bool canClick;
	public bool testMode;

	private Animator menuAnimator;

	void Start() {
		objectForm = ObjectForm.Teapot;
		canClick = false;
		testMode = false;
		menuAnimator = GameObject.Find("Menu").GetComponent<Animator>();

		DontDestroyOnLoad(gameObject);
		Invoke("authorizeClick", 5f);
	}

	public void goToStageSelection(bool b) {
		menuAnimator.Play("MainMenuToStageSelection", 0, 0f);
		testMode = b;
	}

	public void goToMainMenu() {
		menuAnimator.Play("StageSelectionToMainMenu", 0, 0f);
	}

	public void startStage() {
		canClick = false;
		menuAnimator.Play("StageSelectionToStage", 0, 0f);
	}

	public void loadObject() {
		SceneManager.LoadScene("Game");
	}

	private void authorizeClick()
	{
		canClick = true;
	}
}

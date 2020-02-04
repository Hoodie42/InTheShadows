using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Difficulty{Easy, Normal, Hard};
public enum ObjectForm{Teapot, Elephant, Fortytwo, Globe};

public class MenuScript : MonoBehaviour
{
	public Difficulty difficulty;
	public ObjectForm objectForm;
	public bool canClick;

	private Animator menuAnimator;

	void Start() {
		difficulty = Difficulty.Easy;
		objectForm = ObjectForm.Teapot;
		canClick = false;
		menuAnimator = GameObject.Find("Menu").GetComponent<Animator>();

		DontDestroyOnLoad(gameObject);
		Invoke("authorizeClick", 5f);
	}

	public void goToStageSelection() {
		menuAnimator.Play("MainMenuToStageSelection", 0, 0f);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty{Easy, Normal, Hard};

public class MenuScript : MonoBehaviour
{
	public Difficulty difficulty;

	private Animator menuAnimator;

	void Start() {
		difficulty = Difficulty.Easy;
		menuAnimator = GetComponent<Animator>();
	}

	public void goToStageSelection() {
		menuAnimator.Play("MainMenuToStageSelection", 0, 0f);
	}

	public void goToMainMenu() {
		menuAnimator.Play("StageSelectionToMainMenu", 0, 0f);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverScript : MonoBehaviour
{
	public enum MenuButtonType{Normal, Test, Teapot, Globe, Fortytwo, Elephant, EasyDifficulty, NormalDifficulty, HardDifficulty, Back};
	public MenuButtonType buttonType;

	private MenuScript menuScript;
	private TextMesh textMesh;
	private bool isMouseOver = false;

	void Start() {
		menuScript = GameObject.Find("Menu").GetComponent<MenuScript>();
		textMesh = GetComponent<TextMesh>();
	}

	void Update() {
		// TEXT MESH COLORS
		switch(buttonType) {
			case MenuButtonType.Normal:
				if (isMouseOver) {
					textMesh.color = new Color(.9f, .9f, .9f);
					if (Input.GetMouseButtonDown(0)) {
						Debug.Log("Launch Normal Mode");
						menuScript.goToStageSelection();
					}
				} else {
					textMesh.color = new Color(.1f, .1f, .1f);
				}
				break;

			case MenuButtonType.Teapot:
				if (isMouseOver) {
					textMesh.color = new Color(.9f, .9f, .9f);
					if (Input.GetMouseButtonDown(0)) {
						Debug.Log("Launch Teapot Scene");
					}
				} else {
					textMesh.color = new Color(.1f, .1f, .1f);
				}
				break;

			case MenuButtonType.Globe:
				if (isMouseOver) {
					textMesh.color = new Color(.9f, .9f, .9f);
					if (Input.GetMouseButtonDown(0)) {
						Debug.Log("Launch Globe Scene");
					}
				} else {
					textMesh.color = new Color(.1f, .1f, .1f);
				}
				break;

			case MenuButtonType.Fortytwo:
				if (isMouseOver) {
					textMesh.color = new Color(.9f, .9f, .9f);
					if (Input.GetMouseButtonDown(0)) {
						Debug.Log("Launch Fortytwo Scene");
					}
				} else {
					textMesh.color = new Color(.1f, .1f, .1f);
				}
				break;

			case MenuButtonType.Elephant:
				if (isMouseOver) {
					textMesh.color = new Color(.9f, .9f, .9f);
					if (Input.GetMouseButtonDown(0)) {
						Debug.Log("Launch Elephant Scene");
					}
				} else {
					textMesh.color = new Color(.1f, .1f, .1f);
				}
				break;

			case MenuButtonType.EasyDifficulty:
				if (menuScript.difficulty == Difficulty.Easy) {
					textMesh.color = new Color(.9f, .9f, .9f);
				} else {
					textMesh.color = new Color(.1f, .1f, .1f);
				}
				if (Input.GetMouseButtonDown(0) && isMouseOver) {
					menuScript.difficulty = Difficulty.Easy;
				}
				break;

			case MenuButtonType.NormalDifficulty:
				if (menuScript.difficulty == Difficulty.Normal) {
					textMesh.color = new Color(.9f, .9f, .9f);
				} else {
					textMesh.color = new Color(.1f, .1f, .1f);
				}
				if (Input.GetMouseButtonDown(0) && isMouseOver) {
					menuScript.difficulty = Difficulty.Normal;
				}
				break;

			case MenuButtonType.HardDifficulty:
				if (menuScript.difficulty == Difficulty.Hard) {
					textMesh.color = new Color(.9f, .9f, .9f);
				} else {
					textMesh.color = new Color(.1f, .1f, .1f);
				}
				if (Input.GetMouseButtonDown(0) && isMouseOver) {
					menuScript.difficulty = Difficulty.Hard;
				}
				break;

			case MenuButtonType.Back:
				if (isMouseOver) {
					textMesh.color = new Color(.9f, .9f, .9f);
					if (Input.GetMouseButtonDown(0)) {
						menuScript.goToMainMenu();
					}
				} else {
					textMesh.color = new Color(.1f, .1f, .1f);
				}
				break;
			default:
				if (isMouseOver) {
					textMesh.color = new Color(.9f, .9f, .9f);
					if (Input.GetMouseButtonDown(0)) {
						Debug.Log("Launch Test Mode");
						menuScript.goToStageSelection();
					}
				} else {
					textMesh.color = new Color(.1f, .1f, .1f);
				}
				break;
		}
	}

	void OnMouseOver() {
		isMouseOver = true;
	}

	void OnMouseExit() {
		isMouseOver = false;
	}
}

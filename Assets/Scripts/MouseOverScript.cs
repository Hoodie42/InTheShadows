using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverScript : MonoBehaviour
{
	public enum MenuButtonType{Normal, Test, Teapot, Globe, Fortytwo, Elephant, EasyDifficulty, NormalDifficulty, HardDifficulty};
	public MenuButtonType buttonType;

	private bool isMouseOver = false;

	void Update() {
		if (Input.GetMouseButtonDown(0) && isMouseOver) {
			if (buttonType == MenuButtonType.Normal) {
				Debug.Log("Launch Normal Mode");
			}
			else if (buttonType == MenuButtonType.Teapot) {
				Debug.Log("Launch Teapot Scene");
			}
			else if (buttonType == MenuButtonType.Globe) {
				Debug.Log("Launch Globe Scene");
			}
			else if (buttonType == MenuButtonType.Fortytwo) {
				Debug.Log("Launch Fortytwo Scene");
			}
			else if (buttonType == MenuButtonType.Elephant) {
				Debug.Log("Launch Elephant Scene");
			}
			else if (buttonType == MenuButtonType.EasyDifficulty) {
				Debug.Log("Set difficulty to easy");
			}
			else if (buttonType == MenuButtonType.NormalDifficulty) {
				Debug.Log("Set difficulty to normal");
			}
			else if (buttonType == MenuButtonType.HardDifficulty) {
				Debug.Log("Set difficulty to hard");
			}
			else {
				Debug.Log("Launch Test Mode");
			}
		}
	}

	void OnMouseOver() {
		isMouseOver = true;
	}

	void OnMouseExit() {
		isMouseOver = false;
	}
}

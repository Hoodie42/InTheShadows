using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverScript : MonoBehaviour
{
	public enum MenuButtonType{Normal, Test, Teapot, Globe, Fortytwo, Elephant, Back};
	public MenuButtonType buttonType;

	private MenuScript menuScript;
	private TextMesh textMesh;
	private AudioSource clickSound;
	private int progression;
	private bool isMouseOver = false;

	void Start() {
		menuScript = GameObject.Find("MenuLogic").GetComponent<MenuScript>();
		textMesh = GetComponent<TextMesh>();
		clickSound = GameObject.Find("Main Camera").GetComponent<AudioSource>();
	}

	void Update() {
		progression = PlayerPrefs.GetInt("ItsProgression", 0);
		switch(buttonType) {
			case MenuButtonType.Normal:
				if (isMouseOver) {
					textMesh.color = new Color(.9f, .9f, .9f);
					if (Input.GetMouseButtonDown(0) && menuScript.canClick) {
						clickSound.Play();
						menuScript.goToStageSelection(false);
					}
				} else {
					textMesh.color = new Color(.1f, .1f, .1f);
				}
				break;

			case MenuButtonType.Teapot:
				if (isMouseOver) {
					textMesh.color = new Color(.9f, .9f, .9f);
					if (Input.GetMouseButtonDown(0) && menuScript.canClick) {
						clickSound.Play();
						menuScript.objectForm = ObjectForm.Teapot;
						menuScript.startStage();
					}
				} else {
					textMesh.color = new Color(.1f, .1f, .1f);
				}
				if (progression > 0 && !menuScript.testMode) {
					transform.Find("Status").gameObject.GetComponent<TextMesh>().text = "easy (done)";
				} else {
					transform.Find("Status").gameObject.GetComponent<TextMesh>().text = "easy";
				}
				break;

			case MenuButtonType.Globe:
				if (isMouseOver && (progression >= 2 || menuScript.testMode)) {
					textMesh.color = new Color(.9f, .9f, .9f);
					if (Input.GetMouseButtonDown(0) && menuScript.canClick) {
						clickSound.Play();
						menuScript.objectForm = ObjectForm.Globe;
						menuScript.startStage();
					}
				} else {
					textMesh.color = new Color(.1f, .1f, .1f);
				}
				if (progression < 2 && !menuScript.testMode) {
					transform.Find("Status").gameObject.GetComponent<TextMesh>().text = "unavailable";
				} else if (progression > 2 && !menuScript.testMode) {
					transform.Find("Status").gameObject.GetComponent<TextMesh>().text = "hard (done)";
				} else {
					transform.Find("Status").gameObject.GetComponent<TextMesh>().text = "hard";
				}
				break;

			case MenuButtonType.Fortytwo:
				if (isMouseOver && (progression >= 3 || menuScript.testMode)) {
					textMesh.color = new Color(.9f, .9f, .9f);
					if (Input.GetMouseButtonDown(0) && menuScript.canClick) {
						clickSound.Play();
						menuScript.objectForm = ObjectForm.Fortytwo;
						menuScript.startStage();
					}
				} else {
					textMesh.color = new Color(.1f, .1f, .1f);
				}
				if (progression < 3 && !menuScript.testMode) {
					transform.Find("Status").gameObject.GetComponent<TextMesh>().text = "unavailable";
				} else if (progression > 3 && !menuScript.testMode) {
					transform.Find("Status").gameObject.GetComponent<TextMesh>().text = "hard (done)";
				} else {
					transform.Find("Status").gameObject.GetComponent<TextMesh>().text = "hard";
				}
				break;

			case MenuButtonType.Elephant:
				if (isMouseOver && (progression >= 1 || menuScript.testMode)) {
					textMesh.color = new Color(.9f, .9f, .9f);
					if (Input.GetMouseButtonDown(0) && menuScript.canClick) {
						clickSound.Play();
						menuScript.objectForm = ObjectForm.Elephant;
						menuScript.startStage();
					}
				} else {
					textMesh.color = new Color(.1f, .1f, .1f);
				}
				if (progression < 1 && !menuScript.testMode) {
					transform.Find("Status").gameObject.GetComponent<TextMesh>().text = "unavailable";
				} else if (progression > 1 && !menuScript.testMode) {
					transform.Find("Status").gameObject.GetComponent<TextMesh>().text = "normal (done)";
				} else {
					transform.Find("Status").gameObject.GetComponent<TextMesh>().text = "normal";
				}
				break;

			case MenuButtonType.Back:
				if (isMouseOver) {
					textMesh.color = new Color(.9f, .9f, .9f);
					if (Input.GetMouseButtonDown(0) && menuScript.canClick) {
						clickSound.Play();
						menuScript.goToMainMenu();
					}
				} else {
					textMesh.color = new Color(.1f, .1f, .1f);
				}
				break;

			default:
				if (isMouseOver) {
					textMesh.color = new Color(.9f, .9f, .9f);
					if (Input.GetMouseButtonDown(0) && menuScript.canClick) {
						clickSound.Play();
						menuScript.goToStageSelection(true);
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

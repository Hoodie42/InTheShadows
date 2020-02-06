using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{
	public void quitGameButton() {
		Application.Quit();
	}

	public void goToMainMenu() {
		GameObject.Find("GameCanvas").GetComponent<Animator>().Play("GameCanvasFadeIn", 0, 0f);
	}

	public void loadMainMenu() {
		SceneManager.LoadScene("MainMenu");
	}
}

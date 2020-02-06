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
		SceneManager.LoadScene("MainMenu");
	}
}

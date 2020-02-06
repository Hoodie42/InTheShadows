using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickQuitScript : MonoBehaviour
{
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			PlayerPrefs.SetInt("ItsProgression", 0);
		}
	}
}

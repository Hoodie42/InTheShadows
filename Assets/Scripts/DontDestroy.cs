using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
	void Start() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag("Music");

		if (objects.Length > 1)
			Destroy(gameObject);
		else
			DontDestroyOnLoad(gameObject);
	}
}

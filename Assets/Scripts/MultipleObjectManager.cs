using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleObjectManager : MonoBehaviour
{
	private GameObject[] objects;
	private int currentObject;

	void Start() {
		objects = GameObject.FindGameObjectsWithTag("ShadowForm");
		currentObject = 0;
	}

	void Update () {
		if (Input.GetMouseButtonDown(1)) {
			currentObject += 1;
			if (currentObject >= objects.Length)
				currentObject = 0;

			foreach(GameObject obj in objects) {
				obj.GetComponent<ClickRotationObject>().setFocus(false);
			}
		}
		objects[currentObject].GetComponent<ClickRotationObject>().setFocus(true);
	}
}

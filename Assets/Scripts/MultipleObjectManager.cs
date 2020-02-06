using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleObjectManager : MonoBehaviour
{
	public bool win;

	private GameObject[] objects;
	private int currentObject;
	private bool canFocus;

	void Start() {
		win = false;
		canFocus = true;
		currentObject = 0;

		if (GameObject.Find("MenuLogic")) {
			ObjectForm objToSpawn = GameObject.Find("MenuLogic").GetComponent<MenuScript>().objectForm;

			switch(objToSpawn) {
				case ObjectForm.Teapot:
					GameObject objectTeapot = Instantiate(Resources.Load<GameObject>("Prefabs/objectTeapot"));
					objectTeapot.name = "objectTeapot";
					break;
				case ObjectForm.Elephant:
					GameObject objectElephant = Instantiate(Resources.Load<GameObject>("Prefabs/objectElephant"));
					objectElephant.name = "objectElephant";
					break;
				case ObjectForm.Fortytwo:
					GameObject objectFour = Instantiate(Resources.Load<GameObject>("Prefabs/objectFour"));
					GameObject objectTwo = Instantiate(Resources.Load<GameObject>("Prefabs/objectTwo"));
					objectFour.name = "objectFour";
					objectTwo.name = "objectTwo";
					break;
				case ObjectForm.Globe:
					GameObject objectGlobe = Instantiate(Resources.Load<GameObject>("Prefabs/objectGlobe"));
					GameObject objectBase = Instantiate(Resources.Load<GameObject>("Prefabs/objectBase"));
					objectGlobe.name = "objectGlobe";
					objectBase.name = "objectBase";
					break;
			}
			Destroy(GameObject.Find("MenuLogic"));
		}
		objects = GameObject.FindGameObjectsWithTag("ShadowForm");
	}

	void LateUpdate () {
		if (!Input.GetMouseButton(0) && !canFocus && !win) {
			objects[currentObject].GetComponent<ClickRotationObject>().setFocus(false);
			win = true;
			GameObject.Find("GameCanvas").GetComponent<Animator>().Play("GameCanvasWin", 0, 0f);
		} else if (!win) {
			if (Input.GetMouseButtonDown(1)) {
				currentObject += 1;
				if (currentObject >= objects.Length)
					currentObject = 0;

				foreach(GameObject obj in objects) {
					obj.GetComponent<ClickRotationObject>().setFocus(false);
				}
			}
			objects[currentObject].GetComponent<ClickRotationObject>().setFocus(true);

			if (Input.GetMouseButton(0)) {
				canFocus = false;
				foreach(GameObject obj in objects) {
					if (!obj.GetComponent<ClickRotationObject>().isInPlace) {
						canFocus = true;
						break;
					}
				}
			}
		}
	}
}

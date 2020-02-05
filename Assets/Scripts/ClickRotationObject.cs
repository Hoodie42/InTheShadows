using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRotationObject : MonoBehaviour
{
	[SerializeField]
	private Vector3 tempVector;
	[SerializeField]
	private Vector3 originalMousePos;
	[SerializeField]
	private bool isRotHor;
	[SerializeField]
	private bool isRotVer;
	[SerializeField]
	private bool isMov;
	[SerializeField]
	private bool actionRegistered;

	void Start() {
		originalMousePos = Vector3.zero;
		isRotHor = false;
		isRotVer = false;
		isMov = false;
		actionRegistered = false;
	}

	void Update() {

		if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift) && !actionRegistered) {
			isRotHor = false;
			isRotVer = false;
			isMov = true;
			actionRegistered = true;
			originalMousePos = Input.mousePosition;
			tempVector = transform.position;
		} else if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftControl) && !actionRegistered) {
			isRotHor = false;
			isRotVer = true;
			isMov = false;
			actionRegistered = true;
			originalMousePos = Input.mousePosition;
			tempVector = transform.eulerAngles;
		} else if (Input.GetMouseButton(0) && !actionRegistered) {
			isRotHor = true;
			isRotVer = false;
			isMov = false;
			actionRegistered = true;
			originalMousePos = Input.mousePosition;
			tempVector = transform.eulerAngles;
		} else if (!Input.GetMouseButton(0) && actionRegistered) {
			isRotHor = false;
			isRotVer = false;
			isMov = false;
			actionRegistered = false;
		}

		if (isRotVer) {
			float tmp = originalMousePos.y - Input.mousePosition.y;
			if (tempVector.z != 180)
				transform.eulerAngles = new Vector3(tempVector.x + tmp, tempVector.y, tempVector.z);
			else
				transform.eulerAngles = new Vector3(tempVector.x - tmp, tempVector.y, tempVector.z);
		} else if (isRotHor) {
			float tmp = originalMousePos.x - Input.mousePosition.x;
			transform.eulerAngles = new Vector3(tempVector.x, tempVector.y + tmp, tempVector.z);
		} else if (isMov) {
			float tmpX = originalMousePos.x - Input.mousePosition.x;
			float tmpY = originalMousePos.y - Input.mousePosition.y;
			transform.position = new Vector3(tempVector.x - (tmpX * .01f), tempVector.y - (tmpY * .01f), transform.position.z);
		}
	}
}

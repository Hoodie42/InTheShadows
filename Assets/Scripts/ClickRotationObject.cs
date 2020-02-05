using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRotationObject : MonoBehaviour
{
	public Vector3 desiredRotation;
	public bool isFocusedOn;
	public bool isInPlace;

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

	private Light selfLight;
	private float rotFork;

	void Start() {
		originalMousePos = Vector3.zero;
		isRotHor = false;
		isRotVer = false;
		isMov = false;
		actionRegistered = false;
		isFocusedOn = false;
		isInPlace = false;
		selfLight = transform.Find("light").gameObject.GetComponent<Light>();
		selfLight.enabled = false;
		rotFork = 20f;
	}

	void Update() {
		//CHECK IF IN PLACE
		float diffX = Mathf.DeltaAngle(transform.eulerAngles.x, desiredRotation.x);
		float diffY = Mathf.DeltaAngle(transform.eulerAngles.y, desiredRotation.y);
		float diffZ = Mathf.DeltaAngle(transform.eulerAngles.z, desiredRotation.z);
		float difference = Mathf.Abs(diffX) + Mathf.Abs(diffY) + Mathf.Abs(diffZ);

		if(difference < rotFork) {
			isInPlace = true;
		} else {
			isInPlace = false;
		}

		// INPUTS
		if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift) && !actionRegistered && isFocusedOn) {
			isRotHor = false;
			isRotVer = false;
			isMov = true;
			actionRegistered = true;
			originalMousePos = Input.mousePosition;
			tempVector = transform.position;
		} else if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftControl) && !actionRegistered && isFocusedOn) {
			isRotHor = false;
			isRotVer = true;
			isMov = false;
			actionRegistered = true;
			originalMousePos = Input.mousePosition;
			tempVector = transform.eulerAngles;
		} else if (Input.GetMouseButton(0) && !actionRegistered && isFocusedOn) {
			isRotHor = true;
			isRotVer = false;
			isMov = false;
			actionRegistered = true;
			originalMousePos = Input.mousePosition;
			tempVector = transform.eulerAngles;
		} else if ((!Input.GetMouseButton(0) && actionRegistered) || !isFocusedOn) {
			isRotHor = false;
			isRotVer = false;
			isMov = false;
			actionRegistered = false;
		}

		// ROTATION - TRANSLATION
		if (isRotVer) {
			float tmp = originalMousePos.y - Input.mousePosition.y;
			if (tempVector.z != 180)
				transform.eulerAngles = new Vector3(tempVector.x + (tmp * .2f), tempVector.y, tempVector.z);
			else if (tempVector.z == 180)
				transform.eulerAngles = new Vector3(tempVector.x - (tmp * .2f), tempVector.y, tempVector.z);
		} else if (isRotHor) {
			float tmp = originalMousePos.x - Input.mousePosition.x;
			transform.eulerAngles = new Vector3(tempVector.x, tempVector.y + (tmp * .2f), tempVector.z);
		} else if (isMov) {
			float tmpX = originalMousePos.x - Input.mousePosition.x;
			float tmpY = originalMousePos.y - Input.mousePosition.y;
			transform.position = new Vector3(tempVector.x - (tmpX * .01f), tempVector.y - (tmpY * .01f), transform.position.z);
		}
	}

	public void setFocus(bool b) {
		selfLight.enabled = b;
		isFocusedOn = b;
	}

	private float convertAngles(float f) {
		while (f < 0f)
			f += 360f;
		while (f > 360f)
			f -= 360f;
		return f;
	}
}

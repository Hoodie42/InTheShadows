using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRotationObject : MonoBehaviour
{
	public Vector3[] desiredRotations;
	public Vector3 positionBetweenObjects;
	public string pairObject;
	public bool isFullyRandomized = true;
	public bool canBeFullyRotated = true;
	public bool canBeMoved = true;
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
	private float posFork;

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
		posFork = 1f;

		if (isFullyRandomized)
			transform.eulerAngles = new Vector3(Random.Range(45f, 315f), Random.Range(45f, 315f), 0f);
		else
			transform.eulerAngles = new Vector3(0f, Random.Range(45f, 315f), 0f);
	}

	void Update() {
		//CHECK IF IN PLACE
		foreach(Vector3 desiredRotation in desiredRotations) {
			float diffX = Mathf.DeltaAngle(transform.eulerAngles.x, desiredRotation.x);
			float diffY = Mathf.DeltaAngle(transform.eulerAngles.y, desiredRotation.y);
			float difference = Mathf.Abs(diffX) + Mathf.Abs(diffY);

			if(difference < rotFork) {
				if (pairObject != "") {
					Transform otherTransform = GameObject.Find(pairObject).transform;
					diffX = transform.position.x - otherTransform.position.x;
					diffY = transform.position.y - otherTransform.position.y;

					if (diffX < positionBetweenObjects.x + posFork && diffX > positionBetweenObjects.x - posFork
						&& diffY < positionBetweenObjects.y + posFork && diffY > positionBetweenObjects.y - posFork) {
						isInPlace = true;
						break;
					} else {
						isInPlace = false;
					}
				} else {
					isInPlace = true;
					break;
				}
			} else {
				isInPlace = false;
			}
		}

		// INPUTS
		if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift) && canBeMoved && !actionRegistered && isFocusedOn) {
			isRotHor = false;
			isRotVer = false;
			isMov = true;
			actionRegistered = true;
			originalMousePos = Input.mousePosition;
			tempVector = transform.position;
		} else if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftControl) && canBeFullyRotated && !actionRegistered && isFocusedOn) {
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

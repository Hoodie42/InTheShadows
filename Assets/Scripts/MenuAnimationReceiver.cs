using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimationReceiver : MonoBehaviour
{
	public void loadObject() {
		GameObject.Find("MenuLogic").GetComponent<MenuScript>().loadObject();
	}
}

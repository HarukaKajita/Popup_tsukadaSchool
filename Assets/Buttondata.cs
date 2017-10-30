using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttondata : MonoBehaviour{
	public static Button yesButton;
	public static Button noButton;
	public static Button aButton;
	public static Button bButton;
	public static Button cButton;

	public static void Setup(){
		yesButton = GameObject.Find ("Canvas/Panel/YesButton").GetComponent<Button>();
		noButton = GameObject.Find ("Canvas/Panel/NoButton").GetComponent<Button>();
		aButton = GameObject.Find ("Canvas/Panel/AButton").GetComponent<Button>();
		bButton = GameObject.Find ("Canvas/Panel/BButton").GetComponent<Button>();
		cButton = GameObject.Find ("Canvas/Panel/CButton").GetComponent<Button>();
	}

}

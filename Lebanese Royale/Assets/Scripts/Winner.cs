﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Winner : MonoBehaviour {
	const int buttonWidth=200;
	const int buttonHeight=84;
	public Text WinnerText;
	GUISkin skin;

	void Start () {
		skin= Resources.Load("GUISkin") as GUISkin;
		string winner = MainGame.Load();
		WinnerText.text="Chicken Dinner Mr."+winner;
	}
	
	void Update () {
		
	}

	void OnGUI(){
		GUI.skin=skin;
		if(GUI.Button(new Rect(Screen.width/2-(buttonWidth/2),(2*Screen.height/3)-(buttonHeight/2),buttonWidth,buttonHeight),"Go To Menu")){
			Application.LoadLevel("Menu");
		}
	}

}

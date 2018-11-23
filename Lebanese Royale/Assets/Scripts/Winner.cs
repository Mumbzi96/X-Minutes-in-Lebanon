using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Winner : MonoBehaviour {
	const int buttonWidth=84;
	const int buttonHeight=60;
	public Text WinnerText;
	// Use this for initialization
	void Start () {
		string winner = MainGame.Load();
		WinnerText.text="Chicken Dinner Mr."+winner;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		
		
		if(GUI.Button(new Rect(Screen.width/2-(buttonWidth/2),(2*Screen.height/3)-(buttonHeight/2),buttonWidth,buttonHeight),"Go To Menu")){
			Application.LoadLevel("Menu");
		}
	}

}

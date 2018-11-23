using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Menu : MonoBehaviour {
		const int buttonWidth=84;
		const int buttonHeight=60;

	void OnGUI(){
		
		
		if(GUI.Button(new Rect(Screen.width/2-(buttonWidth/2),(2*Screen.height/3)-(buttonHeight/2),buttonWidth,buttonHeight),"Start")){
			Application.LoadLevel("GameScene");
		}
	}
}

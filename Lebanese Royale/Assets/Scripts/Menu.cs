﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Menu : MonoBehaviour {
	const int buttonWidth=200;
	const int buttonHeight=84;
	GUISkin skin;

	void Start(){
		
		skin= Resources.Load("GUISkin") as GUISkin;
	}

	void OnGUI(){
		
		GUI.skin=skin;
		if(GUI.Button(new Rect(Screen.width/2-(buttonWidth/2),(2*Screen.height/3)-(buttonHeight/2),buttonWidth,buttonHeight),"Start")){
			Save();
			SceneManager.LoadScene("GameScene");
		}
	}

	public static void Save(){
		string savePath=Application.persistentDataPath+"/winner.dat";
		BinaryFormatter bf = new BinaryFormatter();
		PlayerData data = new PlayerData();
		
		// Dirty Work
		using (var file = File.Create(savePath)){
			bf.Serialize(file,data);
		}
	}
	
}

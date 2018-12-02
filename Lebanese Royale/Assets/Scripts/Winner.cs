using System.Collections;
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
		string winner = Load();
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

	public static string Load(){
		string savePath=Application.persistentDataPath+"/winner.dat";
		string winner="0";
		if (File.Exists(savePath)){
			BinaryFormatter bf = new BinaryFormatter();
			using (var file = File.Open(savePath, FileMode.Open)){
				PlayerData data = (PlayerData)bf.Deserialize(file);
				winner = data.mainWinner;
			}
			return winner;
		}
		else return winner;
	}

}

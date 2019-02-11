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
	public Text TimeText;
	GUISkin skin;

	void Start () {
		PlayerData data = Load();
		WinnerText.text=data.mainWinner + " wins!";
		//Time fixes
		data.time=(int)(data.time/60);
		if(data.time<1)
		data.time++;
		data.time+=5;
		TimeText.text="You stayed "+data.time + " minutes in Lebanon";
		
		
	}
	
	public void PlayGame(){
		SceneManager.LoadScene("Menu");
	}

	public static PlayerData Load(){
		string savePath=Application.persistentDataPath+"/winner.dat";
		PlayerData data= new PlayerData();
		if (File.Exists(savePath)){
			BinaryFormatter bf = new BinaryFormatter();
			using (var file = File.Open(savePath, FileMode.Open)){
				data = (PlayerData)bf.Deserialize(file);
			}
			return data;
		}
		else return data;
	}

}

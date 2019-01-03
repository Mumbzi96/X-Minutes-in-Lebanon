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
		string winner = Load();
		WinnerText.text=winner + " wins!";
	}
	
	public void PlayGame(){
		SceneManager.LoadScene("Menu");
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

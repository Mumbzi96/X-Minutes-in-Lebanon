using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Menu : MonoBehaviour {

	public static bool isCringeMode=true;

	void Start(){
	}

	public void PlayGame(){
		Save();
		isCringeMode=true;
		SceneManager.LoadScene("BoardScene");
	}

	static void Save(){
		string savePath=Application.persistentDataPath+"/winner.dat";
		BinaryFormatter bf = new BinaryFormatter();
		PlayerData data = new PlayerData();
		
		// Dirty Work
		using (var file = File.Create(savePath)){
			bf.Serialize(file,data);
		}
	}
	
	public void OpenMiniGame(string toPlay){
		isCringeMode=false;
		SceneManager.LoadScene(toPlay);
	}
	
}

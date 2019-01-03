using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class WinnerFoL : MonoBehaviour {
	const int buttonWidth=200;
	const int buttonHeight=84;
	public Text WinnerText;

	void Start () {
		PlayerData winner = MainFG.Load();
		WinnerText.text="Great job Player "+winner.lastWinner;
	}

	public void PlayGame(){
		SceneManager.LoadScene("GameScene");
	}
	
	void Update () {
		
	}

}

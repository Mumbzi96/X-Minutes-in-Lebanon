﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class WinnerFG : MonoBehaviour {
	public Text WinnerText;

	void Start () {
		PlayerData winner = MainFG.Load();
		WinnerText.text="Player " +winner.lastWinner + " wins!";
	}

	public void PlayGame(){
		SceneManager.LoadScene("BoardScene");
	}

	void Update () {
		
	}
}

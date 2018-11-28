using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MainFG : MonoBehaviour {
	// //Object to instantiate at start
	// public Player player1; 
	// public Player player2;
	//UI objects to update
	public Text player1score;
	public Text player2score;
	public Text timeText;
	//UI helpers
	private float time=30f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Timer();
		Scores();
		//7dud collider or no exiting camera
		//InputEnabled boolean for when game ends
		//SpawnFood with points()
		//GameOver()
		//Save and Load after gamer over
	}

	// Mainly text updates
	void Timer(){
		time-=Time.deltaTime;
		int seconds=(int)time;
		timeText.text=seconds.ToString();
	}

	void Scores(){
		GameObject player1t= GameObject.FindWithTag("Player1");
		GameObject player2t= GameObject.FindWithTag("Player2");
		player1score.text="Player1: "+player1t.GetComponent<PlayerFG>().points.ToString();
		player2score.text="Player2: "+player2t.GetComponent<PlayerFG>().points.ToString();
	}
}

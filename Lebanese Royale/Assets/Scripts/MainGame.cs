using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MainGame : MonoBehaviour {
	//Object to instantiate at start
	public Floor FloorObject;
	public Floor StartFloor;
	public Floor FinalFloor;
	public Player player; 
	//UI objects to update
	public Text player1score;
	public Text player2score;
	public Text cityNameText;
	//UI helpers
	private static float time;
	public static int spacer=25;
	// Other Helpers
	static string[] miniGames={"MenuFG","MenuFoL"};
	static int _currentMiniGame=0;
	public static int currentMiniGame{
		get{
			_currentMiniGame++;
			if (_currentMiniGame>=miniGames.Length){
				_currentMiniGame=0;
			}
			return _currentMiniGame;
		}
	}
	//Static values
	public static bool InputEnabled= true;
	
	//Functions START HERE
	void Start () {
		Load();
		SoundEffectsHelper.Instance.MakeButtonPressSound();
		player.tag="Player1";
		InputEnabled= true;

	}
	
	void Update () {
		Scores();
		CameraFollow();
		CityOn();
		if(InputEnabled==true){
			Turns();
		}
		
	}
	// Mainly text updates
	void Scores(){
		GameObject player1t= GameObject.FindWithTag("Player1");
		// GameObject player2t= GameObject.FindWithTag("Player2");
		player1score.text="Player1: "+player1t.GetComponent<Player>().points.ToString();
		// player2score.text="Player2: "+player2t.GetComponent<Player>().points.ToString();
	}
	// Mainly updates with a button click 
	void Turns(){
		if (Input.GetKeyUp(KeyCode.Space)){
			GameObject player= GameObject.FindWithTag("Player1");
			// int diceRoll=Random.Range(1,6);
			// diceRollText.text="Roll: "+diceRoll;
			player.GetComponent<Player>().Move(3,"Right");
		}
	}
	void CameraFollow(){
		GameObject something= GameObject.FindWithTag("Player1");
		Vector3 pos=something.transform.position;
		transform.SetPositionAndRotation(new Vector3(pos.x,pos.y,-10),new Quaternion(0,0,0,0));
	}

	public void CityOn(){
		GameObject something= GameObject.FindWithTag("Player1");
		cityNameText.text=something.GetComponent<Player>().CityOn;
	}

	// Statics
	public static void SetWinner(){
		// string winner;
		// // Getting Points
		// GameObject[] players= GetPlayers();
		// int mainp1Points=players[0].GetComponent<Player>().points;
		// int mainp2Points=players[1].GetComponent<Player>().points;
		// // Deciding winner
		// if(mainp1Points>mainp2Points)
		// 	winner="Player 1";
		// else if(mainp1Points<mainp2Points)
		// 	winner="Player 2";
		// else
		// 	winner="You're in Lebanon... NO ONE WINS!";
		// Save(winner);
		// SceneManager.LoadScene("Winner");
	}
	public static void Save(string winner){
		// string savePath=Application.persistentDataPath+"/winner.dat";
		// BinaryFormatter bf = new BinaryFormatter();
		// PlayerData data = new PlayerData();
		
		// // Getting Players from the scene
		// GameObject[] players= GetPlayers();
		// // Saving Points
		// data.mainp1Points=players[0].GetComponent<Player>().points;
		// data.mainp2Points=players[1].GetComponent<Player>().points;
		// // Saving positions
		// data.p1Pos= new LastPosition(players[0].transform.position.x,players[0].transform.position.y,players[0].transform.position.z);
		// data.p2Pos= new LastPosition(players[1].transform.position.x,players[1].transform.position.y,players[1].transform.position.z);
		// // Saving other stuff
		// data.mainWinner=winner;
		// data.time=time;
		// // Dirty Work
		// using (var file = File.Create(savePath)){
		// 	bf.Serialize(file,data);
		// }
	}

	// static GameObject[] GetPlayers(){
	// 	GameObject player1t= GameObject.FindWithTag("Player1");
	// 	GameObject player2t= GameObject.FindWithTag("Player2");
	// 	GameObject[] players=new GameObject[MainGame.Players];
	// 	players[0]=player1t;
	// 	players[1]=player2t;
	// 	return players;
	// }

	public static void Load(){
		// string savePath=Application.persistentDataPath+"/winner.dat";
		
		// if (File.Exists(savePath)){
		// 	BinaryFormatter bf = new BinaryFormatter();
		// 	using (var file = File.Open(savePath, FileMode.Open)){
		// 		PlayerData data = (PlayerData)bf.Deserialize(file);
		// 			// This "if" condition is to reset all data if its a new game
		// 			if(data.mainWinner=="hyye"){
		// 				// Getting players in the scene
		// 				GameObject[] players= GetPlayers();
		// 				// Setting Points back
		// 				players[0].GetComponent<Player>().points=data.mainp1Points;
		// 				players[1].GetComponent<Player>().points=data.mainp2Points;
		// 				// Setting positions back
		// 				players[0].transform.position= new Vector3(data.p1Pos.pX,data.p1Pos.pY,data.p1Pos.pZ);
		// 				players[1].transform.position= new Vector3(data.p2Pos.pX,data.p2Pos.pY,data.p2Pos.pZ);
		// 				// Setting time back
		// 				time=data.time;
		// 			}
		// 	}
		// }
	}


}



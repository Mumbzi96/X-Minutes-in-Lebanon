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
	public Player player1; 
	public Player player2; 
	//UI objects to update
	public Text player1score;
	public Text player2score;
	public Text timeText;
	public Text diceRollText;
	public Text playerTurn;
	//UI helpers
	private static float time;
	public static int spacer=6;
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
	public static int tileNumbers=20;
	public static int Players = 2;
	private static int turn = 1;
	public static string Turn{
		get{
			return "Player"+turn;
		}
		set{
			turn++;
			if (turn>Players){
				Save("hyye");
				turn=1;
				SceneManager.LoadScene(miniGames[currentMiniGame]);
			}
		}
	}
	
	//Functions START HERE
	void Start () {
		Load();
		SoundEffectsHelper.Instance.MakeButtonPressSound();
		// AddFloors();
		// AddPlayers();
		player1.tag="Player1";
		player2.tag="Player2";
		InputEnabled= true;
		// InvokeRepeating("StartSimulation",2,2);

	}

	void AddFloors(){
		//Position numba wan
		Vector3 pos= new Vector3(0,0);
		//Add start Floor
		Instantiate(StartFloor,pos,new Quaternion(0,0,0,0));
		float newX=pos.x +spacer;
		float newY=0;
		pos.Set(newX,pos.y,0);
		//Add event Floors
		for (int i=0;i<tileNumbers;i++){
			if(i==2&&i!=0){
				FloorObject.tag="GoDown";
				Instantiate(FloorObject,pos,new Quaternion(0,0,0,0));
				newY=pos.y -spacer;
				pos.Set(pos.x,newY,0);
			}
			else if(i==5&&i!=0){
				FloorObject.tag="GoUp";
				Instantiate(FloorObject,pos,new Quaternion(0,0,0,0));
				newY=pos.y +spacer;
				pos.Set(pos.x,newY,0);
			}
			// else if(i==6&&i!=0){
			// 	FloorObject.tag="GoLeft";
			// 	Instantiate(FloorObject,pos,new Quaternion(0,0,0,0));
			// 	newX=pos.x -spacer;
			// 	pos.Set(newX,pos.y,0);;
			// }
			else{
				FloorObject.tag="GoRight";
				Instantiate(FloorObject,pos,new Quaternion(0,0,0,0));
				newX=pos.x +spacer;
				pos.Set(newX,pos.y,0);
			}
			
		}
		//Final Map Position
		Instantiate(FinalFloor,pos,new Quaternion(0,0,0,0));
		Debug.Log("Added Floors");
	}

	void AddPlayers(){
		Vector3 pos1= new Vector3(0,0);
		Vector3 pos2= new Vector3(0,0);
		Instantiate(player1,pos1,new Quaternion(0,0,0,0));
		Instantiate(player2,pos2,new Quaternion(0,0,0,0));
		Debug.Log("Added players");

	}

	void StartSimulation(){
		// GameObject player1t= GameObject.FindWithTag("Player1");
		// GameObject player2t= GameObject.FindWithTag("Player2");
		// int turn=Random.Range(1,6);
		// player1t.GetComponent<Player>().Move(turn,"Right");
		// turn=Random.Range(1,6);
		// player2t.GetComponent<Player>().Move(turn,"Right");
		
	}
	
	void Update () {
		Timer();
		Scores();
		CameraFollow();
		if(InputEnabled==true){
			
			Turns();
		}
		
	}
	// Mainly text updates
	void Timer(){
		time=Time.time;
		string minutes = ((int)time/60).ToString();
		string seconds = ((int)time%60).ToString();
		timeText.text=minutes + ":" +seconds;
	}
	void Scores(){
		GameObject player1t= GameObject.FindWithTag("Player1");
		GameObject player2t= GameObject.FindWithTag("Player2");
		playerTurn.text=Turn;
		player1score.text="Player1: "+player1t.GetComponent<Player>().points.ToString();
		player2score.text="Player2: "+player2t.GetComponent<Player>().points.ToString();
	}
	// Mainly updates with a button click 
	void Turns(){
		if (Input.GetKeyUp(KeyCode.Space)){
			GameObject player= GameObject.FindWithTag(Turn);
			int diceRoll=Random.Range(1,6);
			diceRollText.text="Roll: "+diceRoll;
			player.GetComponent<Player>().Move(diceRoll,"Right");
		}
	}
	void CameraFollow(){
		GameObject something= GameObject.FindWithTag(Turn);
		Vector3 pos=something.transform.position;
		transform.SetPositionAndRotation(new Vector3(pos.x,pos.y,-10),new Quaternion(0,0,0,0));
	}

	// Statics
	public static void SetWinner(string winner){
		Save(winner);
		SceneManager.LoadScene("Winner");
	}
	public static void Save(string winner){
		string savePath=Application.persistentDataPath+"/winner.dat";
		BinaryFormatter bf = new BinaryFormatter();
		PlayerData data = new PlayerData();
		
		// Getting Players from the scene
		GameObject[] players= GetPlayers();
		// Saving Points
		data.mainp1Points=players[0].GetComponent<Player>().points;
		data.mainp2Points=players[1].GetComponent<Player>().points;
		// Saving positions
		data.p1Pos= new LastPosition(players[0].transform.position.x,players[0].transform.position.y,players[0].transform.position.z);
		data.p2Pos= new LastPosition(players[1].transform.position.x,players[1].transform.position.y,players[1].transform.position.z);
		// Saving other stuff
		data.mainWinner=winner;
		data.time=time;
		// Dirty Work
		using (var file = File.Create(savePath)){
			bf.Serialize(file,data);
		}
	}
	static GameObject[] GetPlayers(){
		GameObject player1t= GameObject.FindWithTag("Player1");
		GameObject player2t= GameObject.FindWithTag("Player2");
		GameObject[] players=new GameObject[MainGame.Players];
		players[0]=player1t;
		players[1]=player2t;
		return players;
	}

	public static void Load(){
		string savePath=Application.persistentDataPath+"/winner.dat";
		
		if (File.Exists(savePath)){
			BinaryFormatter bf = new BinaryFormatter();
			using (var file = File.Open(savePath, FileMode.Open)){
				PlayerData data = (PlayerData)bf.Deserialize(file);
					// This "if" condition is to reset all data if its a new game
					if(data.mainWinner=="hyye"){
						// Getting players in the scene
						GameObject[] players= GetPlayers();
						// Setting Points back
						players[0].GetComponent<Player>().points=data.mainp1Points;
						players[1].GetComponent<Player>().points=data.mainp2Points;
						// Setting positions back
						players[0].transform.position= new Vector3(data.p1Pos.pX,data.p1Pos.pY,data.p1Pos.pZ);
						players[1].transform.position= new Vector3(data.p2Pos.pX,data.p2Pos.pY,data.p2Pos.pZ);
						// Setting time back
						time=data.time;
					}
			}
		}
	}
}



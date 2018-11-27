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
	private float time;
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
				turn=1;
			}
		}
	}
	

	//Functions START HERE
	
	void Start () {
		SoundEffectsHelper.Instance.MakeButtonPressSound();
		AddFloors();
		AddPlayers();
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
		float newX=pos.x +7;
		float newY=0;
		pos.Set(newX,pos.y,0);
		//Add event Floors
		for (int i=0;i<tileNumbers;i++){
			if(i==2&&i!=0){
				FloorObject.tag="GoDown";
				Instantiate(FloorObject,pos,new Quaternion(0,0,0,0));
				newY=pos.y -7;
				pos.Set(pos.x,newY,0);
			}
			else if(i==5&&i!=0){
				FloorObject.tag="GoUp";
				Instantiate(FloorObject,pos,new Quaternion(0,0,0,0));
				newY=pos.y +7;
				pos.Set(pos.x,newY,0);
			}
			// else if(i==6&&i!=0){
			// 	FloorObject.tag="GoLeft";
			// 	Instantiate(FloorObject,pos,new Quaternion(0,0,0,0));
			// 	newX=pos.x -7;
			// 	pos.Set(newX,pos.y,0);;
			// }
			else{
				FloorObject.tag="GoRight";
				Instantiate(FloorObject,pos,new Quaternion(0,0,0,0));
				newX=pos.x +7;
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
		GameObject player1t= GameObject.FindWithTag("Player1");
		GameObject player2t= GameObject.FindWithTag("Player2");
		int turn=Random.Range(1,6);
		player1t.GetComponent<Player>().Move(turn,"Right");
		turn=Random.Range(1,6);
		player2t.GetComponent<Player>().Move(turn,"Right");
		
	}
	
	// Update is called once per frame
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
		GameObject turnT= GameObject.FindWithTag(Turn);
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
			int turn=Random.Range(1,6);
			diceRollText.text="Roll: "+turn.ToString();
			player.GetComponent<Player>().Move(turn,"Right");
		}
	}
	void CameraFollow(){
		GameObject something= GameObject.FindWithTag(Turn);
		Vector3 pos=something.transform.position;
		transform.SetPositionAndRotation(new Vector3(pos.x,pos.y,-10),new Quaternion(0,0,0,0));
	}

	// Statics
	public static void SetWinner(string winner){
		Debug.Log(winner);
		Save(winner);
		Application.LoadLevel("Winner");
		// SceneManager.LoadScene("Winner");
	}
	public static void Save(string winner){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath+"/winner.dat");
		
		PlayerData data = new PlayerData();
		data.winner=winner;
		bf.Serialize(file,data);
		file.Close();
	}
	public static string Load(){
		if (File.Exists(Application.persistentDataPath+"/winner.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath+"/winner.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();
			string winner = data.winner;
			return winner;
		}
		else return "0";
	}
}

[System.Serializable]
class PlayerData{
	public string winner;
}

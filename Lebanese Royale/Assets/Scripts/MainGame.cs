using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MainGame : MonoBehaviour {
	// Points
	public static int Player1Points;
	public static int Player2Points;
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
	static string[] miniGames={"FoLTutorial","lebolympicsTutorial","MenuRT"};
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
		
		Player1Points=0;
		Player2Points=0;
		player.tag="Player1";
		InputEnabled= true;
		SoundEffectsHelper.Instance.MakeButtonPressSound();
		Load();
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
		player1score.text="Player1: "+Player1Points.ToString();
		player2score.text="Player2: "+Player2Points.ToString();
	}

	// Mainly updates with a button click 
	void Turns(){
		if (Input.GetKeyUp(KeyCode.Space)){
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

	public static void LoadMiniGame(){
		Save("hyye");
		SceneManager.LoadScene(miniGames[currentMiniGame]);
	}

	// Statics
	public static void SetWinner(){
		string winner;
		// Getting Points
		int mainp1Points=Player1Points;
		int mainp2Points=Player2Points;
		// Deciding winner
		if(mainp1Points>mainp2Points)
			winner="Player 1";
		else if(mainp1Points<mainp2Points)
			winner="Player 2";
		else
			winner="You're in Lebanon... NO ONE WINS!";
		Save(winner);
		SceneManager.LoadScene("Winner");
	}
	
	public static void Save(string winner){
		string savePath=Application.persistentDataPath+"/winner.dat";
		BinaryFormatter bf = new BinaryFormatter();
		PlayerData data = new PlayerData();
		GameObject player= GameObject.FindWithTag("Player1");
		
		// Saving Points
		data.mainp1Points=Player1Points;
		data.mainp2Points=Player2Points;
		// Saving position
		data.lastPosition= new LastPosition(player.transform.position.x,player.transform.position.y,player.transform.position.z);
		// Saving other stuff
		data.mainWinner=winner;
		data.time=time;
		// Dirty Work
		using (var file = File.Create(savePath)){
			bf.Serialize(file,data);
		}
	}

	public static void Load(){
		string savePath=Application.persistentDataPath+"/winner.dat";
		GameObject player= GameObject.FindWithTag("Player1");

		if (File.Exists(savePath)){
			BinaryFormatter bf = new BinaryFormatter();
			using (var file = File.Open(savePath, FileMode.Open)){
				PlayerData data = (PlayerData)bf.Deserialize(file);
					// This "if" condition is to reset all data if its a new game
					if(data.mainWinner=="hyye"){
						// Setting Points back
						Player1Points=data.mainp1Points;
						Player2Points=data.mainp2Points;
						// Setting positions back
						player.transform.position= new Vector3(data.lastPosition.pX,data.lastPosition.pY,data.lastPosition.pZ);
						// Setting time back
						time=data.time;
					}
			}
		}
	}


}



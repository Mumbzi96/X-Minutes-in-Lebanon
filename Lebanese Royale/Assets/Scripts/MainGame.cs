using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	//UI helpers
	private float time;
	//Static values
	public static string Following="Player2";
	public static int tileNumbers=20;

	
	// Use this for initialization
	void Start () {
		AddFloors();
		AddPlayers();
		player1.tag="Player1";
		player2.tag="Player2";
		InvokeRepeating("StartSimulation",2,2);

	}
	
	// Update is called once per frame
	void Update () {
		Timer();
		Scores();
		CameraFollow();

	}
	void CameraFollow(){
		GameObject something= GameObject.FindWithTag(Following);
		Vector3 pos=something.transform.position;
		transform.SetPositionAndRotation(new Vector3(pos.x,pos.y,-10),new Quaternion(0,0,0,0));
	}

	void AddFloors(){
		//Position numba wan
		Vector3 pos= new Vector3(0,0);
		//Add start Floor
		Instantiate(StartFloor,pos,new Quaternion(0,0,0,0));
		float newX=pos.x +7;
		pos.Set(newX,pos.y,0);
		//Add event Floors
		for (int i=0;i<tileNumbers;i++){
			Instantiate(FloorObject,pos,new Quaternion(0,0,0,0));
			newX=pos.x +7;
			pos.Set(newX,pos.y,0);
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
	void Scores(){
		GameObject player1t= GameObject.FindWithTag("Player1");
		GameObject player2t= GameObject.FindWithTag("Player2");
		player1score.text="Player1: "+player1t.GetComponent<Player>().points.ToString();
		player2score.text="Player2: "+player2t.GetComponent<Player>().points.ToString();

	}
	
	void Timer(){
		time=Time.time;
		string minutes = ((int)time/60).ToString();
		string seconds = ((int)time%60).ToString();
		if(time>=20)
			timeText.text="GAME OVER!";
		else
			timeText.text=minutes + ":" +seconds;
	}

	void StartSimulation(){
		GameObject player1t= GameObject.FindWithTag("Player1");
		GameObject player2t= GameObject.FindWithTag("Player2");
		int turn=Random.Range(1,6);
		player1t.GetComponent<Player>().Move(turn);
		turn=Random.Range(1,6);
		player2t.GetComponent<Player>().Move(turn);
		
	}
}

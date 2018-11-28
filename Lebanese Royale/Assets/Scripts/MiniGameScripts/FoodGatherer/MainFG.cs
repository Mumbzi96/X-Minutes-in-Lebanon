using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MainFG : MonoBehaviour {
	// Public objects
	public FoodFG ba2lewa;
	public FoodFG bread;
	public FoodFG falefel;
	public FoodFG ftayer;
	public FoodFG ful;
	public FoodFG kabse;
	public FoodFG shawerma;
	public FoodFG tabbuleh;
	public FoodFG wings;
	// Helpers
	FoodFG[] allCuisines = new FoodFG[9];
	// UI objects to update
	public Text player1score;
	public Text player2score;
	public Text timeText;
	// UI helpers
	private float time=30f;

	// Use this for initialization
	void Start () {
		AddFoodList();
		InvokeRepeating("SpawnFood",1,1);
	}
	void AddFoodList(){
		allCuisines[0]=ba2lewa;
		allCuisines[1]=bread;
		allCuisines[2]=falefel;
		allCuisines[3]=ftayer;
		allCuisines[4]=ful;
		allCuisines[5]=kabse;
		allCuisines[6]=shawerma;
		allCuisines[7]=tabbuleh;
		allCuisines[8]=wings;
	}
	
	// Update is called once per frame
	void Update () {
		Timer();
		Scores();
		//7dud collider or no exiting camera
		//InputEnabled boolean for when game ends
		//GameOver()
		//Save and Load after gamer over
	}

	void SpawnFood(){
		int size=(int)(Camera.main.orthographicSize-0.5);
		// Debug.Log(Camera.main.orthographicSize);
		int x=Random.Range(-size,size);
		int y=Random.Range(-size,size);
		int toSpawn=Random.Range(0,allCuisines.Length);
		Vector3 pos= new Vector3(x,y);
		Instantiate(allCuisines[toSpawn],pos,new Quaternion(0,0,0,0));
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

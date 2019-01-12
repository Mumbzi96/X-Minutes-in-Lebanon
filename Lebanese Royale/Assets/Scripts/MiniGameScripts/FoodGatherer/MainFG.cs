using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MainFG : MonoBehaviour {
	// Public objects
	// Food
	public FoodFG ba2lewa;
	public FoodFG bread;
	public FoodFG falefel;
	public FoodFG ftayer;
	public FoodFG ful;
	public FoodFG kabse;
	public FoodFG shawerma;
	public FoodFG tabbuleh;
	public FoodFG wings;
	// Weapons
	public Weapon pencil;
	public Weapon ak47;
	public Weapon rpg;

	// Helpers
	FoodFG[] allCuisines = new FoodFG[9];
	Weapon[] allWeapons = new Weapon[3];
	public static bool isGameEnabled= true;
	// UI objects to update
	public Text player1score;
	public Text player2score;
	public Text timeText;
	// UI helpers
	private float time=60f;

	// Use this for initialization
	void Start () {
		isGameEnabled=true;
		AddFoodList();
		AddWeaponList();
		InvokeRepeating("SpawnFood",1,3);
		InvokeRepeating("SpawnWeapons",1,8);
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
	void AddWeaponList(){
		allWeapons[0]=pencil;
		allWeapons[1]=ak47;
		allWeapons[2]=rpg;
	}
	// Update is called once per frame
	void Update () {
		if(isGameEnabled==true){
			Timer();
			Scores();
		}
	}

	void SpawnFood(){
		int size=(int)(Camera.main.orthographicSize-0.5);
		int x=Random.Range(-size,size);
		int y=Random.Range(-size,size);
		int toSpawn=Random.Range(0,allCuisines.Length);
		Vector3 pos= new Vector3(x,y);
		Instantiate(allCuisines[toSpawn],pos,new Quaternion(0,0,0,0));
	}
	void SpawnWeapons(){
		int size=(int)(Camera.main.orthographicSize-0.5);
		int x=Random.Range(-size,size);
		int y=Random.Range(-size,size);
		int toSpawn=Random.Range(0,allWeapons.Length);
		Vector3 pos= new Vector3(x,y);
		Instantiate(allWeapons[toSpawn],pos,new Quaternion(0,0,0,0));
	}

	// Mainly text updates
	void Timer(){
		time-=Time.deltaTime;
		int seconds=(int)time;
		timeText.text=seconds.ToString();
		if(time<=0){
			isGameEnabled=false;
			CancelInvoke("SpawnFood");
			Save();
			SceneManager.LoadScene("WinnerFG");
		}
	}
	static GameObject[] GetPlayers(){
		GameObject player1t= GameObject.FindWithTag("Player1");
		GameObject player2t= GameObject.FindWithTag("Player2");
		GameObject[] players=new GameObject[2];
		players[0]=player1t;
		players[1]=player2t;
		return players;
	}
	void Scores(){
		GameObject player1t= GameObject.FindWithTag("Player1");
		GameObject player2t= GameObject.FindWithTag("Player2");
		player1score.text="Player1: "+player1t.GetComponent<PlayerFG>().points.ToString();
		player2score.text="Player2: "+player2t.GetComponent<PlayerFG>().points.ToString();
	}


	// Statics
	public static void Save(){
		// Deciding scores
		GameObject[] players=GetPlayers();
		int p1points = players[0].GetComponent<PlayerFG>().points;
		int p2points = players[1].GetComponent<PlayerFG>().points;
		string winner;
		if(p1points>p2points)
			winner="1";
		else if (p2points>p1points)
			winner="2";
		else winner="0";
		PlayerData data = Load();


		// Actually saving
		string savePath=Application.persistentDataPath+"/winner.dat";
		BinaryFormatter bf = new BinaryFormatter();
		// Adding main points to data
		if(winner=="1")
			data.mainp1Points+=10;
		else if(winner=="2")
			data.mainp2Points+=10;
		// Saving the games last points (sa2ale)
		data.lastp1Points=p1points;
		data.lastp2Points=p2points;
		data.lastWinner=winner;

		using (var file = File.Create(savePath)){
			bf.Serialize(file,data);
		}
	}
	public static PlayerData Load(){
		string savePath=Application.persistentDataPath+"/winner.dat";
		PlayerData data=new PlayerData();
		if (File.Exists(savePath)){
			BinaryFormatter bf = new BinaryFormatter();
			using (var file = File.Open(savePath, FileMode.Open)){
				data = (PlayerData)bf.Deserialize(file);
			}
			return data;
		}
		else return new PlayerData();
	}
}

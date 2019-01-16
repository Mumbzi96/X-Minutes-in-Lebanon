using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MainRT : MonoBehaviour {

	public GameObject enemy;
	public static bool inputEnabled=true;
	private const float time=60f;
	private float timer=60f;

	// ShooterSides
	public GameObject leftSide;
	public GameObject rightSide;
	public GameObject upSide;
	public GameObject downSide;

	// Public texts
	public Text P1Health;
	public Text P2Health;
	public Text TimeText;

	void Start () {
		InvokeRepeating("SpawnEnemy",1,5);
	}
	
	void Update () {
		Timer();
		Health();
	}

	void ChooseShooters(){
		int chosenSides= Random.Range(0,3);
		if(timer>=57){
			leftSide.SetActive(true);
			rightSide.SetActive(false);
			upSide.SetActive(false);
			downSide.SetActive(false);
		}
		else if(timer>=53){
			leftSide.SetActive(false);
			rightSide.SetActive(true);
			upSide.SetActive(false);
			downSide.SetActive(false);
		}
		else if(timer>=50){
			leftSide.SetActive(true);
			rightSide.SetActive(false);
			upSide.SetActive(false);
			downSide.SetActive(false);
		}
		else if(timer>=10){
			if(chosenSides==0){
				leftSide.SetActive(true);
				rightSide.SetActive(false);
				upSide.SetActive(true);
				downSide.SetActive(false);
			}
			else if(chosenSides==1){
				leftSide.SetActive(false);
				rightSide.SetActive(true);
				upSide.SetActive(false);
				downSide.SetActive(true);
			}
			else if(chosenSides==2){
				leftSide.SetActive(true);
				rightSide.SetActive(true);
				upSide.SetActive(false);
				downSide.SetActive(false);
			}
			else if(chosenSides==3){
				leftSide.SetActive(false);
				rightSide.SetActive(false);
				upSide.SetActive(true);
				downSide.SetActive(true);
			}
		}
		else{
			leftSide.SetActive(true);
			rightSide.SetActive(false);
			upSide.SetActive(true);
			downSide.SetActive(true);
		}


	}

	void SpawnEnemy(){
		// Random Position
		int size=(int)(Camera.main.orthographicSize-0.5);
		int x=Random.Range(-size,size);
		int y=Random.Range(-size,size);
		Vector3 pos= new Vector3(x,y);
		// Random Rotation
		int rotation=Random.Range(0,360);
		//
		enemy.GetComponent<enemyRT>().CanBeDestroyed=true;
		Instantiate(enemy, pos, Quaternion.Euler(new Vector3(0,0, rotation))); 
	}

	void Timer(){
		timer-=Time.deltaTime;
		int seconds=(int)timer;
		if(seconds%3==0)
			ChooseShooters();
		TimeText.text=seconds.ToString();
		if(timer<=0){
			SetWinner();
		}
	}

	void Health(){
		GameObject player1= GameObject.FindWithTag("Player1");
		GameObject player2= GameObject.FindWithTag("Player2");
		P1Health.text=player1.GetComponent<PlayerRT>().health.ToString();
		P2Health.text=player2.GetComponent<PlayerRT>().health.ToString();
	}

	// Statics
	static public void SetWinner(){
		inputEnabled=false;
		Save();
		SceneManager.LoadScene("WinnerRT");
	}
	public static void Save(){
		// Deciding scores
		GameObject player1= GameObject.FindWithTag("Player1");
		GameObject player2= GameObject.FindWithTag("Player2");
		int p1points = player1.GetComponent<PlayerRT>().health;
		int p2points = player2.GetComponent<PlayerRT>().health;
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

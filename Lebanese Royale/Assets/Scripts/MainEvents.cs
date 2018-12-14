using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEvents : MonoBehaviour {

	static string[] eventList= new string[11];
	// Payed 1 By All
	// Pay 1 to everyone
	// Choose a payer

	void Start () {
		SetEvents();
	}
	
	void Update () {
	}

	void SetEvents(){
		eventList[0]="Add";
		eventList[1]="Add";
		eventList[2]="Add";
		eventList[3]="Add";
		eventList[4]="Add";
		eventList[5]="Add";
		eventList[6]="Add";
		eventList[7]="Subtract";
		eventList[8]="Add";
		eventList[9]="Add";
		eventList[10]="PayTo";
	}

	public static void GetEvent(string tag){
		//This part is used for the "PayTo" case
		int luckyPlayerNumber=Random.Range(1,MainGame.Players);
		string luckyPlayerName="Player"+luckyPlayerNumber;
		GameObject player= GameObject.FindWithTag(luckyPlayerName);
		//This part kello rawa2 dw I GOT THIS!
		GameObject luckyPlayer= GameObject.FindWithTag(tag);
        int eventNumber=Random.Range(0,9);
		int turn;
		switch(eventList[eventNumber]){
			case "Add":turn=Random.Range(1,10);luckyPlayer.GetComponent<Player>().points+=turn;break;
			case "Subtract":turn=Random.Range(1,10);player.GetComponent<Player>().points-=turn;break;
			case "PayTo":turn=Random.Range(1,5);player.GetComponent<Player>().points-=turn;luckyPlayer.GetComponent<Player>().points+=turn;break;
		}

	}
}

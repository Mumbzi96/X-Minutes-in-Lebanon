using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEvents : MonoBehaviour {

	static string[] eventList= new string[10];
	// int eventType;

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
	}

	public static void GetEvent(string tag){
		GameObject player= GameObject.FindWithTag(tag);
        int eventNumber=Random.Range(0,9);
		int turn;
		switch(eventList[eventNumber]){
			case "Add":turn=Random.Range(1,10);player.GetComponent<Player>().points+=turn;break;
			case "Subtract":turn=Random.Range(1,10);player.GetComponent<Player>().points-=turn;break;
		}

	}
}

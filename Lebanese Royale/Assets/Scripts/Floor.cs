using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static void GetEvent(string tag){
		GameObject player= GameObject.FindWithTag(tag);
		int turn=Random.Range(1,10);
		player.GetComponent<Player>().points+=turn;

	}
}

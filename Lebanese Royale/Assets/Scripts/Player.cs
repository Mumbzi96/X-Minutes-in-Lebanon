using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	int nextX=MainGame.spacer;
	int nextY=0;
	public string CityOn;

	public void Move(int turn,string direction){
			MainGame.InputEnabled=false;
			StartCoroutine(MoveIt( turn, direction));
	}
	//This coroutine makes the movement an animation instead of a flash
	private IEnumerator MoveIt(int turn,string direction){
		if(direction=="Left")
			for(int i=1;i<=turn;i++){
				transform.SetPositionAndRotation(new Vector3(transform.position.x+nextX,transform.position.y+nextY,0),new Quaternion(0,0,0,0));
				 yield return new WaitForSeconds(1f);
			}
		else if(direction=="Up"){
			for(int i=1;i<=turn;i++){
				transform.SetPositionAndRotation(new Vector3(transform.position.x+nextX,transform.position.y+nextY,0),new Quaternion(0,0,0,0));
				yield return new WaitForSeconds(1f);
			}
		}
		else if(direction=="Right"){
			for(int i=1;i<=turn;i++){
				transform.SetPositionAndRotation(new Vector3(transform.position.x+nextX,transform.position.y+nextY,0),new Quaternion(0,0,0,0));
				 yield return new WaitForSeconds(2f);
			}
		}
		else if(direction=="Down"){
			for(int i=1;i<=turn;i++){
				transform.SetPositionAndRotation(new Vector3(transform.position.x+nextX,transform.position.y+nextY,0),new Quaternion(0,0,0,0));
				yield return new WaitForSeconds(1f);
			}
		}
		// Sound is playing
		SoundEffectsHelper.Instance.MakeTurnSound(transform.position.x,transform.position.y,transform.position.z);
		MainGame.InputEnabled=true;
		MainGame.LoadMiniGame();
		

	}

	void OnCollisionEnter2D(Collision2D collision){
		switch(collision.gameObject.tag){
			case "FinalFloor":MainGame.SetWinner();break;
			case "GoRight":nextX=MainGame.spacer;nextY=0;CityOn=collision.gameObject.GetComponent<Floor>().cityName;break;
		}
	}
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    private int _points = 0;
	public int points{
        get
        {
            return _points;
        }
        set
        {
            _points = value;
        }
    }
	int nextX=7;
	int nextY=0;

	public void Move(int turn,string direction){
		if (transform.position.x>(7*MainGame.tileNumbers))
			MainGame.SetWinner(gameObject.tag);
		else{
			MainGame.InputEnabled=false;
			StartCoroutine(MoveIt( turn, direction));
		}
	}
	//This coroutine makes the movement an animation instead of a flash
	private IEnumerator MoveIt(int turn,string direction){
		if(direction=="Left")
			for(int i=1;i<=turn;i++){
				// transform.SetPositionAndRotation(new Vector3(transform.position.x-(7),transform.position.y,0),new Quaternion(0,0,0,0));
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
				 yield return new WaitForSeconds(1f);
			}
		}
		else if(direction=="Down"){
			for(int i=1;i<=turn;i++){
				transform.SetPositionAndRotation(new Vector3(transform.position.x+nextX,transform.position.y+nextY,0),new Quaternion(0,0,0,0));
				yield return new WaitForSeconds(1f);
			}
		}
		SoundEffectsHelper.Instance.MakeTurnSound();
		MainGame.Turn="whatever";
		MainGame.InputEnabled=true;
		MainEvents.GetEvent(gameObject.tag);

	}

	void OnCollisionEnter2D(Collision2D collision){
		// switch(collision.gameObject.tag){
		// 	case "FinalFloor":MainGame.SetWinner(gameObject.tag);break;
		// 	case "GoLeft":Move(1,"Left" );break;
		// 	case "GoUp":Move(1,"Up");break;
		// 	// case "GoRight":;break;
		// 	case "GoDown":Move(1,"Down");break;
		// }
		switch(collision.gameObject.tag){
			case "FinalFloor":MainGame.SetWinner(gameObject.tag);break;
			case "GoLeft":nextX=-7;nextY=0;break;
			case "GoUp":nextX=0;nextY=7;break;
			case "GoRight":nextX=7;nextY=0;break;
			case "GoDown":nextX=0;nextY=-7;break;
		}
	}
}

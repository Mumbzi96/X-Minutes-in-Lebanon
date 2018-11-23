using System;
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

	public void Move(int turn,string direction){
		if (transform.position.x>(7*MainGame.tileNumbers))
			MainGame.SetWinner(gameObject.tag);
		else{
			MainGame.InputEnabled=false;
			StartCoroutine(MoveIt( turn, direction));
		}
	}
	private IEnumerator MoveIt(int turn,string direction){
		if(direction=="Left")
			for(int i=1;i<=turn;i++){
				transform.SetPositionAndRotation(new Vector3(transform.position.x-(7),transform.position.y,0),new Quaternion(0,0,0,0));
				 yield return new WaitForSeconds(1f);
			}
		else if(direction=="Up"){
			for(int i=1;i<=turn;i++){
				transform.SetPositionAndRotation(new Vector3(transform.position.x,transform.position.y+(7*i),0),new Quaternion(0,0,0,0));
				yield return new WaitForSeconds(1f);
			}
		}
		else if(direction=="Right"){
			for(int i=1;i<=turn;i++){
				transform.SetPositionAndRotation(new Vector3(transform.position.x+(7),transform.position.y,0),new Quaternion(0,0,0,0));
				 yield return new WaitForSeconds(1f);
			}
		}
		else if(direction=="Down"){
			for(int i=1;i<=turn;i++){
				transform.SetPositionAndRotation(new Vector3(transform.position.x,transform.position.y-(7*i),0),new Quaternion(0,0,0,0));
				yield return new WaitForSeconds(1f);
			}
		}
		MainGame.InputEnabled=true;
		MainGame.Turn="whatever";
		SoundEffectsHelper.Instance.MakeTurnSound();

	}

	void OnCollisionEnter2D(Collision2D collision){
		switch(collision.gameObject.tag){
			case "FinalFloor":MainGame.SetWinner(gameObject.tag);break;
			case "GoLeft":Floor.GetEvent(gameObject.tag);Move(1,"Left");break;
			case "GoUp":Floor.GetEvent(gameObject.tag);Move(1,"Up");break;
			// case "GoRight":Floor.GetEvent(gameObject.tag);Move(1,"Right");break;
			case "GoDown":Floor.GetEvent(gameObject.tag);Move(1,"Down");break;
		}
	}

}

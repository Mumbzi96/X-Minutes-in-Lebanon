using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFG : MonoBehaviour {
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
	Rigidbody2D rb2d;
	float speed=15;

	void Start(){
		rb2d=gameObject.GetComponent<Rigidbody2D>();
	}
	void FixedUpdate(){
		Move();
	}

	public void Move(){
		if(gameObject.tag=="Player1"){
			float x= Input.GetAxis("Horizontal");
			float y= Input.GetAxis("Vertical");
			if (x!=null){
				Vector3 nv3= new Vector3(x,0,0);
				gameObject.transform.Translate(nv3*speed*Time.deltaTime);
			}
			if (y!=null){
				Vector3 nv3= new Vector3(0,y,0);
				gameObject.transform.Translate(nv3*speed*Time.deltaTime);
			}
		}
		else if(gameObject.tag=="Player2"){
			float x2= Input.GetAxis("Horizontal2");
			float y2= Input.GetAxis("Vertical2");
			if (x2!=null){
				Vector3 nv3= new Vector3(x2,0,0);
				gameObject.transform.Translate(nv3*speed*Time.deltaTime);
			}
			if (y2!=null){
				Vector3 nv3= new Vector3(0,y2,0);
				gameObject.transform.Translate(nv3*speed*Time.deltaTime);
			}

		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		switch(collision.gameObject.tag){
			case "WHAT":MainGame.SetWinner(gameObject.tag);break;
			// case "FinalFloor":MainGame.SetWinner(gameObject.tag);break;
			// case "GoLeft":nextX=-MainGame.spacer;nextY=0;break;
			// case "GoUp":nextX=0;nextY=MainGame.spacer;break;
			// case "GoRight":nextX=MainGame.spacer;nextY=0;break;
			// case "GoDown":nextX=0;nextY=-MainGame.spacer;break;
		}
	}
}

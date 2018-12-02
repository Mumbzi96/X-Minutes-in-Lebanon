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
    }
	Rigidbody2D rb2d;
	float speed=7;

	void Start(){
		rb2d=gameObject.GetComponent<Rigidbody2D>();
	}
	void FixedUpdate(){
		if(MainFG.isGameEnabled==true)
			Move();
	}

	public void Move(){
		if(gameObject.tag=="Player1"){
			float x= Input.GetAxis("Horizontal");
			float y= Input.GetAxis("Vertical");
			Vector3 nv3= new Vector3(x,y,0);
			gameObject.transform.Translate(nv3*speed*Time.deltaTime);
		}
		else if(gameObject.tag=="Player2"){
			float x2= Input.GetAxis("Horizontal2");
			float y2= Input.GetAxis("Vertical2");
			Vector3 nv3= new Vector3(x2,y2,0);
			gameObject.transform.Translate(nv3*speed*Time.deltaTime);

		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		switch(collision.gameObject.tag){
			case "Food":_points+=collision.gameObject.GetComponent<FoodFG>().points;break;
		}
	}
}

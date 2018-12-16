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
	float speed=7;

	// Public GameObjects
	public Bullet pencil;
	public Bullet ak47Bullet;
	public Bullet rocket;

	void Start(){
	}
	void FixedUpdate(){
		if(MainFG.isGameEnabled==true){
			Move();
			Shoot();			
		}
	}


	public void Move(){
		SpriteRenderer mySpriteRenderer = GetComponent<SpriteRenderer>();
		if(gameObject.tag=="Player1"){
			float x= Input.GetAxis("Horizontal");
			if(x<0)
				mySpriteRenderer.flipX=true;
			else if(x>0)
				mySpriteRenderer.flipX=false;
			float y= Input.GetAxis("Vertical");
			Vector3 nv3= new Vector3(x,y,0);
			gameObject.transform.Translate(nv3*speed*Time.deltaTime);
		}
		else if(gameObject.tag=="Player2"){
			float x2= Input.GetAxis("Horizontal2");
			if(x2<0)
				mySpriteRenderer.flipX=true;
			else if(x2>0)
				mySpriteRenderer.flipX=false;
			float y2= Input.GetAxis("Vertical2");
			Vector3 nv3= new Vector3(x2,y2,0);
			gameObject.transform.Translate(nv3*speed*Time.deltaTime);

		}
	}

	public void Shoot(){
		SpriteRenderer mySpriteRenderer = GetComponent<SpriteRenderer>();
		if(gameObject.tag=="Player1"){
			if(Input.GetButton("Fire")==true)
				if(mySpriteRenderer.flipX==true){
					ak47Bullet.direction="left";
					Instantiate(ak47Bullet, transform.position, new Quaternion(0,0,0,0));
				}
			else{
				ak47Bullet.direction="right";
				Instantiate(ak47Bullet, transform.position, new Quaternion(0,0,0,0));
			}
				
		}

		else if(gameObject.tag=="Player2"){
		}
	}
	void OnCollisionEnter2D(Collision2D collision){
		switch(collision.gameObject.tag){
			case "Food":_points+=collision.gameObject.GetComponent<FoodFG>().points;break;
		}
	}
}

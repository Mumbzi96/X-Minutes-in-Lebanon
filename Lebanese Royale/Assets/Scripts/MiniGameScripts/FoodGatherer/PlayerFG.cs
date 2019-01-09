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
	Rigidbody2D rb;
	// Helpers
	private bool canShoot=true;
	private float shotTimer=0;
	private string bulletTag;
	private string firedBy;
	private string equippedWeapon;
	private Bullet currentBullet;
	// Better jumping
	[Range(1,10)]
	private float jumpVelocity=5.5f;
	private bool isJumping=false;
	// private float fallMultiplier=2.5f;
	// private float lowJumpMultiplier=2f;

	// Public GameObjects
	public Bullet pencil;
	public Bullet ak47Bullet;
	public Bullet rocket;

	// Public Helpers
	public Animator animator;

	void Start(){
		rb= GetComponent<Rigidbody2D>();
		firedBy=gameObject.tag;
		if (gameObject.tag=="Player1"){
			bulletTag="Player1Bullet";
		}
		else if (gameObject.tag=="Player2")
			bulletTag="Player2Bullet";
	}

	private void ChangeBullet(){
		switch(equippedWeapon){
			case "pencil":currentBullet=pencil;break;
			case "ak47":currentBullet=ak47Bullet;break;
			case "rpg":currentBullet=rocket;break;
		}

	}

	void Update(){
		
	}
	
	void FixedUpdate(){
		if(MainFG.isGameEnabled==true){
			Move();
			ShotTracker();
		}
		
		
	}

	private void ShotTracker(){
		/*
		This function checks if the user can shoot;
		if not
		the tracker will subtract till shooting isAllowed again
		*/
		switch(canShoot){
			case true:Shoot();break;
			case false:if(shotTimer<=0) canShoot=true;break;
		}
		if(shotTimer>0){
			shotTimer-=Time.deltaTime;
		}
	}

	private void Move(){
		SpriteRenderer mySpriteRenderer = GetComponent<SpriteRenderer>();
		
		if(gameObject.tag=="Player1"){
			// Movement
			float x= Input.GetAxis("Horizontal");
			animator.SetFloat("Speed",Mathf.Abs(x));
			if(x<0)
				mySpriteRenderer.flipX=true;
			else if(x>0)
				mySpriteRenderer.flipX=false;
			
			Vector3 nv3= new Vector3(x,0,0);
			gameObject.transform.Translate(nv3*speed*Time.deltaTime);
			// JUMPING
			if(Input.GetKeyDown(KeyCode.UpArrow)&& animator.GetBool("IsJumping")==false){
				animator.SetBool("IsJumping",true);
				rb.velocity=Vector2.up*jumpVelocity;
			}
		}
		else if(gameObject.tag=="Player2"){
			// Movement
			float x= Input.GetAxis("Horizontal2");
			if(x<0)
				mySpriteRenderer.flipX=true;
			else if(x>0)
				mySpriteRenderer.flipX=false;
			Vector3 nv3= new Vector3(x,0,0);
			gameObject.transform.Translate(nv3*speed*Time.deltaTime);
			// JUMPING
			if(Input.GetKeyDown(KeyCode.W)&& animator.GetBool("IsJumping")==false){
				animator.SetBool("IsJumping",true);
				rb.velocity=Vector2.up*jumpVelocity;
			}
		}
	}

	public void Shoot(){
		SpriteRenderer mySpriteRenderer = GetComponent<SpriteRenderer>();
		
		if(gameObject.tag=="Player1"){
			if(Input.GetButton("Fire")==true){
				currentBullet.tag=bulletTag;
				currentBullet.firedBy=firedBy;
				if(mySpriteRenderer.flipX==true){
					currentBullet.direction="left";
					Instantiate(currentBullet, new Vector3(transform.position.x-0.5f,transform.position.y,transform.position.z), new Quaternion(0,0,0,0));
				}
				else{
					currentBullet.direction="right";
					Instantiate(currentBullet, new Vector3(transform.position.x+0.5f,transform.position.y,transform.position.z), new Quaternion(0,0,0,0));
				}
					
				canShoot=false;
				shotTimer=1;
			}
		}

		else if(gameObject.tag=="Player2"){
			if(Input.GetButton("Fire2")==true){
				currentBullet.tag=bulletTag;
				currentBullet.firedBy=firedBy;
				if(mySpriteRenderer.flipX==true){
					currentBullet.direction="left";
					Instantiate(currentBullet, new Vector3(transform.position.x-0.5f,transform.position.y,transform.position.z), new Quaternion(0,0,0,0));
				}
				else{
					currentBullet.direction="right";
					Instantiate(currentBullet, new Vector3(transform.position.x+0.5f,transform.position.y,transform.position.z), new Quaternion(0,0,0,0));
				}
				canShoot=false;
				shotTimer=1;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		animator.SetBool("IsJumping",false);
		switch(collision.gameObject.tag){
			case "Food":_points+=collision.gameObject.GetComponent<FoodFG>().points;break;
			case "Player1Bullet":if(gameObject.tag=="Player2") _points-=50;break;
			case "Player2Bullet":if(gameObject.tag=="Player1") _points-=50;break;
			case "Weapon":equippedWeapon=collision.gameObject.GetComponent<Weapon>().type;ChangeBullet();break;
		}
	}
}

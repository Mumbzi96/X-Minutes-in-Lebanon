using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	[HideInInspector] public int damage=1;
	[HideInInspector] public int speed=5;
	public string direction="right";
	
	
	void Start () {
		
	}
	
	void Update () {
		// transform.position += transform.right *speed* Time.deltaTime;
		// if(MainFG.isGameEnabled==true)
			Move();
	}

	private void Move(){
		switch(direction){
			case "right":transform.position += transform.right *speed* Time.deltaTime;break;
			case "left":transform.position += -(transform.right) *speed* Time.deltaTime;break;
		}
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		Destroy(gameObject,3);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	[HideInInspector] public int damage=1;
	[HideInInspector] public int speed=5;
	[HideInInspector] public string direction="right";
	[HideInInspector] public string firedBy;
	
	
	void Start () {
		Destroy(gameObject,3);
	}
	
	void Update () {
			Move();
	}

	private void Move(){
		switch(direction){
			case "right":transform.position += transform.right *speed* Time.deltaTime;break;
			case "left":transform.position += -(transform.right) *speed* Time.deltaTime;break;
		}
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag!=firedBy)
			Destroy(gameObject);
	}
}

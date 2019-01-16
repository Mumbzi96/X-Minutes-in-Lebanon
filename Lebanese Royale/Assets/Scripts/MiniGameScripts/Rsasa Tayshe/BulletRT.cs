using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRT : MonoBehaviour {
	[HideInInspector] public int damage=1;
	[HideInInspector] public int speed=2;
	[HideInInspector] public string direction="right";
	[HideInInspector] public string firedBy;
	private SpriteRenderer mySpriteRenderer;
	
	
	void Start () {
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		Destroy(gameObject,3);
	}
	
	void Update () {
			Move();
	}

	private void Move(){
		Vector3 nv3= new Vector3(3,0,0);
		switch(direction){
			case "right":mySpriteRenderer.flipX=false;gameObject.transform.Translate(nv3*speed*Time.deltaTime);break;
			case "left":mySpriteRenderer.flipX=true;gameObject.transform.Translate(-(nv3*speed*Time.deltaTime));break;
		}
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag!="Enemy")
			Destroy(gameObject);
	}
}

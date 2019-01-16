using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRT : MonoBehaviour {

	[HideInInspector] public int health=3;
	[HideInInspector] public int speed=3;

	void Start () {
		
	}
	
	void Update () {
		if(MainRT.inputEnabled==true)
			Move();

		if(health<=0)
			MainRT.SetWinner();
	}

	void Move(){
		SpriteRenderer mySpriteRenderer = GetComponent<SpriteRenderer>();
		
		if(gameObject.tag=="Player1"){
			// Movement
			float x= Input.GetAxis("Horizontal");
			float y= Input.GetAxis("Vertical");
			Vector3 nv3= new Vector3(x,y,0);
			gameObject.transform.Translate(nv3*speed*Time.deltaTime);
		}
		else if(gameObject.tag=="Player2"){
			// Movement
			float x= Input.GetAxis("Horizontal2");
			float y= Input.GetAxis("Vertical2");
			Vector3 nv3= new Vector3(x,y,0);
			gameObject.transform.Translate(nv3*speed*Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		health--;
	}
}

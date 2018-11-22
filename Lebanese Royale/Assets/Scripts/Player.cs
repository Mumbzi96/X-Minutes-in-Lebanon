using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public int _points = 0;
	public int points
    {
        get
        {
            return _points;
        }
        set
        {
            _points = value;
        }
    }
	// public float speed=15;
	// private Rigidbody2D rb2d;
	void Awake(){
		DontDestroyOnLoad(gameObject);
	}
	// Use this for initialization
	void Start () {
		// rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Move(int turn,string direction){
		if (transform.position.x>(7*MainGame.tileNumbers))
			MainGame.SetWinner(gameObject.tag);
		else{
			MainGame.InputEnabled=false;
			StartCoroutine(MoveIt( turn, direction));
		}
		MainGame.Turn="whatever";

		//Horizontal
		// float x= Input.GetAxis("Horizontal");
		// if(x!=null){
			// Vector3 nv3 = new Vector3(x,y,0);
			// rb2d.position=new Vector3(500,500);

		// }
		// //Vertical
		// float y= Input.GetAxis("Vertical");
		// if(y!=null){
		// 	Vector3 nv3 = new Vector3(0,y,0);
		// 	gameObject.transform.Translate(nv3*speed*Time.deltaTime);
		// }
	}
	public IEnumerator MoveIt(int turn,string direction){
		if(direction=="Down"){
			for(int i=1;i<=turn;i++){
				transform.SetPositionAndRotation(new Vector3(transform.position.x,transform.position.y-(7*i),0),new Quaternion(0,0,0,0));
			}
		}
		else
			for(int i=1;i<=turn;i++){
				transform.SetPositionAndRotation(new Vector3(transform.position.x+(7),transform.position.y,0),new Quaternion(0,0,0,0));
				 yield return new WaitForSeconds(1f);
			}
		MainGame.InputEnabled=true;
	}


	void OnCollisionEnter2D(Collision2D collision){
		// Make this a switch
		if (collision.gameObject.tag=="Floor"){
			Floor.GetEvent(gameObject.tag);
		}
		else if(collision.gameObject.tag=="FinalFloor")
			MainGame.SetWinner(gameObject.tag);
		else if(collision.gameObject.tag=="DirectionFloor"){
			Move(1,"Down");
		}
			

	}

}

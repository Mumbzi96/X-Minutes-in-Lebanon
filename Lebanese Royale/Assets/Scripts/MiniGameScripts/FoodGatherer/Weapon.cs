using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public string type;
	
	
	void Start () {
	}
	
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag=="Player1"||collision.gameObject.tag=="Player2")
			Destroy(gameObject);
	}
}

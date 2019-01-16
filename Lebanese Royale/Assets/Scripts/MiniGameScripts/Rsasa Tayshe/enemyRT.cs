using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRT : MonoBehaviour {
	
	public Bullet bullet;
	
	void Start () {
		Destroy(gameObject,3);
		InvokeRepeating("Shoot",1,1);
		

	}

	void Shoot(){
		Instantiate(bullet,transform.position,transform.rotation);
	}
	
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		Destroy(gameObject);
	}
}

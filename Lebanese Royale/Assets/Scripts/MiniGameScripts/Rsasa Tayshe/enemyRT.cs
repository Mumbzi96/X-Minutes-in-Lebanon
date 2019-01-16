using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRT : MonoBehaviour {
	
	public BulletRT bullet;
	public bool CanBeDestroyed = false;
	
	
	void Start () {
		if(CanBeDestroyed==true)
			Destroy(gameObject,2);
		InvokeRepeating("Shoot",0.1f,1);
		

	}

	void Shoot(){
		int willShoot=Random.Range(0,10);
		if(willShoot%2==0)
			Instantiate(bullet,transform.position,transform.rotation);
	}
	
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		// Destroy(gameObject);
	}
}

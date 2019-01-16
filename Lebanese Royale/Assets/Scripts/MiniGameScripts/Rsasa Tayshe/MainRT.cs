using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRT : MonoBehaviour {

	public enemyRT enemy;
	public static bool inputEnabled=true;

	void Start () {
		InvokeRepeating("SpawnEnemy",1,1);
	}
	
	void Update () {
	}

	void SpawnEnemy(){
		// Random Position
		int size=(int)(Camera.main.orthographicSize-0.5);
		int x=Random.Range(-size,size);
		int y=Random.Range(-size,size);
		Vector3 pos= new Vector3(x,y);
		// Random Rotation
		int rotation=Random.Range(0,360);
		//
		Instantiate(enemy, pos, Quaternion.Euler(new Vector3(0,0, rotation))); 
	}

	static public void SetWinner(){
		inputEnabled=false;

	}

}

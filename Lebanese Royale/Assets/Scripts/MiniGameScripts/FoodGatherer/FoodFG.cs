using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFG : MonoBehaviour {
	public int points = 1;

	//Constructors
	public FoodFG(int points=1){
		this.points=points;

	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		Destroy(gameObject);
	}
}

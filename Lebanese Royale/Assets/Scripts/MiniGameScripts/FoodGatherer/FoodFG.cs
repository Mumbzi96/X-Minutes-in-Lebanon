using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFG : MonoBehaviour {
	private int _points=1;
	public int points{
        get
        {
            return _points;
        }
        set{}
    }
	
	void Start () {
		/* 
		Food's size is <0 & float so it's multiplied by 100 to make a simple rounding number
		and casted to int because points are int...
		*/
		float val=transform.localScale.x*100;
		_points=(int)val;
	}
	
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag=="Player1"||collision.gameObject.tag=="Player2")
			Destroy(gameObject);
	}
}

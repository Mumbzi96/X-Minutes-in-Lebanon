using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactOrLie: MonoBehaviour {
    // Points
	int player1=0;
    int player2=0;
	// Text
	public Text player1score;
	public Text player2score;
	// Helpers
	bool inputEnabled=true;


	void NextQuestion(){
		// Let dialogue manager display the next question
		// inputEnabled=true
	}

    void Update(){
		if (inputEnabled){
        	Answer();
		}
		
		Scores();
    }

	void Scores(){
		player1score.text="Player1: "+player1.ToString();
		player2score.text="Player2: "+player2.ToString();
	}

    
	// FINISH THIS FUNCTION
    void Answer(){
        if(Input.GetKey(KeyCode.LeftArrow)){
            bool answer=true;
            if (answer==DialogueManager.currentQuestion.answer){
                player1+=3;
            }
            else
            	player2+=3;
			inputEnabled=false;
			NextQuestion();
        }
    }

	/*
		Finish()
		Save()
		Load()
	*/

}

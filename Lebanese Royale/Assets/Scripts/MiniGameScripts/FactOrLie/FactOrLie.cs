using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactOrLie: MonoBehaviour {
    // Points
	int player1=0;
    int player2=0;
	// Text
	public Text currentQuestionText;
	public Text player1score;
	public Text player2score;
	// Helpers
	bool inputEnabled=true;
	DialogueManager dialogueManager=new DialogueManager();

	void Start(){
		dialogueManager.Randomize();
		NextQuestion();
		
	}
	
	void NextQuestion(){
		dialogueManager.currentQuestion=new Dialogue("NOT IMPORTANT BUT DONT DELETE",true);
		StopAllCoroutines();
		StartCoroutine(TypeSentence(dialogueManager.currentQuestion.question));
		

    }

	IEnumerator TypeSentence (string sentence){
		currentQuestionText.text="";
		foreach (char letter in sentence.ToCharArray()){
			currentQuestionText.text+=letter;
			yield return null; // Waits for a single frame
		}
		inputEnabled=true;
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

    
    void Answer(){
        if(Input.GetKey(KeyCode.LeftArrow)){
            bool answer=true;
            if (answer==dialogueManager.currentQuestion.answer){
                player1+=3;
            }
            else
            	player2+=1;
			inputEnabled=false;
			NextQuestion();
        }
		if(Input.GetKey(KeyCode.RightArrow)){
            bool answer=false;
            if (answer==dialogueManager.currentQuestion.answer){
                player1+=3;
            }
            else
            	player2+=1;
			inputEnabled=false;
			NextQuestion();
        }
		if(Input.GetKey(KeyCode.A)){
            bool answer=true;
            if (answer==dialogueManager.currentQuestion.answer){
                player2+=3;
            }
            else
            	player1+=1;
			inputEnabled=false;
			NextQuestion();
        }
		if(Input.GetKey(KeyCode.D)){
            bool answer=false;
            if (answer==dialogueManager.currentQuestion.answer){
                player2+=3;
            }
            else
            	player1+=1;
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

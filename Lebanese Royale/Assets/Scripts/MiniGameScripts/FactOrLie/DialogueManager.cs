using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Use an ArrayList too, take questions randomly, remove them from arraylist (keep them in the main array though)


public class DialogueManager : MonoBehaviour {

	private Dialogue[] dialogues= new Dialogue[5];
	public Text currentQuestionText;
	public static Dialogue currentQuestion;

	// public Text dialogueText;

	void Start () {
		dialogues[0]= new Dialogue("Omar made this game",true);
		currentQuestion=dialogues[0];
		ShowQuestion();
	}
	void Update(){
		
	}

	void ShowQuestion(){
		currentQuestionText.text=dialogues[0].question;
    }

	void NextQuestion(){

	}
	
}

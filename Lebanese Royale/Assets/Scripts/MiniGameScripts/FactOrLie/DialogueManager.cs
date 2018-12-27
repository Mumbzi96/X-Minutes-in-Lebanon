using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Use an ArrayList too, take questions randomly, remove them from arraylist (keep them in the main array though)


public class DialogueManager {

	//
	private Dialogue[] dialogues= new Dialogue[5];
	private int questionCounter=-1;
	//
	private Dialogue _currentQuestion;
	public Dialogue currentQuestion{
        get
        {
            return dialogues[questionCounter];
        }
        set
        {
			questionCounter++;
			_currentQuestion=dialogues[questionCounter];

        }
    }
	

	public DialogueManager(){
		AddQuestions();
	}
	
	private void AddQuestions(){
		dialogues[0]= new Dialogue("Omar made this game",true);
		dialogues[1]= new Dialogue("Current prime minister is Micheal Aoun",false);
		dialogues[2]= new Dialogue("You're playing",true);
		_currentQuestion=dialogues[0];
	}
}

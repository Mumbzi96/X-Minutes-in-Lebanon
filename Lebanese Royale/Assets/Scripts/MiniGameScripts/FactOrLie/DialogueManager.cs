using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager {

	//
	List<Dialogue> dialogues = new List<Dialogue>();
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
		dialogues.Add(new Dialogue("Omar made this game",true)) ;
		dialogues.Add(new Dialogue("Current prime minister is Micheal Aoun",false)) ;
		dialogues.Add(new Dialogue("You're playing",true)) ;
		_currentQuestion=dialogues[0];
	}
}

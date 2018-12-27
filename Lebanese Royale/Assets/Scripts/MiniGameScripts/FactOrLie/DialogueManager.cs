using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager {

	//
	List<Dialogue> dialoguesList = new List<Dialogue>();
	Dialogue[] dialogues;
	private int questionCounter=-1;
	private int numberOfQuestions=3;
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
		dialoguesList.Add(new Dialogue("Omar made this game",true)) ;
		dialoguesList.Add(new Dialogue("Current prime minister is Micheal Aoun",false)) ;
		dialoguesList.Add(new Dialogue("You're playing",true)) ;
		dialoguesList.Add(new Dialogue("Hyye?",true)) ;
		dialoguesList.Add(new Dialogue("Saed Al Harriri is our current prime minister?",true));
		dialoguesList.Add(new Dialogue("Nabih Berri is leaving his office...",false));
		dialoguesList.Add(new Dialogue("howwe?",false));
		dialogues= new Dialogue[dialoguesList.Count];
	}

	public void Randomize(){
		List<Dialogue> dialoguesListSorting= new List<Dialogue>(dialoguesList);
		for (int i=0;i<dialoguesList.Count;i++){
			/*  I'm using this condition because when the count becomes 0
				The random value picks between (0,0) which doesn't work */
			if (dialoguesListSorting.Count==0){
				dialogues[i]=dialoguesListSorting[0];
			}
			else{
				int randomValue = Random.Range(0,dialoguesListSorting.Count);
				dialogues[i]=dialoguesListSorting[randomValue];
				dialoguesListSorting.RemoveAt(randomValue);
			}
			
		}
		

	}
}

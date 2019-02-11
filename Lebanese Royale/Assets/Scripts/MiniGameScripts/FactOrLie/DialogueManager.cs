using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager {

	List<Dialogue> dialoguesList = new List<Dialogue>();
	Dialogue[] dialogues;
	private int questionCounter=-1;
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
		dialoguesList.Add(new Dialogue("Traffic Light are actually made for design, you don't have to use it",false)) ;
		dialoguesList.Add(new Dialogue("You're playing",true)) ;
		dialoguesList.Add(new Dialogue("The train station acts as the main source of transportation between major cities",false)) ;
		dialoguesList.Add(new Dialogue("Bechara El Khoury, first President and Riad El Solh, first Prime Minister of independent Lebanon are considered as the founders of the present day Lebanese Republic.",true)) ;
		dialoguesList.Add(new Dialogue("A mother's main weapon is the famous \" mesheyye\"",true)) ;
		dialoguesList.Add(new Dialogue("Lebanon Gained independence from France in 1943?",true)) ;
		dialoguesList.Add(new Dialogue("Culturally, 4 kisses is the normal greeting here",false)) ; //3
		dialoguesList.Add(new Dialogue("Insults are a form of hate",false)); // It can be, but usually love
		dialoguesList.Add(new Dialogue("Saed Al Harriri is our current prime minister?",true));
		dialoguesList.Add(new Dialogue("Beirut is the 2nd oldest city name in the world",true)); // The oldest
		dialoguesList.Add(new Dialogue("Lebanon is well known for its famous phoenician desert?",false));
		dialoguesList.Add(new Dialogue("A piece of land can have 2 owners",true));
		dialoguesList.Add(new Dialogue("Romans gave Baalbek its current name", false)); // They called it Heliopolis
		dialoguesList.Add(new Dialogue("\"Ask not what your country can do for you, ask what you can do for your country\" is actually a saying by Gibran Khalil Gibran", true)); //
		dialoguesList.Add(new Dialogue("Main language of Lebanon is French, not English", false)); // Arabic...

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

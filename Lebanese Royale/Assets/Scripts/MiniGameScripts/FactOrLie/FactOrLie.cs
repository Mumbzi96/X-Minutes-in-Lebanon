using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class FactOrLie: MonoBehaviour {
    // Points
	static int player1=0;
    static int player2=0;
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

		if(player1>=10 || player2>=10){
			inputEnabled= false;
			Save();
			SceneManager.LoadScene("WinnerFoL");
		}
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

	// Statics
	public static void Save(){
		// GameObject MainController= GameObject.FindWithTag("Player");
		//  GetComponent<FactOrLie>()
		Debug.Log(player1);
		// Deciding scores
		string winner;
		if( player1>player2)
			winner="1";
		else if ( player2> player1)
			winner="2";
		else winner="0";
		PlayerData data = Load();

		// Actually saving
		string savePath=Application.persistentDataPath+"/winner.dat";
		BinaryFormatter bf = new BinaryFormatter();
		// Adding main points to data
		if(winner=="1")
			data.mainp1Points+=10;
		else if(winner=="2")
			data.mainp2Points+=10;
		// Saving the games last points (sa2ale)
		data.lastp1Points= player1;
		data.lastp2Points= player2;
		data.lastWinner= winner;

		using (var file = File.Create(savePath)){
			bf.Serialize(file,data);
		}
	}

	public static PlayerData Load(){
		string savePath=Application.persistentDataPath+"/winner.dat";
		PlayerData data=new PlayerData();
		if (File.Exists(savePath)){
			BinaryFormatter bf = new BinaryFormatter();
			using (var file = File.Open(savePath, FileMode.Open)){
				data = (PlayerData)bf.Deserialize(file);
			}
			return data;
		}
		else return new PlayerData();
	}
}

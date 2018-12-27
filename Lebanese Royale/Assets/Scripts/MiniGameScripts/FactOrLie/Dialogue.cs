using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue {

    public string question;
    public bool answer;
    
    //true is a fact; false is a lie
    public Dialogue (string question, bool answer){
        this.question=question;
        this.answer=answer;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MenuFG : MonoBehaviour {

	void Start(){
	}

	public void PlayGame(){
		SceneManager.LoadScene("FoodGatherer");
	}

}

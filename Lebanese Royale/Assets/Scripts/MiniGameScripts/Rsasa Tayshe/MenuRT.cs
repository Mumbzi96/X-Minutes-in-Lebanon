using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MenuRT : MonoBehaviour {
	
	public string NextScene;

	void Start(){
	}

	public void PlayGame(){
		Debug.Log("Clicked");
		SceneManager.LoadScene(NextScene);
	}

}

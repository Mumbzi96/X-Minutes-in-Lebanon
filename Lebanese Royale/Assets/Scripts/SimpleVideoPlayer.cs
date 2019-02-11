using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleVideoPlayer : MonoBehaviour {
	VideoPlayer video;
	public string nextScene;
	// Use this for initialization
	void Start () {
		 video=gameObject.GetComponent<VideoPlayer>();
		 video.loopPointReached += OnMovieFinished;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMovieFinished(VideoPlayer player){
		SceneManager.LoadScene(nextScene);
	}
	
	public void SkipScene(){
		SceneManager.LoadScene(nextScene);
	}

}

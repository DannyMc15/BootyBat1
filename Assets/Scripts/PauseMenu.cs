﻿using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public string startMenu;
	public bool isPaused;
	public GameObject pauseMenuCanvas;


	
	// Update is called once per frame
	void Update () {
		if (isPaused) {
			pauseMenuCanvas.SetActive(true);
			Time.timeScale = 0f;
		} else {
			pauseMenuCanvas.SetActive(false);
			Time.timeScale = 1f;
		}

		if(Input.GetKeyDown(KeyCode.P)){
			isPaused = !isPaused;
		}
	}
	public void Resume(){
			isPaused = false;
	}
	public void QuittoStartMenu(string name){
		Application.LoadLevel(name);
	}
}

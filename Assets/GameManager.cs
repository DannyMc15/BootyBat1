﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Need this for referencing UI objects

public class GameManager : MonoBehaviour {

	public int score;
	public int canShoot;
	public int health;
	public int timer;
	//public int lives;

	private int oneSecond = 0;

	public GameObject scoreTextRef;	//This references the score text, so we can change it later
	public GameObject shotsNumberRef;
	public GameObject healthNumberRef;
	public GameObject timerNumberRef;
	//public GameObject livesNumberRef;
	// Use this for initialization

	void Start () 
	{
		scoreTextRef = GameObject.Find ("scoreText");
		shotsNumberRef = GameObject.Find ("shotsNumber");
		healthNumberRef = GameObject.Find ("HealthNumber");
		timerNumberRef = GameObject.Find ("TimerNumber");
		//livesNumberRef = GameObject.Find ("livesNumber");
		//score = 0;
		score = PlayerPrefs.GetInt ("LastScore");
		canShoot = 0;
		timer = 50;
		health = 3;
		//lives = 3;
		updateScore ();	//Calls the update score function
		InvokeRepeating ("lowerTime", 2, 2.0F);
	}

	//void Update(){
	//	oneSecond++;
	//	if (oneSecond == 20) {
	//		timer--;
	//		timerNumberRef.GetComponent<Text> ().text = timer.ToString ();
		//	oneSecond=0;
		//}
	//}

	void lowerTime() {
		timer--;
		timerNumberRef.GetComponent<Text> ().text = timer.ToString ();
		if (timer == 0 && Application.loadedLevelName != "START") {
			Application.LoadLevel("GAME_OVER");
		}
	}

	//This function updates the score
	public void updateScore()
	{
		scoreTextRef.GetComponent<Text> ().text = score.ToString (); //Sets the score to the score
		PlayerPrefs.SetInt ("LastScore", score);
		canShoot++;
		shotsNumberRef.GetComponent<Text> ().text = canShoot.ToString ();
		//print (canShoot);
		healthNumberRef.GetComponent<Text> ().text = health.ToString ();
		//livesNumberRef.GetComponent<Text> ().text = health.ToString ();

	}
}

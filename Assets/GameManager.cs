using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Need this for referencing UI objects

public class GameManager : MonoBehaviour {

	public int score;
	public GameObject scoreTextRef;	//This references the score text, so we can change it later
	// Use this for initialization
	void Start () 
	{
		scoreTextRef = GameObject.Find ("scoreText");
		score = 0;
		updateScore ();	//Calls the update score function
	}

	//This function updates the score
	public void updateScore()
	{
		scoreTextRef.GetComponent<Text> ().text = score.ToString (); //Sets the score to the score
	}

}

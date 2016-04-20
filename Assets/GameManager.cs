using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Need this for referencing UI objects

public class GameManager : MonoBehaviour {

	public int score;
	public int canShoot;
	public GameObject scoreTextRef;	//This references the score text, so we can change it later
	public GameObject shotsNumberRef;
	// Use this for initialization
	void Start () 
	{
		scoreTextRef = GameObject.Find ("scoreText");
		shotsNumberRef = GameObject.Find ("shotsNumber");
		score = 0;
		canShoot = 0;
		updateScore ();	//Calls the update score function
	}

	//This function updates the score
	public void updateScore()
	{
		scoreTextRef.GetComponent<Text> ().text = score.ToString (); //Sets the score to the score
		canShoot++;
		shotsNumberRef.GetComponent<Text> ().text = canShoot.ToString ();
		print (canShoot);
	}

}

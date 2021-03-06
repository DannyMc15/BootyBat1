﻿
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	
	public float seconds = 1.0f;
	
	public int health = 3; // Amount of health
	//public int lives = 3;
	public int invincibleTimer = 500;
	
	public bool isInvulnerable = false;
	
	public string targetTag = "Enemy";
	public string targetTag2 = "Falling Hazard";
	public string targetTag3 = "Projectile";

	private GameManager gameManage;

	AudioSource source;
	public AudioClip sound;
	
	void Start(){
		gameManage = FindObjectOfType<GameManager> ();
		source = GetComponent<AudioSource> ();
	}
	
	
	void OnCollisionEnter2D(Collision2D target)
	{
		if(target.gameObject.tag == targetTag && isInvulnerable == false
		   ||target.gameObject.tag==targetTag2 && isInvulnerable == false
			||target.gameObject.tag==targetTag3 && isInvulnerable == false)
		{
			StartCoroutine(InvulnerableDelay());
			health--;
			source.PlayOneShot(sound);
			gameManage.health--;
			gameManage.healthNumberRef.GetComponent<Text> ().text = health.ToString ();
			invincibleTimer = 0;
			//print("HIT!");
		}
		if (health == 0){
			//lives--;
			//gameManage.lives--;
			//gameManage.livesNumberRef.GetComponent<Text> ().text = health.ToString ();
			//PlayerPrefs.SetInt("LastScore", gameManage.score);
			Application.LoadLevel("GAME_OVER"); 
		}
		//if (lives == 0) {//add gameover scene here
			//Application.LoadLevel(GameOverScreen);
		//}
		
	}

	void OnTriggerEnter2D (Collider2D target){
		if (target.gameObject.tag == targetTag3 && isInvulnerable == false) {
			StartCoroutine(InvulnerableDelay());
			health--;
			gameManage.health--;
			gameManage.healthNumberRef.GetComponent<Text> ().text = health.ToString ();
			invincibleTimer = 0;
		}
		if (health == 0){
			Application.LoadLevel("GAME_OVER"); 
		}
	}
	
	private IEnumerator InvulnerableDelay()
	{
		isInvulnerable = true;
		yield return new WaitForSeconds(seconds);
		isInvulnerable = false;
	}
}
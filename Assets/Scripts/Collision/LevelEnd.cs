using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {
	
	public string targetTag = "Player";
	public int win = 0;
	public int ScoreNumber = 0;
	
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			
		}
	}

	void OnGUI () {
		// Make a background box
		//GUI.Box(new Rect(850,10,100,50), "SCORE:");
	}

}
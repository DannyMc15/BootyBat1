using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public string targetTag = "Player";
	public string targetTag2 = "echoBlast";
	public string targetTag3 = "Falling Hazard";
	
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			Application.LoadLevel(Application.loadedLevel);
		}
		if (target.gameObject.tag == targetTag2) {
			Destroy (gameObject);
		}

		if (target.gameObject.tag == targetTag3) {
			Destroy (gameObject);
		}
	}
}

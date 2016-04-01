using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {
	
	public string targetTag = "Player";
	
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
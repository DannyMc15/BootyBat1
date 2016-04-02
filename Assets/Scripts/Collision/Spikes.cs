using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {
	
	public string targetTag = "Player";
	public string targetTag2 = "echoBlast";
	
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			Application.LoadLevel(Application.loadedLevel);
		}
		if (target.gameObject.tag == targetTag2) {
			print ("killed!");
			Destroy (gameObject);
		}
	}
}
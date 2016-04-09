using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public string targetTag = "Player";
	public string targetTag2 = "echoBlast";
	public string targetTag3 = "Falling Hazard";

	private int counter = 0;

	void Update(){
		if (counter == 1) {
			counter++;
		}
		if (counter == 10000) {
			counter = 0;
		}
	}
	
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			Application.LoadLevel(Application.loadedLevel);
			counter = 1;
		}
		if (target.gameObject.tag == targetTag2) {
			Destroy (gameObject);
		}

		if (target.gameObject.tag == targetTag3) {
			Destroy (gameObject);
		}
	}

	void OnGUI() {
		if (counter >0) {
			GUI.Label (new Rect (250, 10, 100, 200), "TRY AGAIN!");
		}
	}
}

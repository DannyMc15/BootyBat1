using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {
	
	public string targetTag = "Player";
	public string targetTag2 = "echoBlast";
	private int counter=0;

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
			print ("killed!");
			Destroy (gameObject);
		}
	}

	void OnGUI() {
		if (counter >0) {
			GUI.Label (new Rect (250, 10, 100, 20), "TRY AGAIN!");
		}
	}
}
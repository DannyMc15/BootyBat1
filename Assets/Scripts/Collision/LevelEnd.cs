using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

	public GameObject Player;
	private int counter;
	
	void OnTriggerEnter2D(Collider2D target){
		Destroy(Player);
		counter = 1;
	}

	void OnGUI() {
		if (counter == 1) {
			GUI.Label (new Rect (250, 10, 1000, 20), "CONGRATULATIONS!");
		}
	}

}
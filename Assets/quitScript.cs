using UnityEngine;
using System.Collections;

public class quitScript : MonoBehaviour {

	private string targetTag = "Player";
	
	
	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == targetTag) {
			Application.Quit();
		}
	}
}
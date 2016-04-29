using UnityEngine;
using System.Collections;

public class levelLoader : MonoBehaviour {

	public string nextLevel;
	private string targetTag = "Player";

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == targetTag) {
			Application.LoadLevel (nextLevel);
		}
	}
}

using UnityEngine;
using System.Collections;

public class MakeHazardFall : MonoBehaviour {
	
	public string targetTag = "Falling Hazard";
	
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}

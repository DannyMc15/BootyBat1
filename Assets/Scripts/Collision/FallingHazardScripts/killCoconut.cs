using UnityEngine;
using System.Collections;

public class killCoconut : MonoBehaviour {
	
	public string targetTag = "Falling Hazard";
	public GameObject hazard;
	
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			Destroy(hazard);
		}
	}
}

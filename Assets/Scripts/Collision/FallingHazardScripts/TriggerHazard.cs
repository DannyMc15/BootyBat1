using UnityEngine;
using System.Collections;

public class TriggerHazard : MonoBehaviour {

	public string targetTag = "Player";

	public Rigidbody2D body2d;

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			print ("FALL!!!");
			body2d.WakeUp();
		}
	}
}
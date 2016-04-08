using UnityEngine;
using System.Collections;

public class FallingHazard : MonoBehaviour {

	public string targetTag = "Player";
	public string targetGround = "Ground";
	public LayerMask collisionLayer;
	public bool standing;
	public Vector2 bottomPosition = Vector2.zero;
	public float collisionRadius = 10f;

	private int ground = 0;
				
	void FixedUpdate(){
				
		var pos = bottomPosition;
		pos.x += transform.position.x;
		pos.y += transform.position.y;
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag && ground == 0) {
			killBooty ();
		}

		if (target.gameObject.tag == targetGround) {
			ground = 1;
		}
	}

	void killBooty(){
		Application.LoadLevel (Application.loadedLevel);
	}
}

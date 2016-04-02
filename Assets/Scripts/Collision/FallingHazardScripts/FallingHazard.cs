using UnityEngine;
using System.Collections;

public class FallingHazard : MonoBehaviour {

	public string targetTag = "Player";
	public LayerMask collisionLayer;
	public bool standing;
	public Vector2 bottomPosition = Vector2.zero;
	public float collisionRadius = 10f;
				
			void FixedUpdate(){
				
				var pos = bottomPosition;
				pos.x += transform.position.x;
				pos.y += transform.position.y;
				
				standing = Physics2D.OverlapCircle (pos, collisionRadius, collisionLayer);
				
			}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	void Update(){

	}
}

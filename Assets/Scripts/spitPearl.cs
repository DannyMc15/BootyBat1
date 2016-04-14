using UnityEngine;
using System.Collections;

public class spitPearl : MonoBehaviour {
	
	public string targetTag = "Player";
	public string targetGround = "Ground";
	public LayerMask collisionLayer;
	public bool standing;
	public Vector2 bottomPosition = Vector2.zero;
	public float collisionRadius = 10f;
	
	private int ground = 0;
	private int counter = 0;
	
	void Update(){
		if (counter == 1) {
			counter++;
		}
		if (counter == 10000) {
			counter = 0;
		}
	}
	
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
		counter = 1;
	}
	
	void OnGUI() {
		if (counter >0) {
			GUI.Label (new Rect (250, 10, 100, 20), "TRY AGAIN!");
		}
	}
}

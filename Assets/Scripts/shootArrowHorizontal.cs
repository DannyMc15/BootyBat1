using UnityEngine;
using System.Collections;

public class shootArrowHorizontal : MonoBehaviour {
	
	public GameObject player;
	private float distance;
	private Rigidbody2D body2d;
	public int gravityChange= -20;
	
	private bool canBreak = false;

	//public Vector2 gravity;
	
	// Use this for initialization
	void Start () {
		body2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player.transform.position, gameObject.transform.position);
		//print (distance);
		if (distance <= 180) {
			body2d.constraints = RigidbodyConstraints2D.None;
			//body2d.AddForce(gravityChange);
			body2d.AddForce(Vector2.left);
			//body2d.gravityScale=gravityChange;
			canBreak=true;

		}
	}
	
	void OnCollisionEnter2D(Collision2D target){
		if (canBreak == true) {
			Destroy (gameObject);
		}
	}
}
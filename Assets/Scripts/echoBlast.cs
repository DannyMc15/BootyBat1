using UnityEngine;
using System.Collections;

public class echoBlast : MonoBehaviour {

	public Vector2 initialVelocity = new Vector2(100,-100);
	public int bounces = 1;

	private Rigidbody2D body2d;

	void Awake(){
		body2d = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		//coll = GetComponent<Collider> ();
		//coll.isTrigger = true;

		var startVelX = initialVelocity.x * transform.localScale.x;


		body2d.velocity = new Vector2 (startVelX, initialVelocity.y);
	
	}
	
	void OnCollisionEnter2D(Collision2D target){
		if (bounces == 1) 
			Destroy (gameObject);
	}
}

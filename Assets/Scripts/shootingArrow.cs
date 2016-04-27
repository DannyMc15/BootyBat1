using UnityEngine;
using System.Collections;

public class shootingArrow : MonoBehaviour {
	
	public GameObject player;
	private float distance;
	private Rigidbody2D body2d;
	public int gravityChange= -40;
	public int howFar = 180;
	
	private bool canBreak = false;
	
	// Use this for initialization
	void Start () {
		body2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player.transform.position, gameObject.transform.position);
		//print (distance);
		if (distance <= howFar) {
			body2d.gravityScale=gravityChange;
			canBreak=true;
			body2d.constraints = RigidbodyConstraints2D.None;
		}
	}
	
	void OnCollisionEnter2D(Collision2D target){
		if (canBreak == true) {
			Destroy (gameObject);
		}
	}
}
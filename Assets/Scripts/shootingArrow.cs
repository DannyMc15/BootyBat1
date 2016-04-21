using UnityEngine;
using System.Collections;

public class shootingArrow : MonoBehaviour {
	
	public GameObject player;
	private float distance;
	private Rigidbody2D body2d;
	public int gravityChange= -20;
	
	private bool canBreak = false;
	
	// Use this for initialization
	void Start () {
		body2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player.transform.position, gameObject.transform.position);
		//print (distance);
		if (distance <= 180) {
			body2d.gravityScale=gravityChange;
			canBreak=true;
		}
	}
	
	void OnCollisionEnter2D(){
		if(canBreak==true)
			Destroy (gameObject);
	}
}
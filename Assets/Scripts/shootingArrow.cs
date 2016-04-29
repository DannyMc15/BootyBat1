using UnityEngine;
using System.Collections;

public class shootingArrow : MonoBehaviour {
	
	public GameObject player;
	private float distance;
	private Rigidbody2D body2d;
	public int gravityChange= -40;
	public int howFar = 180;
	
	private bool canBreak = false;

	AudioSource source;
	public AudioClip shoot;
	private bool canPlay = true;
	
	// Use this for initialization
	void Start () {
		body2d = GetComponent<Rigidbody2D> ();
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player.transform.position, gameObject.transform.position);
		//print (distance);
		if (distance <= howFar) {
			playSE ();
			body2d.gravityScale=gravityChange;
			body2d.constraints = RigidbodyConstraints2D.None;
			canBreak=true;
			//Invoke("makeBreakable",0.5);

		}
	}
	
	void OnCollisionEnter2D(Collision2D target){
		if (canBreak == true) {
			Destroy (gameObject);
		}
	}

	void makeBreakable(){
		canBreak = true;
	}

	void playSE(){
		if (canPlay == true) {
			source.PlayOneShot (shoot);
			canPlay = false;
		}
	}
}
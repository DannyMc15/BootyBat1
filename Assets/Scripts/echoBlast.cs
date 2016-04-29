using UnityEngine;
using System.Collections;


public class echoBlast : MonoBehaviour {

	public Vector2 initialVelocity = new Vector2(100,-100);
	public int bounces = 1;

	private Rigidbody2D body2d;
	private float startTime;
	private int finalAnimation;
	private bool stopped = false;

	private Animator animator;

	private ParticleSystem ps;
	private SpriteRenderer sr;
	private CircleCollider2D cc;

	private bool hasShot = false;

	void Awake(){
		body2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		//coll = GetComponent<Collider> ();
		//coll.isTrigger = true;
		ps = GetComponent<ParticleSystem> ();
		sr = GetComponent<SpriteRenderer> ();
		cc = GetComponent<CircleCollider2D> ();

		var startVelX = initialVelocity.x * transform.localScale.x;


		body2d.velocity = new Vector2 (startVelX, initialVelocity.y);
		startTime = Time.time;
	
	}

	void Update(){
		if (Time.time - startTime > 2) {
			//print ("5");
			//Destroy (gameObject);
			BlowUp ();
		}
		if (stopped == true) {
			finalAnimation++;
		}
		if (finalAnimation >= 6) {
			//Destroy(gameObject);
			Destroy (sr);
		}
	}
	
	void OnCollisionEnter2D(Collision2D target){
		if (bounces == 1) {
			//print ("collision");
			if(hasShot==false){
				ps.Play();
				hasShot=true;
			}
			BlowUp();
		}
	}

	void BlowUp(){
		//animator.SetBool("Active", false);
		stopped=true;
		body2d.velocity = new Vector2(0,0);
		Invoke ("Disintigrate", 1);
	}

	void Disintigrate(){
		Destroy (sr);
		Destroy (cc);
	}
}

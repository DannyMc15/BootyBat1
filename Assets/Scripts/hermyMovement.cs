using UnityEngine;
using System.Collections;

public class hermyMovement : MonoBehaviour {
	
	public float moveSpeed;
	public int distCounter = 0;
	public int distancetoWalk = 100;
	public GameManager gameManagerRef;

	public string targetTag = "Player";
	public string targetTag2 = "echoBlast";
	public string targetTag3 = "Falling Hazard";

	private bool hitByBlast = false;
	private bool isWalking = true;

	AudioSource source;
	public AudioClip sound;
	
	//private int counter = 0;
	//private int counter2 = 0;
	
	private Animator hermyAnimator;

	void Awake(){;
		hermyAnimator = GetComponent<Animator> ();
		source = GetComponent<AudioSource> ();
	}
	
	// Use this for initialization
	void Start () {
		gameManagerRef = GameObject.Find ("GameManager").GetComponent<GameManager> ();	//on start, get reference
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		distCounter++;
		if (distCounter < distancetoWalk&&isWalking==true) {
			transform.Translate (new Vector3 (moveSpeed, 0, 0) * Time.deltaTime);
			//transform.localScale = new Vector3(1, 1, 1);
			//transform.localScale = new Vector3 (1, 1, 1);
		} else if (distCounter == distancetoWalk) {
			moveSpeed *= -1;
			distCounter = 0;
			//transform.localScale = new Vector3(-1, 1, 1);
			//transform.localScale = new Vector3 (-1, 1, 1);
		}

		if(moveSpeed > 0){
			transform.localScale = new Vector3(1, 1, 1);
		}else{
			transform.localScale = new Vector3(-1, 1, 1);
		}

		//if (counter == 1) {
		//	counter++;
		//}
		//if (counter == 10000) {
		//	counter = 0;
		//}
		if (hitByBlast == true) {
			Invoke ("killIt", 0.6F);
		}
	}
	
	void OnCollisionEnter2D(Collision2D target){
			//if (target.gameObject.tag == targetTag) {
				//Application.LoadLevel(Application.loadedLevel);
				//counter = 1;
			//}
			if (target.gameObject.tag == targetTag2) {
				source.PlayOneShot(sound,1.5F);
				gameObject.tag="Untagged";
				isWalking=false;
				hermyAnimator.SetBool("killed", true);
				//counter2=0;
				hitByBlast=true;
				addPoints();
			}
			
			if (target.gameObject.tag == targetTag3) {
				//Destroy (gameObject);
				hitByBlast=true;
			}
	}

	public void addPoints()
	{
		gameManagerRef.score += 10;
		gameManagerRef.updateScore ();
		
	}

	void killIt() {
		Destroy(gameObject);
	}
	
}

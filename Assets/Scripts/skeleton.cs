using UnityEngine;
using System.Collections;

public class skeleton : MonoBehaviour {

	public float moveSpeed;
	public int distCounter = 0;
	
	public string targetTag = "Player";
	public string targetTag2 = "echoBlast";
	public string targetTag3 = "Falling Hazard";
	public GameManager gameManagerRef;
	
	private bool hitByBlast = false;
	
	//private int counter = 0;
	private int finalAnimCount = 0;
	private int animationCounter = 0;
	private bool isWalking = true;
	
	private Animator animator;

	AudioSource source;
	public AudioClip sound;
	
	void Awake(){;
		animator = GetComponent<Animator> ();
		source = GetComponent<AudioSource> ();
	}

	void Start () {
		gameManagerRef = GameObject.Find ("GameManager").GetComponent<GameManager> ();	//on start, get reference
	}
	
	void FixedUpdate(){

		//Change Animations and Swing Sword
		animationCounter++;
		if (animationCounter >= 150 &&finalAnimCount==0) {//swing sword
			isWalking=false;
			ChangeAnimationState(1);
			animationCounter=0;
		}
		if (animationCounter >=40&&animationCounter<60 &&finalAnimCount==0) {//back to walking
			isWalking=true;
			ChangeAnimationState(0);
		}

		/*if (counter == 1) {
			counter++;
		}
		if (counter == 10000) {
			counter = 0;
		}*/

		//Kill Him
		/*if (hitByBlast == true) {
			finalAnimCount++;
		}
		if(finalAnimCount==20){
			Destroy (gameObject);
		}*/

		if (hitByBlast == true) {
			source.PlayOneShot(sound,0.8F);
			Invoke ("killIt", 0.6F);
		}

		//Change Direction He's Walking
		distCounter++;
		if (distCounter < 100/*&&finalAnimCount==0*/&&isWalking==true) {
			transform.Translate (new Vector3 (moveSpeed, 0, 0) * Time.deltaTime);
		} else if (distCounter == 100/*&&finalAnimCount==0*/) {
			moveSpeed *= -1;
			distCounter = 0;
		}

		//Change Direction He's Facing
		if(moveSpeed > 0){
			transform.localScale = new Vector3(1, 1, 1);
		}
		else{
			transform.localScale = new Vector3(-1, 1, 1);
		}

	}
	
	void OnTriggerEnter2D(Collider2D target){
		//if (target.gameObject.tag == targetTag) {
			//Application.LoadLevel(Application.loadedLevel);
			//counter = 1;
		//}
		if (target.gameObject.tag == targetTag2) {
			gameObject.tag="Untagged";
			isWalking=false;
			ChangeAnimationState(2);
			//finalAnimCount=0;
			hitByBlast=true;
			addPoints();
		}
		
		//if (target.gameObject.tag == targetTag3) {
			//Destroy (gameObject);
			//hitByBlast=false;
		//}
	}

	public void addPoints()
	{
		gameManagerRef.score += 10;
		gameManagerRef.updateScore ();
		
	}

	void ChangeAnimationState(int value){
		animator.SetInteger ("skeleState", value);
	}

	void killIt() {
		Destroy(gameObject);
	}
}

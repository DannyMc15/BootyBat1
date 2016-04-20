using UnityEngine;
using System.Collections;

public class skeleton : MonoBehaviour {

	public float moveSpeed;
	public int distCounter = 0;
	
	public string targetTag = "Player";
	public string targetTag2 = "echoBlast";
	public string targetTag3 = "Falling Hazard";
	
	private bool hitByBlast = false;
	
	//private int counter = 0;
	private int finalAnimCount = 0;
	private int animationCounter = 0;
	private bool isWalking = true;
	
	private Animator animator;
	
	void Awake(){;
		animator = GetComponent<Animator> ();
	}
	
	void Update(){

		//Change Animations and Swing Sword
		animationCounter++;
		if (animationCounter >= 60 &&finalAnimCount==0) {//swing sword
			isWalking=false;
			ChangeAnimationState(1);
			animationCounter=0;
		}
		if (animationCounter >=10&&animationCounter<60 &&finalAnimCount==0) {//back to walking
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
		if (hitByBlast == true) {
			finalAnimCount++;
		}
		if(finalAnimCount==20){
			Destroy (gameObject);
		}

		//Change Direction He's Walking
		distCounter++;
		if (distCounter < 100&&finalAnimCount==0&&isWalking==true) {
			transform.Translate (new Vector3 (moveSpeed, 0, 0) * Time.deltaTime);
		} else if (distCounter == 100&&finalAnimCount==0) {
			print ("change direction");
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
		if (target.gameObject.tag == targetTag) {
			//Application.LoadLevel(Application.loadedLevel);
			//counter = 1;
		}
		if (target.gameObject.tag == targetTag2) {
			ChangeAnimationState(2);
			finalAnimCount=0;
			hitByBlast=true;
		}
		
		if (target.gameObject.tag == targetTag3) {
			//Destroy (gameObject);
			//hitByBlast=false;
		}
	}
	
	/*void OnGUI() {
		if (counter >0) {
			GUI.Label (new Rect (250, 10, 100, 200), "TRY AGAIN!");
		}
	}*/

	void ChangeAnimationState(int value){
		animator.SetInteger ("skeleState", value);
	}
}

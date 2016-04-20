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
	
	private Animator animator;
	
	void Awake(){;
		animator = GetComponent<Animator> ();
	}
	
	void Update(){
		animationCounter++;
		if (animationCounter >= 20) {//swing sword
			//ChangeAnimationState(1);
		}

		/*if (counter == 1) {
			counter++;
		}
		if (counter == 10000) {
			counter = 0;
		}*/
		
		if (hitByBlast == true) {
			finalAnimCount++;
		}
		
		if(finalAnimCount==6){
			Destroy (gameObject);
		}

		distCounter++;
		if (distCounter < 100) {
			print ("you should be walking");
			transform.Translate (new Vector3 (moveSpeed, 0, 0) * Time.deltaTime);
		} else if (distCounter == 100) {
			moveSpeed *= -1;
			distCounter = 0;
		}


		if(moveSpeed > 0){
			transform.localScale = new Vector3(1, 1, 1);
		}
		else{
			transform.localScale = new Vector3(-1, 1, 1);
		}

	}
	
	/*void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			//Application.LoadLevel(Application.loadedLevel);
			//counter = 1;
		}
		if (target.gameObject.tag == targetTag2) {
			animator.SetBool("isKilled", true);
			finalAnimCount=0;
			hitByBlast=true;
		}
		
		if (target.gameObject.tag == targetTag3) {
			//Destroy (gameObject);
			//hitByBlast=false;
		}
	}*/
	
	/*void OnGUI() {
		if (counter >0) {
			GUI.Label (new Rect (250, 10, 100, 200), "TRY AGAIN!");
		}
	}*/

	void ChangeAnimationState(int value){
		animator.SetInteger ("skeleState", value);
	}
}

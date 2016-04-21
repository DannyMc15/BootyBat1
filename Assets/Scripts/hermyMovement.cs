using UnityEngine;
using System.Collections;

public class hermyMovement : MonoBehaviour {
	
	public float moveSpeed;
	public int distCounter = 0;
	public int distancetoWalk = 100;

	public string targetTag = "Player";
	public string targetTag2 = "echoBlast";
	public string targetTag3 = "Falling Hazard";

	private bool hitByBlast = false;
	private bool isWalking = true;
	
	private int counter = 0;
	private int counter2 = 0;
	
	private Animator hermyAnimator;

	void Awake(){;
		hermyAnimator = GetComponent<Animator> ();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		distCounter++;
		if (distCounter < distancetoWalk&&isWalking==true) {
			transform.Translate (new Vector3 (moveSpeed, 0, 0) * Time.deltaTime);
			//transform.localScale = new Vector3 (1, 1, 1);
		} else if (distCounter == distancetoWalk) {
			moveSpeed *= -1;
			distCounter = 0;
			//transform.localScale = new Vector3 (-1, 1, 1);
		}
		if(moveSpeed > 0)
		{
			transform.localScale = new Vector3(1, 1, 1);
		}
		else
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}

		if (counter == 1) {
			counter++;
		}
		if (counter == 10000) {
			counter = 0;
		}
		
		if (hitByBlast == true) {
			counter2++;
		}
		
		if(counter2==20){
			
			Destroy (gameObject);
		}
	}
	
	void OnCollisionEnter2D(Collision2D target)
	{
			if (target.gameObject.tag == targetTag) {
				//Application.LoadLevel(Application.loadedLevel);
				//counter = 1;
			}
			if (target.gameObject.tag == targetTag2) {
				gameObject.tag="Untagged";
				isWalking=false;
				hermyAnimator.SetBool("killed", true);
				counter2=0;
				hitByBlast=true;
			}
			
			if (target.gameObject.tag == targetTag3) {
				//Destroy (gameObject);
				hitByBlast=false;
			}
	}

	void OnGUI() {
		if (counter >0) {
			GUI.Label (new Rect (250, 10, 100, 200), "TRY AGAIN!");
		}
	}
	
	
}

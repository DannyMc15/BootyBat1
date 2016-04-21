using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public string targetTag = "Player";
	public string targetTag2 = "echoBlast";
	public string targetTag3 = "Falling Hazard";

	private bool hitByBlast = false;

	private int counter = 0;
	private int counter2 = 0;

	private Animator animator;

	void Awake(){;
		animator = GetComponent<Animator> ();
	}

	void Update(){
		if (counter == 1) {
			counter++;
		}
		if (counter == 10000) {
			counter = 0;
		}

		if (hitByBlast == true) {
			counter2++;
		}

		if(counter2==6){

			Destroy (gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D target){

		if (target.gameObject.tag == targetTag) {
			//Application.LoadLevel(Application.loadedLevel);
			//counter = 1;
		}
		if (target.gameObject.tag == targetTag2||target.gameObject.tag==targetTag3) {
			gameObject.tag="Untagged";
			animator.SetBool("isKilled", true);
			counter2=0;
			hitByBlast=true;
		}
	}

	void OnGUI() {
		if (counter >0) {
			GUI.Label (new Rect (250, 10, 100, 200), "TRY AGAIN!");
		}
	}
}

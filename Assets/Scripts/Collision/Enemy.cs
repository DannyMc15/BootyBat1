using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public string targetTag = "Player";
	public string targetTag2 = "echoBlast";
	public string targetTag3 = "Falling Hazard";

	//private bool hitByBlast = false;

	//private int counter = 0;
	//private int counter2 = 0;

	private Animator animator;

	AudioSource source;
	public AudioClip sound;

	void Awake(){;
		animator = GetComponent<Animator> ();
		source = GetComponent<AudioSource> ();
	}

	//void Update(){
		/*if (counter == 1) {
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
		}*/
	//}
	
	void OnTriggerEnter2D(Collider2D target){

		if (target.gameObject.tag == targetTag) {
			//Application.LoadLevel(Application.loadedLevel);
			//counter = 1;
		}
		if (target.gameObject.tag == targetTag2||target.gameObject.tag==targetTag3) {
			source.PlayOneShot(sound,4F);
			gameObject.tag="Untagged";
			animator.SetBool("isKilled", true);
			//counter2=0;
			//hitByBlast=true;
			Invoke ("killIt",1);
		}
	}

	void killIt(){
		Destroy (gameObject);
	}
}

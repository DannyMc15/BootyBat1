using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private InputState inputState;
	private Walk walkBehavior;
	private Animator animator;

	private Health health;

	//private CollisionState cs;

	void Awake(){
		inputState = GetComponent<InputState> ();
		walkBehavior = GetComponent<Walk> ();
		animator = GetComponent<Animator> ();
	}

	void Start () {
		//cs = FindObjectOfType<CollisionState>();
		health = FindObjectOfType<Health> ();
	}

	void Update () {
		if (health.isInvulnerable == false) { 

			if (inputState.absVelX == 0) {
				ChangeAnimationState (0);
			}

			if (inputState.absVelX > 0) {
				ChangeAnimationState (1);
			}

			if (inputState.absVelY > 0) {
				ChangeAnimationState (2);
			}
		} else if (health.isInvulnerable == true) {
			//print ("OUCH!");
			ChangeAnimationState(4);
		}
	}

	void ChangeAnimationState(int value){
		animator.SetInteger ("AnimState", value);
	}
}

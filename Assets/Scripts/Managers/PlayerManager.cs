using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private InputState inputState;
	private Walk walkBehavior;
	private Animator animator;

	private CollisionState cs;

	void Awake(){
		inputState = GetComponent<InputState> ();
		walkBehavior = GetComponent<Walk> ();
		animator = GetComponent<Animator> ();
	}

	void Start () {
		cs = FindObjectOfType<CollisionState>();
	}

	void Update () {
		if (inputState.absVelX == 0) {
			ChangeAnimationState(0);
		}

		if (inputState.absVelX > 0) {
			ChangeAnimationState(1);
		}

		if (inputState.absVelY > 0) {
			ChangeAnimationState(2);
		}
	}

	void ChangeAnimationState(int value){
		animator.SetInteger ("AnimState", value);
	}
}

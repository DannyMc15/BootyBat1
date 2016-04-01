using UnityEngine;
using System.Collections;

public class Walk : AbstractBehavior {


	public float speed = 50f;
	//public float runMultiplier = 2f;
	private CollisionState cs;

	// Use this for initialization
	void Start () {
		cs = FindObjectOfType<CollisionState>();
	}
	
	// Update is called once per frame
	void Update () {

		if (cs.standing == true) {
			body2d.velocity = new Vector2 (0, body2d.velocity.y);
		}

		var right = inputState.GetButtonValue (inputButtons [0]);
		var left = inputState.GetButtonValue (inputButtons [1]);
		var run = inputState.GetButtonValue (inputButtons [2]);

		if (right || left) {

			var tmpSpeed = speed;

			//if(run && runMultiplier > 0){
			//	tmpSpeed *= runMultiplier;
			//}

			var velX = tmpSpeed * (float)inputState.direction;

			body2d.velocity = new Vector2 (velX, body2d.velocity.y);

		} 
		else {
			//body2d.velocity = new Vector2 (0, body2d.velocity.y);
		}
	}
}
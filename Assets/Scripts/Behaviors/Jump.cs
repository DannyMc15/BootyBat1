using UnityEngine;
using System.Collections;

public class Jump : AbstractBehavior {

	public float jumpSpeed = 100f;
    public float flapSpeed = 100f;
    public float jumpDelay = .1f;
    public int jumpCount = 1;

    protected float lastJumpTime = 0;
    protected int jumpsRemaining = 0;//for limiting number of flaps

    private CollisionState cs;

	// Use this for initialization
	void Start () {
        cs = FindObjectOfType<CollisionState>();
	}
	
	// Update is called once per frame
	void Update () {
		var canJump = inputState.GetButtonValue (inputButtons [0]);
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);

		if (cs.standing) {
			if(canJump && holdTime < .1f ){//try adding jumps here
                //jumpsRemaining = jumpCount - 1;
				OnJump ();
			}
		} else {
            if(canJump && holdTime < .1f && Time.time - lastJumpTime > jumpDelay /*&& jumpsRemaining > 0*/){
                OnFlap();
				print("flap");
            }
        }
	}

	protected virtual void OnJump(){
		var vel = body2d.velocity;

		body2d.velocity = new Vector2 (vel.x, jumpSpeed);
	}

    protected virtual void OnFlap()
    {
        var vel = body2d.velocity;
        lastJumpTime = Time.time;
        body2d.velocity = new Vector2(vel.x, flapSpeed);
		//body2d.velocity = new Vector2(vel.x, 5);
    }

}

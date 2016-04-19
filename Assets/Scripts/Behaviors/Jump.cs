using UnityEngine;
using System.Collections;

public class Jump : AbstractBehavior {

	public float jumpSpeed = 100f;
    public float flapSpeed = 100f;
    public float jumpDelay = .1f;
    public int jumpCount = 1;

	public AudioClip flapSound1;
	public AudioClip flapSound2;
	public AudioClip flapSound3;
	private int clipCounter = 0;
	AudioSource audio;

    protected float lastJumpTime = 0;
    protected int jumpsRemaining = 0;//for limiting number of flaps

    private CollisionState cs;

	private Animator animator;

	// Use this for initialization
	void Start () {
        cs = FindObjectOfType<CollisionState>();
		animator = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
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
				//print("flap");
				if(clipCounter==0){
					audio.PlayOneShot(flapSound1);
					clipCounter++;
				}
				else if (clipCounter==1){
					audio.PlayOneShot(flapSound2);
					clipCounter++;
				}
				else if(clipCounter==2){
					audio.PlayOneShot(flapSound3);
					clipCounter=clipCounter-2;
				}
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
		//ChangeAnimationState (3);
		//body2d.velocity = new Vector2(vel.x, 5);
    }

	void ChangeAnimationState(int value){
		animator.SetInteger ("AnimState", value);
	}

}

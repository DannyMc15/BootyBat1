using UnityEngine;
using System.Collections;

public class EnemyFiring : MonoBehaviour {

	public GameObject player;

	//public float attackDelay = 1f;
	public float xForce = 1f;
	public float yForce = 1f;
	public GameObject projectilePref; //Set this in the inspecctor

	public int startTime;
	public float repeatRate;

	private float distance;
	private bool start=false;

	AudioSource source;
	public AudioClip sound;

	private Rigidbody2D body2d;
	private bool playSound = false;


	private GameObject tempObj;//We use this to reference the instantiated projectile
	// Use this for initialization
	void Start () {
		InvokeRepeating ("shootProj", startTime, repeatRate);
		source = GetComponent<AudioSource> ();
		body2d = GetComponent<Rigidbody2D> ();
		//if (attackDelay > 0) 
		//{
		//	StartCoroutine (OnAttack());
		//}
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player.transform.position, gameObject.transform.position);
		if (distance <= 1000) {
			playSound = true;
		} else {
			playSound=false;
		}
	}

	void shootProj(){
		if (playSound == true) {
			source.PlayOneShot (sound);
		}
		shootProjectile (new Vector2(xForce, yForce));
	}

	/*IEnumerator OnAttack(){
		//print ("FIRE");
		shootProjectile (new Vector2(xForce, yForce));
		yield return new WaitForSeconds(attackDelay);
		StartCoroutine (OnAttack ());
	}*/

	void shootProjectile(Vector2 direction)
	{
		//Debug.Log ("DERP");
//		Debug.Log (gameObject.name);
		tempObj = (GameObject)Instantiate (projectilePref, transform.position, Quaternion.identity);
		tempObj.GetComponent<Rigidbody2D> ().AddForce (direction);
	}

}

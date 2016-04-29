using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	public string targetTag = "Player";
	public GameManager gameManagerRef;// This is a reference to the game manager script. It is set on start.
	AudioSource audio;
	public AudioClip pickup;
	private ParticleSystem ps;
	private SpriteRenderer sr;
	private bool canCollect=true;
	private ParticleSystem partsys;

	void Start()
	{
		gameManagerRef = GameObject.Find ("GameManager").GetComponent<GameManager> ();	//on start, get reference
		audio = GetComponent<AudioSource> ();
		ps = GetComponent<ParticleSystem> ();
		sr = GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag&&canCollect==true) {
			audio.PlayOneShot (pickup);
			ps.Play();
			//partsys = (ParticleSystem)Instantiate (ps, this.transform.position, Quaternion.identity);
			OnCollect();
			OnDestroy();
			canCollect=false;
		}
	}

	 public void OnCollect()
	{
		//int num = LevelEnd.);
		//num += 100;
		gameManagerRef.score += 1;
		gameManagerRef.updateScore ();

	}

	protected virtual void OnDestroy(){
		//Destroy (gameObject);
		Destroy (sr);
	}
}

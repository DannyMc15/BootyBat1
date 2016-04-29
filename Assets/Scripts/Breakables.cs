using UnityEngine;
using System.Collections;

public class Breakables : MonoBehaviour {

    public string targetTag = "echoBlast";
	private SpriteRenderer sr;
	private BoxCollider2D bc;
	private ParticleSystem ps;

	AudioSource source;
	public AudioClip rock;

	void Start(){
		sr = GetComponent<SpriteRenderer> ();
		bc = GetComponent<BoxCollider2D> ();
		ps = GetComponent<ParticleSystem> ();
		source = GetComponent<AudioSource> ();
	}

    void OnCollisionEnter2D(Collision2D target){
        if (target.gameObject.tag == targetTag){
			source.PlayOneShot(rock);
			ps.Play();
			Destroy (bc);
			Destroy(sr);
            //Destroy(gameObject);
        }
    }
}

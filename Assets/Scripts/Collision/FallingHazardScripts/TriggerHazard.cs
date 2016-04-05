using UnityEngine;
using System.Collections;

public class TriggerHazard : MonoBehaviour {

	public string targetTag = "Player";
	public GameObject Hazard;

	public Rigidbody2D body2d;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			print ("FALL!!!");
			body2d.WakeUp();
		}
	}
}
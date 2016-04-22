using UnityEngine;
using System.Collections;

public class shootArrowVertical : MonoBehaviour {
	
	public GameObject player;
	private float distance;
	
	public int moveSpeed = -5;
	
	private bool canBreak = false;
	private bool shootIt = false;
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player.transform.position, gameObject.transform.position);
		if (distance <= 180) {
			shootIt = true;
			canBreak=true;
		}
		if (shootIt == true) {
			transform.position += new Vector3 (0, moveSpeed, 0);
		}
	}
	
	void OnCollisionEnter2D(){
		if (canBreak == true) {
			shootIt=false;
			Destroy (gameObject);
		}
	}
}

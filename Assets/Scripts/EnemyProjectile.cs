using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

	/*void OnCollisionEnter2D(Collision2D target)
	{
		Debug.Log (target.gameObject.name);
		Destroy (gameObject);
	}*/
	private bool hasShot = false;
	private int count;

	void Update(){
		count++;
		if (count >= 5) {
			hasShot=true;
		}
	}

	void OnCollisionEnter2D(){
		if (hasShot == true) {
			Destroy (gameObject);
			hasShot = false;
		}
	}

}

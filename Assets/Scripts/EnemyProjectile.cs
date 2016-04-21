using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

	/*void OnCollisionEnter2D(Collision2D target)
	{
		Debug.Log (target.gameObject.name);
		Destroy (gameObject);
	}*/

	void OnCollisionEnter2D(){
		Destroy (gameObject);
	}

}

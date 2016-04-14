using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D target)
	{
		Debug.Log (target.gameObject.name);
		Destroy (gameObject);
	}

}

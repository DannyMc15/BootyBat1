using UnityEngine;
using System.Collections;

public class finalTreasure : MonoBehaviour {

	private int counter = 0;

	// Use this for initialization
	void Start () {
		Invoke ("KillIt",5.0F);
	}
	
	// Update is called once per frame

	void KillIt(){
		Destroy (gameObject);
	}
}

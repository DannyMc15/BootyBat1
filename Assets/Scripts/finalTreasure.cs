using UnityEngine;
using System.Collections;

public class finalTreasure : MonoBehaviour {

	private int counter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (counter == 50)
			Destroy (gameObject);
	}
}

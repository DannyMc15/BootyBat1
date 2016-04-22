using UnityEngine;
using System.Collections;

public class hitMeAndStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(){
		Application.LoadLevel ("LEVEL_1");
	}
}

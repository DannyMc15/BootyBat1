﻿using UnityEngine;
using System.Collections;

public class CollisionState : MonoBehaviour {

	public LayerMask collisionLayer;
	public bool standing;
	public Vector2 bottomPosition = Vector2.zero;
	public float collisionRadius = 10f;

	//public string targetTag = "Finish";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

		var pos = bottomPosition;
		pos.x += transform.position.x;
		pos.y += transform.position.y;

		standing = Physics2D.OverlapCircle (pos, collisionRadius, collisionLayer);

	}

	/*void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			Destroy(gameObject);
		}
	}*/
}

using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	public string targetTag = "Player";
	public GameManager gameManagerRef;// This is a reference to the game manager script. It is set on start.

	void Start()
	{
		gameManagerRef = GameObject.Find ("GameManager").GetComponent<GameManager> ();	//on start, get reference
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			OnCollect();
			OnDestroy ();
		}
	}

	 public void OnCollect()
	{
		//int num = LevelEnd.);
		//num += 100;
		gameManagerRef.score += 1;
		gameManagerRef.updateScore ();
	}

	protected virtual void OnDestroy()
	{
		Destroy (gameObject);
	}
}

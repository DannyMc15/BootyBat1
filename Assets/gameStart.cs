using UnityEngine;
using System.Collections;

public class gameStart : MonoBehaviour {

	void Awake(){
		PlayerPrefs.SetInt ("LastScore", 0);
	}
}

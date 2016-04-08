using UnityEngine;
using System.Collections;

public class tilingGround : MonoBehaviour {

	public int textureSize = 16;
	public int newWidth = 2;
	public int newHeight = 1; 

	// Use this for initialization
	void Start () {

		//var newWidth = Mathf.Ceil (Screen.width / (textureSize * PixelPerfectCamera.scale));
		//var newHeight = Mathf.Ceil (Screen.width / (textureSize * PixelPerfectCamera.scale));

		transform.localScale = new Vector3 (newWidth*textureSize, newHeight*textureSize, 1);

		GetComponent<Renderer> ().material.mainTextureScale = new Vector3 (newWidth, newHeight, 1);
	
	}
}

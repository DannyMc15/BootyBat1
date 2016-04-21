using UnityEngine;
using System.Collections;

public class tileBlock : MonoBehaviour {

	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		//transform.renderer.material.mainTextureScale = new Vector2(XScale , YScale );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

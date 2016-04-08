using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

    static public FollowCam S;

	//public bool fields;
	public int scoreDisplay;

	public GameObject poi;
	public float camZ;
	public BoxCollider2D bottomBound;
	public BoxCollider2D topBound;
	public BoxCollider2D leftBound;
	public BoxCollider2D rightBound;

	private BoxCollider2D collider;


	void Awake() {
		S = this;
		camZ = this.transform.position.z;
	}

	void Update () {
		if (poi == null)
			return;

		Vector3 destination = poi.transform.position;
		destination.z = camZ;
		transform.position = destination;
	}
}

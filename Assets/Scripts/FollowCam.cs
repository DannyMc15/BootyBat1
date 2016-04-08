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
		//collider = this;
	}

	void Update () {
		if (poi == null)
			return;

		Vector3 destination = poi.transform.position;
		destination.z = camZ;

		/*if(leftBound.attachedRigidbody.IsTouching(BoxCollider2D collider){
			print ("touching left or right");
		}

		if (destination.y == leftBound.offset.y || destination.y == rightBound.offset.y) {
			//transform.position.x = destination.x;
			print ("touching left or right");
		} else if (destination.y == topBound.offset.y || destination.y == bottomBound.offset.y) {
			//transform.position.y = destination.y;
			print ("touching top or bottom");
		} else {*/
			transform.position = destination;
		//}
	}
}

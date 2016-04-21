using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

    static public FollowCam S;

	//public bool fields;
	public int scoreDisplay;

	public GameObject poi;
	public float camZ;


	void Awake() {
		S = this;
		camZ = this.transform.position.z;
	}

	void Update () {
		if (poi == null)
			return;

		if (poi.transform.position.x <= -30) {
			Vector3 destination = poi.transform.position;
			destination.z = camZ;
			transform.position = destination;
		}

		if (poi.transform.position.x >= -30) {
			Vector3 destination = poi.transform.position;
			destination.z = camZ;
			transform.position = destination;
		}
	}
}
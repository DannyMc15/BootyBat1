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

		/*if (poi.transform.position.x <= -40) {
			Vector3 destination = poi.transform.position;
			//destination.z = camZ;
			Vector3 sidemove = new Vector3 (-40, poi.transform.position.y, poi.transform.position.z);
			destination.z=camZ;
			//transform.position = destination;
			transform.position = sidemove;
		}*/

		//if (poi.transform.position.x >= -30) {
			Vector3 destination = poi.transform.position;
			destination.z = camZ;
			transform.position = destination;
		//}
	}
}
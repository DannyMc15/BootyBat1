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

		Vector3 destination = poi.transform.position;
		destination.z = camZ;
		transform.position = destination;
	}

        /*OPTION 2
    public GameObject player;
 
    public int depthOffset = -10;
    public int verticalOffset = 0;

    void Update()
    {
        transform.position = new Vector3(depthOffset,verticalOffset,player.transform.position.x);
    }*/
}

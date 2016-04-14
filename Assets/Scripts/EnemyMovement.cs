using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public float moveSpeed;
	public int distCounter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		distCounter++;
		if (distCounter < 100) {
			transform.Translate (new Vector3 (moveSpeed, 0, 0) * Time.deltaTime);
			//transform.localScale = new Vector3 (1, 1, 1);
		} else if (distCounter == 100) {
			moveSpeed *= -1;
			distCounter = 0;
			//transform.localScale = new Vector3 (-1, 1, 1);
		}
        if(moveSpeed > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Block")
        {
            moveSpeed *= -1;
         
        }
    }


}

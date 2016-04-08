using UnityEngine;
using System.Collections;

public class Breakables : MonoBehaviour {

    public string targetTag = "echoBlastTarget";

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == targetTag)
        {
            Destroy(gameObject);
        }
    }
}

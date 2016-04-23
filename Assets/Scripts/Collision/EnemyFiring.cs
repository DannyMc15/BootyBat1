using UnityEngine;
using System.Collections;

public class EnemyFiring : MonoBehaviour {

	public GameObject player;

	//public float attackDelay = 1f;
	public float xForce = 1f;
	public float yForce = 1f;
	public GameObject projectilePref; //Set this in the inspecctor

	public int startTime;
	public float repeatRate;

	private float distance;
	private bool start=false;


	private GameObject tempObj;//We use this to reference the instantiated projectile
	// Use this for initialization
	void Start () {
		InvokeRepeating ("shootProj", startTime, repeatRate);
		//if (attackDelay > 0) 
		//{
		//	StartCoroutine (OnAttack());
		//}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void shootProj(){
		shootProjectile (new Vector2(xForce, yForce));
	}

	/*IEnumerator OnAttack(){
		//print ("FIRE");
		shootProjectile (new Vector2(xForce, yForce));
		yield return new WaitForSeconds(attackDelay);
		StartCoroutine (OnAttack ());
	}*/

	void shootProjectile(Vector2 direction)
	{
		//Debug.Log ("DERP");
//		Debug.Log (gameObject.name);
		tempObj = (GameObject)Instantiate (projectilePref, transform.position, Quaternion.identity);
		tempObj.GetComponent<Rigidbody2D> ().AddForce (direction);
	}

}

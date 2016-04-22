using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	
	public float attackDelay = 1f;
	public float xForce = 1f;
	public float yForce = 1f;
	public GameObject projectilePref; //Set this in the inspecctor
	
	
	private GameObject tempObj;//We use this to reference the instantiated projectile
	// Use this for initialization
	void Start () {
		if (attackDelay > 0) 
		{
			StartCoroutine (OnAttack());
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	IEnumerator OnAttack()
	{
		
		//print ("FIRE");
		shootProjectile (new Vector2(xForce, yForce));
		yield return new WaitForSeconds(attackDelay);
		StartCoroutine (OnAttack ());
	}
	
	void shootProjectile(Vector2 direction)
	{
		//Debug.Log ("DERP");
		//		Debug.Log (gameObject.name);
		tempObj = (GameObject)Instantiate (projectilePref, transform.position, Quaternion.identity);
		tempObj.GetComponent<Rigidbody2D> ().AddForce (direction);
	}
	
}

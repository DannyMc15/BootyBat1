using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fireProjectile : AbstractBehavior {

	public float shootDelay = .5f;
	public GameObject projectilePrefab;
	public Vector2 firePosition = Vector2.zero;
	public Color debugColor = Color.yellow;
	public float debugRadius = 3f;

	private float timeElapsed = 0f;
	private GameManager doShoot;

	public GameObject shotsNumberRef;

	AudioSource source;
	public AudioClip spit;

	void Start(){
		doShoot = FindObjectOfType<GameManager> ();
		shotsNumberRef = GameObject.Find ("shotsNumber");
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (projectilePrefab != null &&doShoot.canShoot>0) {

			var canFire=inputState.GetButtonValue(inputButtons[0]);

			if(canFire && timeElapsed > shootDelay){
				CreateProjectile(CalculateFirePosition());
				timeElapsed = 0;
			}

			timeElapsed+=Time.deltaTime;
		}
	
	}

	Vector2 CalculateFirePosition(){
		var pos = firePosition;
		pos.x *= (float)inputState.direction;
		pos.x += transform.position.x;
		pos.y += transform.position.y;

		return pos;
	}

	public void CreateProjectile(Vector2 pos){
		var clone = Instantiate (projectilePrefab, pos, Quaternion.identity) as GameObject;
		source.PlayOneShot (spit);
		clone.transform.localScale = transform.localScale;
		doShoot.canShoot--;
		shotsNumberRef.GetComponent<Text> ().text = doShoot.canShoot.ToString ();
	}

	void OnDrawGizmos(){
		Gizmos.color = debugColor;

		var pos = firePosition;
		if (inputState != null) {
			pos.x *= (float)inputState.direction;
		}
		pos.x += transform.position.x;
		pos.y += transform.position.y;

		Gizmos.DrawWireSphere (pos, debugRadius);
	}

}

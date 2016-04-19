using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float seconds = 1.0f;

    public int health = 3; // Amount of health
    public int invincibleTimer = 500;

    public bool isInvulnerable = false;

    public string targetTag = "Enemy";
    public string targetTag2 = "FallingHazard";
    public string targetTag3 = "Projectile";
    
    void Update(){
    
    }
  

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == targetTag && isInvulnerable == false)
        {
            StartCoroutine(InvulnerableDelay());
            health--;
            invincibleTimer = 0;
            print("HIT!");
        }
        if (health == 0)
        {
            Application.LoadLevel(Application.loadedLevel); 
            print("DEAD!");
        }
        if (health == 0)
        {
            print("Health is zero");
        }
        if (target.gameObject.tag == targetTag)
        {
            print("Tag is registered");
        }

    }

    private IEnumerator InvulnerableDelay()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(seconds);
        isInvulnerable = false;
    }
}

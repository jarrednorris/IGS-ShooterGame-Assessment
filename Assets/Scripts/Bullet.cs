using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public int damage;
    public Rigidbody2D rb;
    public string damageTag; //Who do I damage?

    // Use this for initialization
    void Start()
    {
        rb.velocity = (transform.right * speed);
    }

    // Bullet Collisions
    void OnTriggerEnter2D(Collider2D whatHit) //initialise when 2 colliders collide
    {
        
        var bulletHit = whatHit.GetComponent<Health>(); //calls the health component of what the bullet hit
        if (whatHit.tag == damageTag && bulletHit != null) //if the tag of what was hit was equal to what it wants to hit
        {
            bulletHit.modifyHealth(-damage); //the objects health is modified if collision is with enemy
        }
        

        Destroy(gameObject); //object is deleted after aany collision
    }
}

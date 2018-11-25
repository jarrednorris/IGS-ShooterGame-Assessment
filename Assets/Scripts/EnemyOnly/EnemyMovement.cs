using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Rigidbody2D rb;
    public float moveSpeedX;
    public float moveSpeedY;
    public float moveMinX;
    public float moveMaxX;
    public float moveMinY;
    public float moveMaxY;
    public int collisionDamage;
    new

	void Awake ()  //on awake the enemy moves left at set speed
    {
        Vector3 enemyPosition = gameObject.transform.position;
        if (enemyPosition.y < 0)
            moveSpeedY = moveSpeedY * -1;
        if (enemyPosition.y == 0)
            moveSpeedY = 0;
        rb.velocity = new Vector2(moveSpeedX, moveSpeedY);
        rb.velocity.Normalize();
        moveMinY = gameObject.transform.position.y - 0.5f;

        moveMaxY = gameObject.transform.position.y + 0.5f;
        
    }

    private void LateUpdate()
    {
        Vector3 enemyPosition = gameObject.transform.position;

        if (enemyPosition.x < moveMinX)
            Destroy(gameObject);

        if (enemyPosition.y < moveMinY)
        {
            moveSpeedY = moveSpeedY * -1;
            rb.velocity = new Vector2(moveSpeedX, moveSpeedY);
            rb.velocity.Normalize();
        }
        if (enemyPosition.y > moveMaxY)
        {
            moveSpeedY = moveSpeedY * -1;
            rb.velocity = new Vector2(moveSpeedX, moveSpeedY);
            rb.velocity.Normalize();
        }
    }
    void OnCollisionEnter2D(Collision2D whatHit) //initialise when 2 colliders collide
    {
        Debug.Log("collider hits");
        if (whatHit.gameObject.tag == "Player") //if the tag of what was hit is the player
        {
            Debug.Log("if triggers");
            var collisionHit = whatHit.gameObject.GetComponent<Health>(); //calls the health component of what the bullet hit
            collisionHit.modifyHealth(-collisionDamage); //the objects health is modified if collision is with enemy
            Destroy(gameObject); //object is deleted after any collision
        }


        
    }
}

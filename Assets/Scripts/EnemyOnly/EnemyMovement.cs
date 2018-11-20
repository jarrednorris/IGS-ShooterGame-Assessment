using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Rigidbody2D rb;
    public float moveSpeed = 1;

	void Awake ()  //on awake the enemy moves left at set speed
    {
        rb.velocity = new Vector2(-moveSpeed, 0);

	}
	
}

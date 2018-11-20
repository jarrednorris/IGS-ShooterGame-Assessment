using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed;
    private Rigidbody2D playerRigBod;

    // Use this for initialization
    void Start()
    {

        playerRigBod = GetComponent<Rigidbody2D>();

    }

	private Vector2 moveInput;

	private void Update()
	{
		float playerMoveHorizontal = Input.GetAxis("Horizontal");
		float playerMoveVertical = Input.GetAxis("Vertical");

		moveInput.x = playerMoveHorizontal;
		moveInput.y = playerMoveVertical;

		moveInput.Normalize();
        moveInput.y = moveInput.y * 0.8f;

    }

	void FixedUpdate()
    {
		playerRigBod.velocity = moveInput * playerSpeed * Time.fixedDeltaTime;
    }
}

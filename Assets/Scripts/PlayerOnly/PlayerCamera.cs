using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCamera : MonoBehaviour {

    private GameObject playerSprite;

    void Awake()
    {
        playerSprite = GameObject.Find("PlayerSprite");
    }

    // Update is called once per frame
    void LateUpdate ()
    {
        if (playerSprite == null)
        {
            playerSprite = GameObject.Find("PlayerSprite(Clone)");
        }
		Vector3 x = playerSprite.transform.position;
		x.z = -10;
		x.y = 0;

		if (x.x < -34.18f)
		{
			x.x = -34.18f;
		}

		if (x.x > 34.18f)
		{
			x.x = 34.18f;
		}
        
		transform.position = x;

	}

}

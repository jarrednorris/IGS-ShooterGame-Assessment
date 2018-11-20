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

        //clamps camera at ends of screen
		if (x.x < -33.784f)
		{
			x.x = -33.784f;
		}

		if (x.x > 33.784f)
		{
			x.x = 33.784f;
		}
        
		transform.position = x;

	}

}

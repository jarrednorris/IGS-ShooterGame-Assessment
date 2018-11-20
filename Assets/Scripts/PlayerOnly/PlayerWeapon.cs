using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    bool playerShootReady = true;
    public float shootWait = 1;


    // Use this for initialization
    void Start ()
    {
       
    }

	// Update is called once per frame
	void Update()
	{
        if (playerShootReady == true)
        {
            if (Input.GetButton("Fire1"))
            {
                StartCoroutine(pullTrigger());

            }
        }
	}

    public IEnumerator pullTrigger()
    {
        Shoot();
        playerShootReady = false;
        yield return new WaitForSeconds(shootWait);
        playerShootReady = true;
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
    }
    

    


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour {

    
    public GameObject pickupLife;
    public GameObject pickupHeal;
    public GameObject pickupSpeed;
    public GameObject pickupDamage;
    public GameObject pickupFireRate;
    System.Random rnd = new System.Random();


    // Update is called once per frame
    void Update ()
    {
        int childCount = transform.childCount;
		if (childCount < 1)
        {
            Debug.Log("childCount less then 1");
            SpawnPickups();
        }
	}

    public void SpawnPickups()
    {
        int chancePickup = rnd.Next(1, 10);
        if (chancePickup >= 8)
        {
            Debug.Log("pickup should spawn");
            int whichPickup = rnd.Next(1, 5);
            Debug.Log(whichPickup);
            if (whichPickup == 1)
            {
                Instantiate(pickupLife, gameObject.transform.position, gameObject.transform.rotation);
            }
            if (whichPickup == 2)
            {
                Instantiate(pickupHeal, gameObject.transform.position, gameObject.transform.rotation);
            }
            if (whichPickup == 3)
            {
                Instantiate(pickupSpeed, gameObject.transform.position, gameObject.transform.rotation);
            }
            if (whichPickup == 4)
            {
                Instantiate(pickupDamage, gameObject.transform.position, gameObject.transform.rotation);
            }
            if (whichPickup == 5)
            {
                Instantiate(pickupFireRate, gameObject.transform.position, gameObject.transform.rotation);
            }
            else
                Debug.Log("couldn't pick a pickup");
        }

        Destroy(gameObject);
    }
}

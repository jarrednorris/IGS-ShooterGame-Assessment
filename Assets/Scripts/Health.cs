using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int healthMax;
    public int healthCurrent;
    public GameObject playerSprite;
    public int scoreGain;
    public GameObject pickupLife;
    public GameObject pickupHeal;
    public GameObject pickupSpeed;
    public GameObject pickupDamage;
    public GameObject pickupFireRate;
    System.Random rnd = new System.Random();



    public UnityEvent onDie;

    void Awake()
    {
        healthCurrent = healthMax;
        playerSprite = GameObject.Find("PlayerSprite");
        if (playerSprite == null)
        {
            playerSprite = GameObject.Find("PlayerSprite(Clone)");
        }
        if (gameObject.name == "EnemyA(Clone)" || gameObject.name == "EnemyA")
        {
            scoreGain = 2;
        }
        if (gameObject.name == "EnemyB(Clone)" || gameObject.name == "EnemyB")
        {
            scoreGain = 10;
        }

    }

    public void modifyHealth(int damage)
    {
        healthCurrent = (int)Mathf.Clamp(healthCurrent + damage, 0, healthMax);
        if (healthCurrent == 0)        
            onDie.Invoke();
    }

    public void Die()
    {
        if (gameObject.name != "PlayerSprite(Clone)" && gameObject.name != "PlayerSprite")
        {
            
            var scoreScript = playerSprite.GetComponent<PlayerScore>();
            scoreScript.Score(scoreGain);
            if (gameObject.name == "EnemyC" || gameObject.name == "EnemyD")
                SpawnPickups();
        }

        Destroy(gameObject);
    }

    public void SpawnPickups()
    {
        int chancePickup = rnd.Next(1, 10);
        if (chancePickup >= 8)
        {
            int whichPickup = rnd.Next(1, 5);
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
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickups : MonoBehaviour {

    public GameObject playerSprite;
    public GameObject playerBullet;
    public int speedBoost;
    public int damageBoost;
    public float fireRateBoost;
    bool activeThree = false;
    bool activeFour = false;
    bool activeFive = false;

    // Use this for initialization
    void OnTriggerEnter2D(Collider2D whatHit) //initialise when 2 colliders collide
    {
        Debug.Log("collider hits");
        if (whatHit.gameObject.tag == "Player") //if the tag of what was hit is the player
        {
            Debug.Log("if triggers");
            playerSprite = GameObject.Find("PlayerSprite");
            if (playerSprite == null)
                playerSprite = GameObject.Find("PlayerSprite(Clone)");

            if (gameObject.name == "pickupLife")
            {
                var PlayerLives = playerSprite.GetComponent<LifeManager>();
                PlayerLives.numLives = PlayerLives.numLives + 1;
            }
            if (gameObject.name == "pickupHealth")
            {
                var PlayerHealth = playerSprite.GetComponent<Health>();
                PlayerHealth.healthCurrent = PlayerHealth.healthMax;
            }
            if (gameObject.name == "pickupSpeed" && activeThree == false)
            {
                activeThree = true;
                StartCoroutine(speed());

            }
            if (gameObject.name == "pickupDamage" && activeFour == false)
            {
                activeFour = true;
                StartCoroutine(damage());
            }
            if (gameObject.name == "pickupFireRate" && activeFive == false)
            {
                activeFive = true;
                StartCoroutine(fireRate());
            }
            Destroy(gameObject); //object is deleted after any collision
        }
    }


    public IEnumerator speed()
    {
        
        var PlayerSpeed = playerSprite.GetComponent<PlayerMovement>();
        PlayerSpeed.playerSpeed = PlayerSpeed.playerSpeed + speedBoost;
        yield return new WaitForSeconds(10);
        PlayerSpeed.playerSpeed = PlayerSpeed.playerSpeed - speedBoost;
        activeThree = false;
    }

    public IEnumerator damage()
    {
        
        var PlayerDamage = playerBullet.GetComponent<Bullet>();
        PlayerDamage.damage = PlayerDamage.damage + damageBoost;
        yield return new WaitForSeconds(10);
        PlayerDamage.damage = PlayerDamage.damage - damageBoost;
        activeFour = false;
    }

    public IEnumerator fireRate()
    {
        var PlayerFireRate = playerSprite.GetComponent<PlayerWeapon>();
        PlayerFireRate.shootWait = PlayerFireRate.shootWait - fireRateBoost;
        yield return new WaitForSeconds(10);
        PlayerFireRate.shootWait = PlayerFireRate.shootWait + fireRateBoost;
        activeFive = false;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickups : MonoBehaviour {

    public GameObject PlayerSprite;
    public GameObject PlayerBullet;
    public int speedBoost;
    public int damageBoost;
    public float fireRateBoost;
    bool activeThree = false;
    bool activeFour = false;
    bool activeFive = false;
    // Use this for initialization
    void Awake () {
		if (gameObject.name == "pickupLife")
        {
            var PlayerLives = PlayerSprite.GetComponent<LifeManager>();
            PlayerLives.numLives = PlayerLives.numLives + 1;
        }
        if (gameObject.name == "pickupHealth")
        {
            var PlayerHealth = PlayerSprite.GetComponent<Health>();
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

        

        


    }


    public IEnumerator speed()
    {
        yield return new WaitForSeconds(10);
        var PlayerSpeed = PlayerSprite.GetComponent<PlayerMovement>();
        PlayerSpeed.playerSpeed = PlayerSpeed.playerSpeed - speedBoost;
        activeThree = false;
    }

    public IEnumerator damage()
    {
        yield return new WaitForSeconds(10);
        var PlayerDamage = PlayerBullet.GetComponent<Bullet>();
        PlayerDamage.damage = PlayerDamage.damage - damageBoost;
        activeFour = false;
    }

    public IEnumerator fireRate()
    {
        yield return new WaitForSeconds(10);
        var PlayerFireRate = PlayerSprite.GetComponent<PlayerWeapon>();
        PlayerFireRate.shootWait = PlayerFireRate.shootWait + fireRateBoost;
        activeFive = false;
    }
}

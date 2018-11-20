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
        }
        Destroy(gameObject);
    }
}
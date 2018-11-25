using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class LifeManager : MonoBehaviour
{
    private GameObject currentPlayerObject; //name of current playersprite
    public GameObject playerPrefab; //name of playersprite prefab
    public Transform spawnPoint; //where the player spawns
    public int numLives, maxLives = 3;
    public UnityEvent onLivesZero; //event called when player loses all lives
    public TextMeshProUGUI livesText;

    private void Awake()
    {
        numLives = maxLives;
        livesText.text = "Lives: " + numLives.ToString();
        SpawnPlayer();
        currentPlayerObject = GameObject.Find("PlayerSprite");
        currentPlayerObject.GetComponent<Health>().onDie.AddListener(OnPlayerDie); //call event onplayerdie after event ondie has been called
    }

    public void ModifyLives(int amount)
    {
        numLives = (int)Mathf.Clamp(numLives + amount, 0, maxLives); //reduces lives and clamps values
        livesText.text = "Lives: " + numLives.ToString();
        Debug.Log("numLives decreased!");
        if (numLives == 0)
        {
            onLivesZero.Invoke(); //on no lives call the event
        }
    }

    public void SpawnPlayer()
    {
        currentPlayerObject = GameObject.Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        currentPlayerObject.GetComponent<Health>().onDie.AddListener(OnPlayerDie);
    }

    public void OnPlayerDie()
    {
        ModifyLives(-1);
        Debug.Log("I just died!");
        StartCoroutine(WaitForTime(5));
    }

   

    public IEnumerator WaitForTime(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        SpawnPlayer();
    }
}

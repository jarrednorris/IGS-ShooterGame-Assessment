using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeManager : MonoBehaviour
{
    private GameObject currentPlayerObject;
    public GameObject playerPrefab;
    public Transform spawnPoint;
    public int numLives, maxLives = 3;
    public UnityEvent onLivesZero;

    private void Awake()
    {
        numLives = maxLives;
        currentPlayerObject = GameObject.Find("PlayerSprite");
    }

    public void ModifyLives(int amount)
    {
        numLives = (int)Mathf.Clamp(numLives + amount, 0, maxLives);
        if (numLives == 0)
        {
            onLivesZero.Invoke();
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

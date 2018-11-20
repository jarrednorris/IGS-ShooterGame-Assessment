using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
    bool enemyShootReady = true;
    public float shootWait = 1; //enemy shot speed

    // Update is called once per frame
    void Update()
    {
        if (enemyShootReady == true)
        {
            StartCoroutine(pullTrigger());
        }
    }

    public IEnumerator pullTrigger()
    {
        Shoot();
        enemyShootReady = false;
        yield return new WaitForSeconds(shootWait);
        enemyShootReady = true;
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

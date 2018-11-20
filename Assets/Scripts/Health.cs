using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int healthMax;
    public int healthCurrent;

    public UnityEvent onDie;

    void Awake()
    {
        healthCurrent = healthMax;
    }

    public void modifyHealth(int damage)
    {
        healthCurrent = (int)Mathf.Clamp(healthCurrent + damage, 0, healthMax);
        if (healthCurrent == 0)        
            onDie.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
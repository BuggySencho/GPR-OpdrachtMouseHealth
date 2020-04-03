using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100;

    public event Action<float, float, int, int> onDamage;

    public void Damage(int i)
    {
        if (health <= 0)
        {
            return;
        }
        health -= i;
        onDamage(1, 0.1f, health, maxHealth);
        if (health <= 0)
        {
            Debug.Log("Big OOF");
        }
    }
}

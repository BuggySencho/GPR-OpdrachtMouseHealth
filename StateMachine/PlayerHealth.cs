using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private int maxHealth = 3;

    public event Action<int, int> onDamage;

    private bool invincible = false;

    public void Damage(int i)
    {
        if (invincible)
        {
            return;
        }

        StartCoroutine(Invincibility());
        if (health <= 0)
        {
            return;
        }
        health -= i;
        onDamage(health, maxHealth);
        if (health <= 0)
        {
            Application.Quit();
        }
    }

    private IEnumerator Invincibility()
    {
        invincible = true;

        for (int i = 0; i < 5; i++)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }        

        invincible = false;
    }
}

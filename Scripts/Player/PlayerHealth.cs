using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100;

    private PlayerHealthUI playerHealthUI;

    public event Action<float, float> onDamage;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthUI = GetComponent<PlayerHealthUI>();
        onDamage += Camera.main.GetComponent<CameraListener>().CallShake;
    }

    public void Damage(int i)
    {
        if (health <= 0)
        {
            return;
        }
        health -= i;
        playerHealthUI.UpdateHealth(health, maxHealth);
        onDamage(1, 0.1f);
        if (health <= 0)
        {
            Debug.Log("Big OOF");
        }
    }
}

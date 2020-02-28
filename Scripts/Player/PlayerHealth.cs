using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100;

    private PlayerHealthUI playerHealthUI;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthUI = GetComponent<PlayerHealthUI>();
    }

    public void Damage(int i)
    {
        if (health <= 0)
        {
            return;
        }
        health -= i;
        playerHealthUI.UpdateHealth(health, maxHealth);
        if (health <= 0)
        {
            Debug.Log("Big OOF");
        }
    }
}

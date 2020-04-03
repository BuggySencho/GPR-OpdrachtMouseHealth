using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraListener : MonoBehaviour
{
    private CameraShake shake;
    private PlayerHealth playerHealth;
    private PlayerHealthUI playerHealthUI;

    private void Start()
    {
        shake = GetComponent<CameraShake>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerHealthUI = playerHealth.GetComponent<PlayerHealthUI>();
        playerHealth.onDamage += CallShake;
    }

    public void CallShake(float duration, float magnitude, int health, int maxHealth)
    {
        shake.ShakeCoroutine(duration, magnitude);
        playerHealthUI.UpdateHealth(health, maxHealth);
    }
}

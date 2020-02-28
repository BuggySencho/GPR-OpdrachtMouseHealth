using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100;

    private Text healthText;
    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        healthText = canvas.transform.GetChild(0).GetComponent<Text>();
        healthBar = canvas.transform.GetChild(2).GetComponent<Image>();
    }

    private void UpdateHealth()
    {
        healthText.text = health.ToString();
        healthBar.fillAmount = (float)health / (float)maxHealth;
    }

    public void Damage(int i)
    {
        if (health <= 0)
        {
            return;
        }
        health -= i;
        UpdateHealth();
        if (health <= 0)
        {
            Debug.Log("Big OOF");
        }
    }
}

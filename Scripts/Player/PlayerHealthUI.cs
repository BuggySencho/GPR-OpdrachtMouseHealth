using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    private Text healthText;
    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        healthText = canvas.transform.GetChild(0).GetComponent<Text>();
        healthBar = canvas.transform.GetChild(2).GetComponent<Image>();
    }

    public void UpdateHealth(int health, int maxHealth)
    {
        healthText.text = health.ToString();
        healthBar.fillAmount = (float)health / (float)maxHealth;
    }
}

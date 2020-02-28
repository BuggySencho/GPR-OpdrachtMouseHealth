using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnPlayer : MonoBehaviour
{
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnMouseDown()
    {
        playerHealth.Damage(10);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogChangeCounter : MonoBehaviour
{
    private int counter = 0;
    private DialogCounterUI dialogCounterUI;

    private void Start()
    {
        dialogCounterUI = GetComponent<DialogCounterUI>();  
    }

    public void CounterUpdate()
    {
        counter++;
        dialogCounterUI.ChangeCounterText(counter);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogCounterUI : MonoBehaviour
{
    [SerializeField] private Text text;

    public void ChangeCounterText(int i)
    {
        text.text = i.ToString();
    }
}

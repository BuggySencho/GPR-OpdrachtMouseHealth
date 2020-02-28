using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogMenu : MonoBehaviour
{

    [SerializeField]
    private Text _textField;
    
    void Awake()
    {
        var dialogSystem = GetComponent<DialogSystem>();
        dialogSystem.DialogChanged += OnDialogChanged;
        dialogSystem.DialogsCompleted += OnDialogsCompleted;
    }

    private void OnDialogChanged(string newDialog)
    {
        _textField.text = newDialog;
    }

    private void OnDialogsCompleted()
    {
        _textField.text = "";
        Debug.Log("check, we zijn klaar met de dialogs. We zouden nu bijvoorbeeld de UI weg kunnen halen (als je dat zou willen in je game)");
    }
}
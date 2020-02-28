using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSetup : MonoBehaviour
{

    void Start()
    {
        var dialogSystem = GetComponent<DialogSystem>();

        dialogSystem.AddDialog("Goedemorgen GD2");
        dialogSystem.AddDialog("Hoe gaat het met jullie?");
        dialogSystem.AddDialog("Al een beetje wakker?");
        dialogSystem.AddDialog("Dit is een voorbeeld van hoe delegates werken");
        dialogSystem.AddDialog("Sta er goed bij stil welke classes elkaar nu kennen");
        dialogSystem.AddDialog("En nog belangrijker: wie kent alleen zichzelf? :)");
        dialogSystem.AddDialog("Succes met het verwerken van delegates in je eigen opdracht");
        dialogSystem.AddDialog("En hopelijk zien we het ook terug in je Input/output");
        
        dialogSystem.Play();
    }

    
}

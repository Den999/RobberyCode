using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameDoor : Interactable
{
    protected override void OnAction()
    {
        Application.Quit();
    }
}

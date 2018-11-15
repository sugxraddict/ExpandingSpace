using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameButton : MonoBehaviour
{
    public void Click()
    {
        EventManager.StartGame();
    }

    public void Instructions()
    {
        EventManager.InstructionsGame();
    }

    public void Quit()
    {
        EventManager.QuitGame();
    }


    public void Back()
    {
        EventManager.BackGame();
    }

    public void Next()
    {
        EventManager.NextGame();
    }

    public void Previous()
    {
        EventManager.PreviousGame();
    }
}

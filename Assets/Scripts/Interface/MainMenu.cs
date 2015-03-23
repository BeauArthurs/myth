using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
    public void Play()
    {
        Application.LoadLevel("Game");
    }
    public void Tutorial()
    {
        Application.LoadLevel("Tutorial");
    }
}

using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
    [SerializeField]
    private GameObject load;
    public void Play()
    {
        load.SetActive(true);
        Application.LoadLevel("Game");
    }
    public void Tutorial()
    {
        load.SetActive(true);
        Application.LoadLevel("Tutorial");
    }
}

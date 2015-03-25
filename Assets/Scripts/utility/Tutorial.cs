using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private Text TXT;
    [SerializeField]
    private int TutorialNumber;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        switch (TutorialNumber)
        {

            case 1:
                TXT.text = "Hello and welcome to the tutorial level of the game Mystery Deep.";
                break;
            case 2:
                TXT.text = "Use your right stick to turn on your lightning.";
                break;
            case 3:
                TXT.text = "Collect artifects to get money.";
                break;
            case 4:
                TXT.text = "Look Under you is a mine, be carefull becouse it wil explote on to you!";
                break;
            case 5:
                TXT.text = "O NO, You just got hurt Press the shop to heal up agen!";
                break;
            case 6:
                TXT.text = "You can also buy upgrades in the to shop.";
                break;
            case 7:
                TXT.text = "You are now ready to play our game";
                Application.LoadLevel("Menu");
                break;
            default:
                print("nothin");
                break;
        }
    }
}
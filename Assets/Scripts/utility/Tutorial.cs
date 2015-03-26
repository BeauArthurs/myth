using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour
{

    private PlayerOperator _operatorController;
    [SerializeField]
    private Text TXT;
    [SerializeField]
    private int TutorialNumber;
    private float timeLastSubtracted;
    // Use this for initialization
    void Start()
    {

        _operatorController = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<PlayerOperator>();
    }


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        switch (TutorialNumber)
        {

            case 1:
                TXT.text = "Welcome to the tutorial level of 'Mystery Deep'. We wish you a good time in the game.";
                break;
            case 2:
                TXT.text = "As first: Use your right stick to turn on your light. Try it out!";
                break;
            case 3:
                TXT.text = "Do you see the treasure underneath the pool? Try to grab them by diving onto it.";
                break;
            case 4:
                TXT.text = "Be careful, there is a mine ahead.";
                break;
            case 5:
                TXT.text = "Alright, you've made it. Good job. You can restock here in this area. Press on the shop button to restock.";
                break;
            case 6:
                TXT.text = "Don't forget: You can't stay underwater for too long. You can upgrade your submarine if you have enough of gold. It will help you.";
                break;
            case 7:
                TXT.text = "Alright. You're ready for the challenge. Get out of your submarine and we'll bring you to the...";
                if (Time.time >= timeLastSubtracted + 3)
                {
                    Application.LoadLevel("Menu");
                }
                break;
            default:
                print("nothin");
                break;
        }
    }
}
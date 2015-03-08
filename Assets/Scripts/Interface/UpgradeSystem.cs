using UnityEngine;
using System.Collections;

public class UpgradeSystem : MonoBehaviour {
    private PlayerOperator _operatorController;
    public int buttons;
	// Use this for initialization
	void Start ()
    {
    _operatorController = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerOperator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled && GameObject.FindGameObjectWithTag("button") == true)
            {
                if (buttons == 1)
                {
                    _operatorController.AddHealth(10);
                    Debug.Log("10");
                }

                else if (buttons == 2)
                {
                    _operatorController.AddAir(10);
                }
            }
        }
  	}
}
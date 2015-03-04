using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {
    private PlayerOperator _operatorController;
    public int typePickUp;
	// Use this for initialization
	void Start () {
        _operatorController = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerOperator>();
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                if (typePickUp == 1)
                {
                    _operatorController.AddMoney(10);
                    Debug.Log("add money 10");
                }
            }
        }
	}
}

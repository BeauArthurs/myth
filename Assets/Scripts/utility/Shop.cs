using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour 
{

    [SerializeField]
    public int itemNumber;

    private GameObject _player;
    private PlayerOperator _operatorController;
	// Use this for initialization
	void Start () 
    {
    _player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
    _operatorController = _player.GetComponent<PlayerOperator>();
    }
	
	// Update is called once per frame
	void Update () {

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            { 
              switch (itemNumber)
              {
                    case 5:
                        print("heal");
                        _operatorController.ChangeHealth(9);
                        break;
                    case 4:
                        print("upgrade health");
                        _operatorController.ChangeHealth(_operatorController.GetHealth() + 1);
                        break;
                    case 3:
                        print("upgrade air thin tank");
                        _operatorController.ChangePressureResistance(_operatorController.GetPressure() + 1);
                        break;
                    case 2:
                        print("upgrade boost");
                        _operatorController.boostSpeed = _operatorController.boostSpeed + 5; 
                        break;
                    case 1:
                        print("presure");
                        break;
                    default:
                        print("nothin");
                        break;
               }
            }
        }
    }
}

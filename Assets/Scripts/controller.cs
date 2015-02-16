using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
    
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Transform stick;
    [SerializeField]
    private Transform stickBase;
    private int _fingerOnStick;
	void Start () 
    {
        _fingerOnStick = 20;
	}
	
	void Update () 
    {
        //checking for any touch input
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 13));
            //if touch input is connected to joystick
            if (i == _fingerOnStick)
            {
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    _player.GetComponent<PlayerController>().Move(MoveStick(position).normalized);
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    _fingerOnStick = 20;
                    stick.localPosition = Vector3.zero;
                }
            }
            else
            {  
                RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
                if (hit != null && hit.collider != null)
                {
                    if (hit.collider.name == "JoyStick")
                    {
                        if (touch.phase == TouchPhase.Began)
                        {
                            _fingerOnStick = i;
                        }
                    }
                    else
                    {
                        Debug.Log(hit.collider.name);
                    }
                }
            }
        }
        //mouse input for non mobile testing
        if(Input.GetMouseButton(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 13));
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
            if (hit != null && hit.collider != null)
            {
                _player.GetComponent<PlayerController>().Move(MoveStick(position));
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            stick.localPosition = Vector3.zero;
        }
	}
    public Vector3 MoveStick(Vector3 pos)
    {

        stick.position = pos;
        Vector3 joystick = pos - stickBase.position;
        return new Vector3(joystick.x, joystick.y, 0).normalized;
    }
}

using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
    private int fingerOnStick;
    [SerializeField]
    private GameObject joyStick;
    public Vector3 JoyStickOutput;
	void Start () 
    {
        fingerOnStick = 20;
	}
	
	void Update () 
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 30));
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
            if(i == fingerOnStick)
            {
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    JoyStickOutput = joyStick.GetComponent<JoyStick>().Move(position);
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    fingerOnStick = 20;
                    JoyStickOutput = Vector3.zero;
                    joyStick.GetComponent<JoyStick>().Stop();
                }
            }
            if (hit != null && hit.collider != null)
            {
                if (hit.collider.name == "JoyStick")
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        fingerOnStick = i;
                    } 
                }
                else
                {
                    Debug.Log(hit.collider.name);
                }
            }
        }
	}
}

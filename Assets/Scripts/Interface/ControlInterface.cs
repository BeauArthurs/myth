using UnityEngine;
using System.Collections;

public class ControlInterface : MonoBehaviour {

    private int _StickOne;
    private int _StickTwo;
    [SerializeField]
    private GameObject[] sticks;
    [SerializeField]
    private PlayerOperator player;
	void Update () 
    {
        int fingers = Input.touchCount;
        for (int i = 0; i < fingers; i++)
        {
            Touch touch = Input.touches[i];
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0 - Camera.main.transform.position.z));
            if(i == _StickOne-1)
            {
                if(touch.phase == TouchPhase.Moved)
                {
                    player.SetDirection(sticks[0].GetComponent<JoyStick>().GetDirection(position).normalized);
                }
                if(touch.phase == TouchPhase.Ended)
                {
                    sticks[0].GetComponent<JoyStick>().LetGo();
                    player.SetDirection(Vector3.zero);
                    _StickOne = 0;
                }
            }
            else  if(i == _StickTwo-1)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    player.SetLightDir(true, sticks[1].GetComponent<JoyStick>().GetAngel(position));
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    player.SetLightDir(false, 0);
                    sticks[1].GetComponent<JoyStick>().LetGo();
                }
            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.name == (Tags.MOVEMENTSTICK))
                    {
                        _StickOne = i + 1;
                    }
                    else if (hit.collider.name == (Tags.LIGHTSTICK))
                    {
                        _StickTwo = i + 1;
                    }
                    else if(hit.collider.name == (Tags.BOOST))
                    {
                        player.boost();
                    }
                }
            }
        }
        //for testing on pc
        if(Input.GetMouseButton(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0 - Camera.main.transform.position.z));
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.name == (Tags.MOVEMENTSTICK))
                {
                    player.SetDirection(sticks[0].GetComponent<JoyStick>().GetDirection(position).normalized);
                }
                else if (hit.collider.name == (Tags.MOVEMENTSTICK))
                {
                    player.SetLightDir(true ,sticks[1].GetComponent<JoyStick>().GetAngel(position));
                }
                else if (hit.collider.name == (Tags.BOOST))
                {
                    player.boost();
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0 - Camera.main.transform.position.z));
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
            if (hit.collider.name == (Tags.MOVEMENTSTICK))
            {
                sticks[0].GetComponent<JoyStick>().LetGo();
                player.SetDirection(Vector3.zero);
            }
            else if (hit.collider.name == (Tags.LIGHTSTICK))
            {
                player.SetLightDir(false, 0);
                sticks[1].GetComponent<JoyStick>().LetGo();
            }
        }
	}
}

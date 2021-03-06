﻿using UnityEngine;
using System.Collections;

public class ControlInterface : MonoBehaviour {

    private int _StickOne;
    private int _StickTwo;
    [SerializeField]
    private GameObject[] sticks;
    [SerializeField]
    private GameObject boost;
    [SerializeField]
    private PlayerOperator player;
	void Update () 
    {
        int fingers = Input.touchCount;
        for (int i = 0; i < fingers; i++)
        {
            Debug.Log("totch");
            Touch touch = Input.touches[i];
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 8));
            if(i == _StickOne-1)
            {
                Debug.Log("move 1");
                if(touch.phase == TouchPhase.Moved)
                {
                    player.SetDirection(sticks[0].GetComponent<JoyStick>().Move(position));
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
                Debug.Log("move 1");
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector3 dif = sticks[1].GetComponent<JoyStick>().Move(position);
                    float angel = Mathf.Atan2(-dif.y, dif.x) * (180 / Mathf.PI);
                    player.SetLightDir(true, angel);

                }
                if (touch.phase == TouchPhase.Ended)
                {
                    player.SetLightDir(false, 0);
                    sticks[1].GetComponent<JoyStick>().LetGo();
                    _StickTwo = 0;
                }
            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.name == (Tags.MOVEMENTSTICK))
                    {
                        Debug.Log("Start 1");
                        _StickOne = i + 1;
                    }
                    else if (hit.collider.name == (Tags.LIGHTSTICK))
                    {
                        Debug.Log("Start 2");
                        _StickTwo = i + 1;
                    }
                }
            }
        }
        //for testing on pc
        if(Input.GetMouseButton(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 8));
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.name == (Tags.MOVEMENTSTICK))
                {
                    player.SetDirection(sticks[0].GetComponent<JoyStick>().Move(position));
                }
                else if (hit.collider.name == (Tags.LIGHTSTICK))
                {
                    Vector3 dif = sticks[1].GetComponent<JoyStick>().Move(position);
                    float angel = Mathf.Atan2(-dif.y,dif.x) *(180/Mathf.PI);
                    player.SetLightDir(true ,angel);
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 8));
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
			if (hit.collider != null)
			{
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
}

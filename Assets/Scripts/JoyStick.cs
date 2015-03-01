using UnityEngine;
using System.Collections;

public class JoyStick : MonoBehaviour 
{
    private Transform stick;
    private Transform stickBase;
	void Start () 
    {
        stick = transform.Find("Stick");
        stickBase = transform.Find("Base");
	}
    public Vector3 MoveStick(Vector3 pos)
    {
        stick.position = pos;
        Vector3 joystick = pos - stickBase.position;
        return new Vector3(joystick.x, joystick.y, 0);
    }
	public void LetGo()
    {
        stick.localPosition = Vector3.zero;
    }
}
using UnityEngine;
using System.Collections;

public class JoyStick : MonoBehaviour {
    [SerializeField]
    private Transform stick;
    [SerializeField]
    private Transform stickBase;
	void Start () 
    {	
	}
	
    public Vector3 Move(Vector3 pos)
    {
        
        stick.position = pos;
        Vector3 joystick = pos - stickBase.position;
        return new Vector3(joystick.x,joystick.y,0).normalized;
    }
    public void Stop()
    {
        stick.localPosition = Vector3.zero;
    }
}

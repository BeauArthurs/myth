using UnityEngine;
using System.Collections;

public class JoyStick : MonoBehaviour 
{
    [SerializeField]
    private Transform stick;
    [SerializeField]
    private Transform stickBase;
    protected Vector3 Difference;
    
    public Vector3 Move(Vector3 pos)
    {
        stick.position = pos;
        Difference = stickBase.position - stick.position;
        return Difference;
    }
	public void LetGo()
    {
        stick.localPosition = Vector3.zero;
    }
}
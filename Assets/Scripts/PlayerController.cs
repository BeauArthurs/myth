using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private int speed;
    private int pressure;
    private int resistance;
    [SerializeField]
    private float air;
    private int health;
	void Start () 
    {
        health = 100;
        resistance = -50;
        air = 100;
	}
	void Update ()
    {
        pressure = Mathf.FloorToInt(transform.position.y) - resistance;
        if(pressure < 0 )
        {
            Debug.Log("you are to low");
        }
        air -= 1 * Time.deltaTime;
    }
    public void Move(Vector3 direction)
    {
        transform.position = transform.position + (direction * speed * Time.deltaTime);
    }
}

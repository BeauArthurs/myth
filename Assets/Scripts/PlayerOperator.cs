using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerOperator : MonoBehaviour 
{
    private bool underWater;
    private Vector3 speed;
    private int totalHaealth;
    private int health;
    private int totalPower;
    private float power;
    private int pressure;
    private int pressureResistance;
    private int money;
    private void Start()
    {
        health = 100;
        totalPower = 100;
        power = 100;
        pressureResistance = 500;
        pressure = Mathf.FloorToInt(transform.position.y) + pressureResistance;
    }
	private void Update ()
    {
        power -= 1 * Time.deltaTime;
        if(speed != Vector3.zero)
        {
            rigidbody.AddForce(1 * speed * Time.deltaTime *200 );
            if(speed.x > .1f)
            {
                transform.rotation = new Quaternion(0, 180,0,0);
            }
            else if(speed.x < -.1)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            pressure = Mathf.FloorToInt(transform.position.y) + pressureResistance;   
        }
        if(health <= 0)
        {
            Destroy(this);
        }
    }
    public int GetTotalHealth()
    {
        return totalHaealth;
    }
    public int GetHealth()
    {
        return health;
    }
    public int GetTotalPower()
    {
        return totalPower;
    }
    public float GetPower()
    {
        return power;
    }
    public int GetPressure()
    {
        return pressure;
    }
    public int GetPressureResistance()
    {
        return pressureResistance;
    }
    public int GetMoney()
    {
        return money;
    }
    public void AddHealth(int amount)
    {
        health += amount;
    }
    public void AddPower(int amount)
    {
        power += amount;
    }
    public void AddPressureResistance(int amount)
    {
        pressureResistance += amount;
    }
    public void AddMoney(int amount)
    {
        money += amount;
    }
    public void SetTotalHealth(int amount)
    {
        totalHaealth = amount;
    }
    public void SetTotalPower(int amount)
    {
        totalPower = amount;
    }
    public void SetSpeed(Vector3 input)
    {
        speed = input;
    }
    public void SetLightDir(Vector3 dir)
    {

    }
}
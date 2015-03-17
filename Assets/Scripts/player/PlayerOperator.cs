using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerOperator : MonoBehaviour 
{
    [SerializeField]
    private Transform sub;
    [SerializeField]
    private Transform flashLight;
    [SerializeField]
    private UiScript ui;
    private float speed = 400;
    private Vector3 direction;
    private int totalHealth;
    private int health;
    private int totalAir;
    private int air;
    private int pressure;
    private int pressureResistance;
    private int money;
    private float degree;
    private bool UnderWater;
    private float timeLastSubtracted;
    private void Start()
    {
        health = 9;
        totalAir = 9;
        air = 9;
        pressureResistance = 0;
        pressure = Mathf.FloorToInt(transform.position.y) + pressureResistance;
    }
    private void Update()
    {
        pressure = Mathf.FloorToInt(pressureResistance - transform.position.y);
        ui.SetDepth(-pressure);
        if (UnderWater == true)
        {
            if (Time.time >= timeLastSubtracted + 3 && air > 0)
            {
                ChangeAir(-1);
                timeLastSubtracted = Time.time;
            }
        }
        else
        {
            if (Time.time >= timeLastSubtracted + .1 && air < 9 )
            {
                ChangeAir(1);
                timeLastSubtracted = Time.time;
            }
        }
        if(air == 0)
        {

        }
    }
	private void FixedUpdate ()
    {
        if(direction != Vector3.zero)
        {
            GetComponent<Rigidbody>().AddForce(1 * direction * Time.deltaTime *speed );
            
            pressure = Mathf.FloorToInt(transform.position.y) + pressureResistance;
            
            if(direction.x < 0)
            {
                degree = 0;
            }
            else if(direction.x > 0)
            {
                degree = 180;
            }
            
        }
        transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, degree, 0), 1f * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == Tags.WALL)
        {
            ChangeHealth(-1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == (Tags.AIR))
        {
            UnderWater = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == (Tags.AIR))
        {
            UnderWater = true;
        }
    }
    //Health
    public void ChangeHealth(int amount)
    {
        health += amount;
        ui.SetHealth(health);
    }
    public void SetTotalHealth(int amount)
    {
        totalHealth = amount;
    }
    public int GetTotalHealth()
    {
        return totalHealth;
    }
    public float GetHealth()
    {
        return health;
    }

    //Air
    public int GetTotalAir()
    {
        return totalAir;
    }
    public float GetAir()
    {
        return air;
    }
    public void ChangeAir(int amount)
    {
        air += amount;
        ui.SetAir(air);
    }
    public void SetTotalAir(int amount)
    {
        totalAir = amount;
    }
    //Pressure 
    public int GetPressure()
    {
        return pressure;
    }
    public int GetPressureResistance()
    {
        return pressureResistance;
    }
    public void ChangePressureResistance(int amount)
    {
        pressureResistance += amount;
    }
    //money
    public int GetMoney()
    {
        return money;
    }
    public void ChangeMoney(int amount)
    {
        money += amount;
    } 
    //
    public void SetDirection(Vector3 input)
    {
        direction = input;
    }
    public void SetLightDir(bool on,float angel)
    {
        flashLight.gameObject.SetActive(on);
        flashLight.eulerAngles = new Vector3(0, 0, angel);
    }
    public void Boost()
    {
        GetComponent<Rigidbody>().AddForce(1 * direction * Time.deltaTime * speed * 35);
    }
}
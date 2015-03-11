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
    private float health;
    private int totalAir;
    private float air;
    private int pressure;
    private int pressureResistance;
    private int money;
    private float degree;
    private bool UnderWater;
    private void Start()
    {
        health = 100;
        totalAir = 100;
        air = 100;
        pressureResistance = 100;
        pressure = Mathf.FloorToInt(transform.position.y) + pressureResistance;
    }
    private void Update()
    {
        if (UnderWater == true)
        {
            if (air > 0)
            {
                ChangeAir(-1 * Time.deltaTime);
            }
        }
        else
        {
            if (air < 100)
            {
                ChangeAir(5 * Time.deltaTime);
            }
        }
        if(air < 0)
        {
            ChangeHealth(-5 * Time.deltaTime);
        }
        if(pressure < 0 )
        {
            ChangeHealth(-5 * Time.deltaTime);
        }
        if (health <= 0)
        {
            Destroy(this);
        }
        pressure = Mathf.FloorToInt(pressureResistance - -transform.position.y);
        ui.UpdatePressure(pressure);
        ui.UpdateAir(air);
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
            ChangeHealth(-10);
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
    public void ChangeHealth(float amount)
    {
        health += amount;
        ui.UpdateHealth(health);
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
    public void ChangeAir(float amount)
    {
        air += amount;
        ui.UpdateAir(air);
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
        ui.UpdatePressure(pressure);
    }
    //money
    public int GetMoney()
    {
        return money;
    }
    public void ChangeMoney(int amount)
    {
        money += amount;
        ui.UpdateMoney(money);
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
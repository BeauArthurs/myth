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
                AddAir(-1 * Time.deltaTime);
            }
        }
        else
        {
            if (air < 100)
            {
                AddAir(5 * Time.deltaTime);
            }
        }
        if(air < 0)
        {
            AddHealth(-5 * Time.deltaTime);
        }
        if(pressure < 0 )
        {
            AddHealth(-5 * Time.deltaTime);
        }
        if (health <= 0)
        {
            Destroy(this);
        }
        pressure = Mathf.FloorToInt(pressureResistance - -transform.position.y);
        ui.setPressure(pressure);
        ui.setAir(air);
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
            AddHealth(-10);
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
    public void boost()
    {
        GetComponent<Rigidbody>().AddForce(1 * direction * Time.deltaTime * speed * 35);
    }
    //Health
    public void SetTotalHealth(int amount)
    {
        totalHealth = amount;
    }
    public int GetTotalHealth()
    {
        return totalHealth;
    }
    public void AddHealth(float amount)
    {
        health += amount;
        ui.setHealth(health);
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
    public void AddAir(float amount)
    {
        air += amount;
        ui.setAir(air);
    }
    public void SetTotalAir(int amount)
    {
        totalAir = amount;
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
    
    
    public void AddPressureResistance(int amount)
    {
        if (money > 200)
        {
            money -= 200;
            pressureResistance += amount;
        }
    }
    public void AddMoney(int amount)
    {
        money += amount;
        ui.setMoney(money);
    }
    
    
    public void SetDirection(Vector3 input)
    {
        direction = input;
    }
    public void SetLightDir(bool on,float angel)
    {
        flashLight.gameObject.SetActive(on);
        flashLight.eulerAngles = new Vector3(0, 0, angel);
    }
}
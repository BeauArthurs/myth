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
        pressureResistance = 500;
        pressure = Mathf.FloorToInt(transform.position.y) + pressureResistance;
    }
	private void Update ()
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
        if (UnderWater == true)
        {
            air -= 1 * Time.deltaTime;
        }
        else
        {
            air += 2 * Time.deltaTime;
        }
        if(health <= 0)
        {
            Destroy(this);
        }
        ui.setAir(air);
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
    public int GetTotalHealth()
    {
        return totalHealth;
    }
    public int GetHealth()
    {
        return health;
    }
    public int GetTotalAir()
    {
        return totalAir;
    }
    public float GetAir()
    {
        return air;
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
        ui.setHealth(health);
    }
    public void AddAir(int amount)
    {
        air += amount;
        ui.setAir(air);
    }
    public void AddPressureResistance(int amount)
    {
        pressureResistance += amount;
    }
    public void AddMoney(int amount)
    {
        money += amount;
        ui.setMoney(money);
    }
    public void SetTotalHealth(int amount)
    {
        totalHealth = amount;
    }
    public void SetTotalAir(int amount)
    {
        totalAir = amount;
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
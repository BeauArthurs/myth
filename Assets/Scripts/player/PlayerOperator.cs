using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerOperator : MonoBehaviour 
{
    [SerializeField]
    private Transform flashLight;
    [SerializeField]
    private UiScript ui;
    [SerializeField]
    private bool tutorial;
    private float speed = 400;
    private Vector3 direction;
    private int totalHealth;
    private int health;
    private int air;
    private int pressure;
    private int pressureResistance;
    private int money;
    private float degree;
    private bool UnderWater;
    private bool aboveWater;
    private float timeLastSubtracted;
    private float redLightTimer;
    [SerializeField]
    private GameObject red;
    private int airTimer;
    [SerializeField]
    private AudioSource alarm;
    [SerializeField]
    private GameObject JoySticks;
    private void Start()
    {
        health = 9;
        air = 9;
        airTimer = 6;
        pressureResistance = 0;
        pressure = Mathf.FloorToInt(transform.position.y) + pressureResistance;
    }
    private void Update()
    {
        pressure = Mathf.FloorToInt(transform.position.y) - pressureResistance;
        if(pressure > 0)
        {
            pressure = 0;
        }
        ui.SetDepth(-pressure);
        if (pressure < -180)
        {
            if (Time.time >= redLightTimer + .5)
            {
                if (red.activeSelf == true)
                {
                    red.SetActive(false);
                    alarm.Play();
                }
                else
                {
                    red.SetActive(true);
                }
                redLightTimer = Time.time;
            }
        }
        else
        {
            red.SetActive(false);
        }
        if (UnderWater == true && tutorial == false)
        {
            if (Time.time >= timeLastSubtracted + airTimer && air > 0)
            {
                ChangeAir(-1); 
                timeLastSubtracted = Time.time;
            }
        }
        else if (UnderWater == true && tutorial == true)
        {
            if (Time.time >= timeLastSubtracted + 10 && air > 0)
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
        if(air == 0 || pressure < -200)
        {
            if (Time.time >= timeLastSubtracted + 1)
            {
                ChangeHealth(1 , -1);
                timeLastSubtracted = Time.time;
            }
        }
    }
	private void FixedUpdate ()
    {
            if(aboveWater == true)
            {
                direction.y = -.2f;
            }
            else if(UnderWater == false)
            {
                if(direction.y > 0)
                {
                    direction.y = .5f;
                }
            }
            GetComponent<Rigidbody>().AddForce(direction * Time.deltaTime *speed );
            
            pressure = Mathf.FloorToInt(transform.position.y) + pressureResistance;
            if(direction.x < 0)
            {
                degree = 0;
            }
            else if(direction.x > 0)
            {
                degree = 180;
            }
        transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, degree, 0), 1f * Time.deltaTime);
    }
    #region Collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Air")
        {
            ChangeHealth(1, -1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == (Tags.AIR))
        {
            UnderWater = false;
        }
        if(other.tag == "TopAir")
        {
            aboveWater = true;
        }
        else if(other.tag == "atlantis")
        {
            ui.win();
            JoySticks.SetActive(false);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == (Tags.AIR))
        {
            UnderWater = true;
        }
        if (other.tag == "TopAir")
        {
            aboveWater = false;
            direction.y = 0;
        }
    }
    #endregion
    #region Health
    public void ChangeHealth(int amount, int multiplayer)
    {
        for (int i = 0; i < amount; i++)
        {
            if (health + (1 * multiplayer) > -1 && health + (1 * multiplayer) < 10)
            {
                health += 1 * multiplayer;
                ui.SetHealth(health);
            }
            else if (health == 0)
            {
                //die
                Application.LoadLevel("Game");
            }
        }
    }
    public void SetTotalHealth(int amount)
    {
        totalHealth = amount;
    }
    public int GetTotalHealth()
    {
        return totalHealth;
    }
    public int GetHealth()
    {
        return health;
    }
    #endregion
    #region Air
    public int GetAirTimer()
    {
        return airTimer;
    }
    public void ChangeAirTimer(int amout)
    {
        if (airTimer < 10)
        {
            airTimer += amout;
        }
    }
    public float GetAir()
    {
        return air;
    }
    public void ChangeAir(int amount)
    {
        if (air - amount > -1)
        {
            air += amount;
            ui.SetAir(air);
        }
    }
    #endregion
    #region Pressure 
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
    #endregion
    #region money
    public int GetMoney()
    {
        return money;
    }
    public void ChangeMoney(int amount)
    {
        money += amount;
        ui.setMoney(money);
    } 
    #endregion
    #region other
    public void SetDirection(Vector3 input)
    {
        direction = -input;
    }
    public void SetLightDir(bool on,float angel)
    {
        flashLight.gameObject.SetActive(on);
        flashLight.eulerAngles = new Vector3(angel, 90, 0);
    }
    #endregion
}
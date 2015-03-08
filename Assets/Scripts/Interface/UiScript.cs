using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UiScript : MonoBehaviour {

    [SerializeField]
    private Slider health;
    [SerializeField]
    private Slider pressure;
    [SerializeField]
    private Slider air;
    [SerializeField]
    private Text money;      
    public void setHealth(int amount)
    {
        health.value = amount;
    }
    public void setPressure(int amount)
    {
        pressure.value = amount;
    }
    public void setAir(float amount)
    {
        air.value = amount;
    }
    public void setMoney(int amount)
    {
        money.text = "money : " + amount;
    }
}

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
    [SerializeField]
    private PlayerOperator player;
    [SerializeField]
    private GameObject pan;
    public void setHealth(float amount)
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
    public void Shop()
    {
        if(pan.activeSelf == true)
        {
            pan.SetActive(false);
        }
        else
        {
            pan.SetActive(true);
        }
    }
    public void Heal()
    {
        player.heal();
    }
    public void AddPressureRes()
    {
        pressure.maxValue += 100;
        player.AddPressureResistance(100);
    }
}

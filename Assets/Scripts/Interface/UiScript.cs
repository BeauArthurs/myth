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
    private GameObject pan;
    [SerializeField]
    private PlayerOperator player;
    public void UpdateHealth(float amount)
    {
        health.value = amount;
    }
    public void UpdatePressure(int amount)
    {
        pressure.value = amount;
    }
    public void UpdateAir(float amount)
    {
        air.value = amount;
    }
    public void UpdateMoney(int amount)
    {
        money.text = "money : " + amount;
    }

    //shop
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
        if (player.GetMoney() > 100)
        {
            player.ChangeMoney(-100);
            player.ChangeHealth(30);
        }
    }
    public void AddPressureResistance()
    {
        if (player.GetMoney() > 300)
        {
            player.ChangeMoney(-300);
            player.ChangePressureResistance(100);
        }
    }
}

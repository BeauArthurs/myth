using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
public class UiScript : MonoBehaviour 
{
    [SerializeField]
    private Sprite[] health;
    [SerializeField]
    private Sprite[] Air;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Image AirTank;
    [SerializeField]
    private RectTransform DepthMeter;
    [SerializeField]
    private GameObject Store;
    [SerializeField]
    private GameObject _Menu;
    [SerializeField]
    private Text money;

    [SerializeField]
    private AudioMixer _Mastermix;

    [SerializeField]
    private PlayerOperator _operatorController;

    public void SetHealth(int amount)
    {
        if (amount < 9 || amount > 0)
        {
            healthBar.sprite = health[amount];
        }
    }
    public void SetAir(int amount)
    {
        AirTank.sprite = Air[amount];
    }
    public void SetDepth(int amount)
    {
        DepthMeter.eulerAngles = new Vector3(0, 0, -amount);
    }
    public void setMoney(int amount)
    {
        money.text = "Money : " + amount;
    }
    public void Shop()
    {
        if (Store.activeSelf == true)
        {
            Store.SetActive(false);
        }
        else
        {
            Store.SetActive(true);
        }
    }

    public void Menu()
    {
        if (_Menu.activeSelf == true)
        {
            _Menu.SetActive(false);
        }
        else
        {
            _Menu.SetActive(true);
        }
    }

    public void Heal()
    {
        if(_operatorController.GetMoney() > 100)
        {
            _operatorController.ChangeMoney(-100);
            _operatorController.ChangeHealth(2 ,1);
        }
    }
    public void UpgradeAirTank()
    {
        if (_operatorController.GetMoney() > 200 && _operatorController.GetAirTimer() < 10)
        {
            _operatorController.ChangeMoney(-200);
            _operatorController.ChangeAirTimer(1);
        }
    }

    public void UpgradeHual()
    {
        if (_operatorController.GetMoney() > 1000)
        {
            _operatorController.ChangeMoney(-1000);
            _operatorController.ChangePressureResistance(200);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        Application.LoadLevel("Menu");
    }
}

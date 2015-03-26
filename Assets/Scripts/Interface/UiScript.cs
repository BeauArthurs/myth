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
    private int _itemNumber;

    [SerializeField]
    private AudioMixer _Mastermix;

    private GameObject _player;
    private PlayerOperator _operatorController;

    void Start () 
    {
    _player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
    _operatorController = _player.GetComponent<PlayerOperator>();
    }

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
              print("heal");
              _operatorController.ChangeHealth(1);
            }

            public void UpgradeHealth()
               {
                  print("upgrade health");
                  _operatorController.ChangeHealth(_operatorController.GetHealth() + 1);
               }

             public void UpgradeAirTank()
              {   
                 print("upgrade air thin tank");
                 _operatorController.ChangePressureResistance(_operatorController.GetPressure() + 1);
              }

           public void Boost()
           {
             print("upgrade boost");
             _operatorController.boostSpeed = _operatorController.boostSpeed + 5;
           }
           public void Exit()
           {
               Application.Quit();
           }
           public void Sound()
           {
               //_Mastermix.SetFloat("MUSIC",10);
               if (Camera.main.GetComponent<AudioSource>().mute == true)
               {
                   Camera.main.GetComponent<AudioSource>().mute = false;
               }
               else
               {
                   Camera.main.GetComponent<AudioSource>().mute = true;
               }
              
           }
           public void MainMenu()
           {
               Application.LoadLevel("Menu");
           }
}

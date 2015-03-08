using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UiScript : MonoBehaviour {

    [SerializeField]
    private Slider helth;
    [SerializeField]
    private Slider pressure;
    [SerializeField]
    private Slider power;
    [SerializeField]
    private PlayerOperator player;
    [SerializeField]
    private Text money;
	void Update () 
    {
        helth.value = player.GetHealth();
        pressure.value = player.GetPressure();
        power.value = player.GetAir();
        money.text = "money : " + player.GetMoney();
	}
}

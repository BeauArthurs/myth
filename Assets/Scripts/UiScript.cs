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
	void Update () 
    {
        helth.value = player.GetHealth();
        pressure.value = player.GetPressure();
        power.value = player.GetPower();
	}
}

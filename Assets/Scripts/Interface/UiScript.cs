using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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

    public void SetHealth(int amount)
    {
        healthBar.sprite = health[amount];
    }
    public void SetAir(int amount)
    {
        AirTank.sprite = Air[amount];
    }
    public void SetDepth(int amount)
    {
        DepthMeter.eulerAngles = new Vector3(0, 0, amount);
    }
}

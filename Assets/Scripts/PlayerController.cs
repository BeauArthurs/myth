using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    Slider _airSlider;
    [SerializeField]
    Slider _pressureSlider;
    [SerializeField]
    private int _speed;
    private int _pressure;
    private int _resistance;
    private float _air;
    private int _health;

	void Start () 
    {
        _health = 100;
        _resistance = -50;
        _air = 100;
	}
	void Update ()
    {
        _airSlider.value = _air;
        _pressure = Mathf.FloorToInt(transform.position.y) - _resistance;
        Debug.Log(_pressure);
        if(_pressure < 0 && _pressure > -100 )
        {
            _pressureSlider.value = -_pressure;
        }
        _air -= 1 * Time.deltaTime;
    }
    public void Move(Vector3 direction)
    {
        rigidbody.AddForce(direction * _speed * Time.deltaTime);
    }
}

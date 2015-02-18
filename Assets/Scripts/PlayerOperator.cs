using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerOperator : MonoBehaviour {
    [SerializeField]
    Slider _airSlider;
    [SerializeField]
    Slider _pressureSlider;
    [SerializeField]
    Slider _healthSlider;
    [SerializeField]
    private int _speed;
    private int _pressure;
    private int _resistance;
    private float _air;
    private int _health;
    private bool underWater;
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
        if(_pressure < 0 && _pressure > -100 )
        {
            _pressureSlider.value = -_pressure;
        }
        if(underWater)
        {
            _air -= 1 * Time.deltaTime;
        }
        else if(!underWater && _air < 100)
        {
            _air += 5 * Time.deltaTime;
        }
        
    }
    public void ChangeHealth(int hitPoints)
    {
        _health += hitPoints;
        _healthSlider.value = _health;
    }
    public void Move(Vector3 direction)
    {
        rigidbody.AddForce(direction * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Air")
        {
            underWater = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Air")
        {
            underWater = true;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag =="Wall")
        {
            ChangeHealth(-5);
        }
    }
}

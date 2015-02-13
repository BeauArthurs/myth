using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{
 
    [SerializeField]
    private GameObject[] _points;
    private GameObject _currentPoint;
    private GameObject _player ;

    public enum MovementState
    {
        Patrol = 0,
        Attack,
    }

    private MovementState _state;

    void Start()
    {

        _player = GameObject.FindGameObjectWithTag("player");
        _currentPoint = _points[0];
        StartCoroutine(PatrolState());
        
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "player")
        {
            StopCoroutine(PatrolState());
            StartCoroutine(AttackState());
        }
    }

    void OnTriggerExit(Collider other)
    {
        this.transform.position = new Vector3(1, 1, 0);
        Debug.Log(this.transform.position);
        StopCoroutine(AttackState());
        StartCoroutine(PatrolState());
    }*/

    IEnumerator PatrolState()
    {
        
        while (_state == MovementState.Patrol)
        { 
            transform.LookAt(_currentPoint.transform.position);
            transform.Translate(Vector3.forward * (2 * Time.deltaTime));
            if (Mathf.Abs (_currentPoint.transform.position.x - this.transform.position.x) < 1)
            {
                if (_currentPoint == _points[0])
                {
                    _currentPoint = _points[1];
                    
                }
                else if (_currentPoint == _points[1])
                {
                    _currentPoint = _points[0];
                }
            }
            yield return 0;
        }
    }

    IEnumerator AttackState()
    {
        while (true)
        {
            transform.LookAt(_player.transform.position);
            transform.Translate(Vector3.forward * (5 * Time.deltaTime));
            yield return 0;
        }
    }

}
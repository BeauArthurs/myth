using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{
 
    [SerializeField]
    private GameObject[] _points;
    private GameObject _currentPoint;
    private GameObject _player ;

    public enum SharkBehavior
    {
        Patrol = 0,
        Attack,
    }

    private SharkBehavior _state;

    void Start()
    {

        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        _currentPoint = _points[0];
        StartCoroutine(PatrolState());
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == (Tags.PLAYER))
        {

            StartCoroutine(AttackState());
            StopCoroutine(PatrolState());
        }
    }

    void OnTriggerExit(Collider other)
    {
        this.transform.position = new Vector3(1, 1, 0);
        StopCoroutine(AttackState());
        StartCoroutine(PatrolState());
    }

    IEnumerator PatrolState()
    {
        _state = SharkBehavior.Patrol;
        while (_state == SharkBehavior.Patrol)
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
        _state = SharkBehavior.Attack;
        while (true)
        {
            transform.LookAt(_player.transform.position);
            transform.Translate(Vector3.forward  * Time.deltaTime);
            yield return 0;
        }
    }

}
using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{
 
    [SerializeField]
    private GameObject[] _points;
    private int _currentPoint;
    private GameObject _player;
    private Transform _target;
    private Vector3 _startPosition;
    private float timeLastSubtracted;
    public enum SharkBehavior
    {
        Patrol = 0,
        Attack,
        Follow,
    }

    [SerializeField]
    private SharkBehavior _state;

    void Start()
    {
        _startPosition = this.transform.position;
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        _currentPoint = 0;
        StartCoroutine(PatrolState());
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == (Tags.PLAYER))
        {
            StartCoroutine(FollowState());
            StopCoroutine(PatrolState());
            _target = other.transform; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == (Tags.PLAYER))
        {
            StopCoroutine(FollowState());
            StartCoroutine(PatrolState());
            Debug.Log(_state);
            this.transform.position = _startPosition;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == (Tags.PLAYER))
        {
           _player.gameObject.GetComponent<PlayerOperator>().ChangeHealth(3 , -1);
        }
    }

    void OnCollitionExit(Collision other)
    {
        StartCoroutine(FollowState());
    }

    IEnumerator PatrolState()
    {
        _state = SharkBehavior.Patrol;
        _currentPoint = 0;
        StopCoroutine(FollowState());

        while (_state == SharkBehavior.Patrol)
        {
            transform.LookAt(_points[_currentPoint].transform.position);
            transform.Translate(Vector3.forward * (20 * Time.deltaTime));
            if (Mathf.Abs(_points[_currentPoint].transform.position.x - this.transform.position.x) < 1)
            {
                if (_currentPoint == _points.Length)
                {
                    _currentPoint = 0;
                }
                _currentPoint = _currentPoint + 1;
                
            }
            yield return 0;
        }
    }

    IEnumerator AttackState()
    {
        
        StopCoroutine(FollowState());
        _state = SharkBehavior.Attack;
        while (_state == SharkBehavior.Attack)
        {
            //GetComponent<Rigidbody>().AddForce(Vector3.left * 500 * Time.deltaTime);
            transform.Translate(Vector3.forward * (10 * Time.deltaTime));
    
            yield return 0;
        }
    }

    IEnumerator FollowState()
    {
        _state = SharkBehavior.Follow;
        while (_state == SharkBehavior.Follow)
        {
                        transform.LookAt(_player.transform.position);
            //GetComponent<Rigidbody>().AddForce(Vector3.left *100* Time.deltaTime);
            transform.Translate(Vector3.forward * (2 * Time.deltaTime));
            float distens = Vector3.Distance (transform.position, _target.position);
            Debug.Log(transform.position);
            if (Time.time >= timeLastSubtracted + 1)
            {
                if (distens <= 10)
                {
                    StopCoroutine(FollowState());
                    StartCoroutine(AttackState());
                }
                timeLastSubtracted = Time.time;
            }

            yield return 0;
        }

        
    }

}
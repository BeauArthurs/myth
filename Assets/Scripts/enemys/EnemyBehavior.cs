using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject[] _points;
    private int _currentPoint;
    private GameObject _player;
    private Transform _target;
    private float timeLastSubtracted;
    [SerializeField]
    private int attackDistance;
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
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        _currentPoint = 0;
        StartCoroutine(PatrolState());
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == (Tags.PLAYER))
        {
            _target = other.transform;
            StartCoroutine(FollowState());
            StopCoroutine(PatrolState());
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
            transform.Translate(Vector3.forward * (3 * Time.deltaTime));
            if (Mathf.Abs(_points[_currentPoint].transform.position.x - this.transform.position.x) < 1)
            {
                if (_currentPoint == _points.Length - 1)
                {
                    _currentPoint = 0;
                }
                else
                {
                    _currentPoint += 1;
                }
            }
            yield return 0;
        }
    }

    IEnumerator AttackState()
    {
        anim.SetTrigger("attack");
        _state = SharkBehavior.Attack; 
        while (_state == SharkBehavior.Attack)
        {
            if (Time.time >= timeLastSubtracted + .7)
            {
                StartCoroutine(FollowState());
                StopCoroutine(AttackState());
            }
            yield return 0;
        }
        
    }

    IEnumerator FollowState()
    {
        _state = SharkBehavior.Follow;
        while (_state == SharkBehavior.Follow)
        {
            
            transform.LookAt(_player.transform.position);
            float distance = Vector3.Distance(transform.position, _target.position);
            if (distance <= attackDistance)
            {
                timeLastSubtracted = Time.time;
                StartCoroutine(AttackState());
                StopCoroutine(FollowState());

            }
            if (distance >= 30)
            {
                transform.position = _points[0].transform.position;
                StartCoroutine(PatrolState());
                StopCoroutine(FollowState());
            }
            transform.Translate(Vector3.forward * (2* Time.deltaTime));
               
            yield return 0;
        }

        
    }

}
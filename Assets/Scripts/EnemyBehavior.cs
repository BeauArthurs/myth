using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{
    private Vector3 _pointA = new Vector3(1,1,0);
    private Vector3 _pointB = new Vector3(10,1,0);

    public enum MovementState
    {
        Patrol = 0,
        Attack,
    }

    private MovementState _state;

    void Start()
    {
        StartCoroutine(PatrolState(_pointA, _pointB)); 
    }

    IEnumerator PatrolState(Vector3 _positionA, Vector3 _positionB)
    {
        Debug.Log("patrol start");
        while (_state == MovementState.Patrol)
        {
            if (this.transform.position == _positionA)
            {
                //L Position

                transform.Translate(Vector3.left * Time.deltaTime);
            }
            else if (this.transform.position == _positionB)
            {
                //R Position
                transform.Translate(Vector3.right * Time.deltaTime);
            }
            yield return 0;
        }
    }

    IEnumerator AttackState()
    {
        Debug.Log("Attack Start");
        while (_state == MovementState.Attack)
        {
            yield return 0;
        }
    }

}
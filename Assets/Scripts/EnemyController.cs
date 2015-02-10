using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    public enum MovementState
    {
        Patrol = 0,
        Attack,
    }

    private MovementState _state;

    void Start()
    {
        StartCoroutine(PatrolState(new Vector3(1, 1, 0), new Vector3(10, 1, 0)));
    }

    IEnumerator PatrolState(Vector3 _positionA, Vector3 _positionB)
    {
        float speed = Time.deltaTime * 1;
        Debug.Log("patrol start");
        while (_state == MovementState.Patrol)
        {
            if (this.transform.position == _positionA)
            {
                //L Position
                this.transform.position = new Vector3(this.transform.position.x + speed, this.transform.position.y, this.transform.position.z);
            }
            if (this.transform.position == _positionB)
            {
                //R Position
                this.transform.position = new Vector3(this.transform.position.x - speed, this.transform.position.y, this.transform.position.z);
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

using UnityEngine;
using System.Collections;

public class EnemyBehaviorNew : MonoBehaviour {

    [SerializeField]
    private GameObject[] _points;
    private GameObject _currentPoint;

   
    public enum SharkBehavior
    { 
        Patrol = 0,
        Attack,
        Follow,
    }
     [SerializeField]
    private SharkBehavior _state;
	void Start () 
    {
        _currentPoint = _points[1];
        StartCoroutine(PatrolState());
	}

    IEnumerator PatrolState()
    {
        _state = SharkBehavior.Patrol;
        while (_state == SharkBehavior.Patrol)
        {
            transform.LookAt(_currentPoint.transform.position);
            GetComponent<Rigidbody>().AddForce(Vector3.left * 2000*  Time.deltaTime);
            yield return 0;
        }
    }
	
}

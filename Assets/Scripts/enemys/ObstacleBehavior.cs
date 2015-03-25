using UnityEngine;
using System.Collections;

public class ObstacleBehavior : MonoBehaviour {
    private GameObject _player;
    private PlayerOperator _operatorController;
	// Use this for initialization
	void Start () {
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        _operatorController = _player.GetComponent<PlayerOperator>();
	}
	
	// Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == (Tags.PLAYER))
        {
            Destroy(this.gameObject);

            _operatorController.ChangeHealth(-3);

        }
    }
}

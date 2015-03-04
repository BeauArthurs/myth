using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {
    private PlayerOperator _operatorController;
    public int typePickUp;
    private GameObject _player;
	// Use this for initialization
	void Start () {
        _player = GameObject.FindGameObjectWithTag("player");
        _operatorController = _player.GetComponent<PlayerOperator>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(_player);
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("not player");
        if (other.gameObject == _player)
        {
            Debug.Log("player not work");
            switch (typePickUp)
            {
                case 1:
                    Debug.Log("1,gold");
                    Destroy(this.gameObject);
                    break;
            }
        }
    }
}

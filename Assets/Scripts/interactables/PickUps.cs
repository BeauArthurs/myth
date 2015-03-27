using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {
    private PlayerOperator _operatorController;
    public int typePickUp;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == (Tags.PLAYER))
        {
            _operatorController = other.GetComponent<PlayerOperator>();
            switch (typePickUp)
            {
                case 1:
                    
                    _operatorController.ChangeMoney(Random.Range(100, 150));
                    Destroy(this.gameObject);
                    break;
            }
        }
    }
}

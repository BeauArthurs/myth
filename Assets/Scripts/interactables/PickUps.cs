using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {
    private PlayerOperator _operatorController;
    public int typePickUp;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("player"))
        {
            _operatorController = other.GetComponent<PlayerOperator>();
            switch (typePickUp)
            {
                case 1:
                    Destroy(this.gameObject);
                    _operatorController.AddMoney(Random.Range(100, 150));
                    break;
            }
        }
    }
}

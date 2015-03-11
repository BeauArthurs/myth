using UnityEngine;
using System.Collections;

public class ObstakleBehaviore : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PlayerOperator _operatorController = other.GetComponent<PlayerOperator>();
        if (other.tag == (Tags.PLAYER))
        {
            Destroy(this.gameObject);
            _operatorController.ChangeHealth(-30);

        }
    }
}

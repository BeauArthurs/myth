using UnityEngine;
using System.Collections;

public class ObstakleBehaviore : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("a");
        if (other.tag == "player")
        {
            Destroy(this.gameObject);
        }
    }
}

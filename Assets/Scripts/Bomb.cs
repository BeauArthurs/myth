using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

    private float distance;
	void Update () 
    {
	
	}
    void OnTriggerStay(Collider other)
    {
        if (other.name == "Player")
        {
            distance = Vector3.Distance(transform.position, other.transform.position);
            if(distance < 5)
            {
                other.GetComponent<PlayerOperator>().ChangeHealth(-20);
                Destroy(this.gameObject);
            }
        }
    }
}

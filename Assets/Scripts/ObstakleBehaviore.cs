using UnityEngine;
using System.Collections;

public class ObstakleBehaviore : MonoBehaviour
{
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "player")
        {
            Destroy(this.gameObject);
            Debug.Log("playerhealth - damage");
        }
    }
}

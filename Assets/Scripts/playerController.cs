using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour 
{
    private bool jumping;
    private void Start()
    {
        jumping = false;
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void Jump()
    {
        if (!jumping)
        {
            rigidbody.AddForce(new Vector3(0, 2500, 0));
            jumping = true;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Platform")
        {
            jumping = false;
        }
    }
}

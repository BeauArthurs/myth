using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour 
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private int jumpHight;
    [SerializeField]
    private bool jumping;
    private void Start()
    {
        jumping = false;
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + Vector3.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!jumping)
            {
                rigidbody.AddForce(Vector3.up * jumpHight);
                jumping = true;
            }
        }
        /*for (int a = 0; a < Input.touchCount; a++)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.touches[a].position.x, Input.touches[a].position.y, 13)), Vector2.zero);
            if (hit.collider != null)
            {
                if (Input.touches[a].phase == TouchPhase.Began)
                {
                    if (hit.collider.name == "Up")
                    {
                        if (!jumping)
                        {
                            rigidbody.AddForce(Vector3.up * jumpHight);
                            jumping = true;
                        }
                    }
                }
                if (Input.touches[a].phase == TouchPhase.Stationary || Input.touches[a].phase == TouchPhase.Moved)
                {

                    if (hit.collider.name == "Left")
                    {
                        transform.position = transform.position + Vector3.left * Time.deltaTime;
                    }
                    if (hit.collider.name == "Right")
                    {
                        transform.position = transform.position + Vector3.right * Time.deltaTime;
                    }
                    if (hit.collider.name == "Down")
                    {

                    }

                }
            }
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Platform")
        {
            jumping = false;
        }
    }
}

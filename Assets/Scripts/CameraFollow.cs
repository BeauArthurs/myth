using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform target;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private float damp;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(target.position.x, target.position.y, Camera.main.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * damp);
    }
}

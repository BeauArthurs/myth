using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    [SerializeField]
    private Transform target;
    private float smoothTime = 0.1F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 targetX = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));
        transform.position = Vector3.SmoothDamp(transform.position, targetX, ref velocity, smoothTime);
    }
}

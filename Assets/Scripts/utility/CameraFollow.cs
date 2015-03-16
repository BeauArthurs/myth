using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform target;
    [SerializeField]
    private float damp;
    private int _zPosCamera = -8;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(target.position.x, target.position.y +3, _zPosCamera);
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * damp);
    }
}

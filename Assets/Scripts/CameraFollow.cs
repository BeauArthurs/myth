﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform target;
    [SerializeField]
    private float damp;
    private int _zPosCamera = -13;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(target.position.x, target.position.y, _zPosCamera);
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * damp);
    }
}

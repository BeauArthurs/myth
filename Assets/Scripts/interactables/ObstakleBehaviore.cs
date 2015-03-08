﻿using UnityEngine;
using System.Collections;

public class ObstakleBehaviore : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PlayerOperator _operatorController = other.GetComponent<PlayerOperator>();
        if (other.tag == "player")
        {
            Destroy(this.gameObject);
            _operatorController.AddHealth(-30);

        }
    }
}
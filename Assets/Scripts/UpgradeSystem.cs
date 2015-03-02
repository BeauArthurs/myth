using UnityEngine;
using System.Collections;

public class UpgradeSystem : MonoBehaviour {
    private PlayerOperator _operatorController;

	// Use this for initialization
	void Start ()
    {
    _operatorController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerOperator>();
	}
	
	// Update is called once per frame
	void Update () 
    {

  	}
}
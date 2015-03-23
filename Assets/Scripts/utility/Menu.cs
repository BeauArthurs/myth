using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    private GameObject _Menu;
	// Use this for initialization
	void Start () {
        _Menu = GameObject.FindGameObjectWithTag(Tags.MENU);
	}
	
	// Update is called once per frame
    void Update()
    {

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {

            }
        }
    }
}

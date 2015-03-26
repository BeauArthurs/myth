using UnityEngine;
using System.Collections;

public class ObstacleBehavior : MonoBehaviour {
    private GameObject _player;
    private PlayerOperator _operatorController;
    [SerializeField]
    private ParticleSystem part;
	// Use this for initialization
	void Start () {
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        _operatorController = _player.GetComponent<PlayerOperator>();
	}
	
	// Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag +"tag");
        if (other.tag == (Tags.PLAYER))
        {
            Debug.Log("6");
            part.Play();
            Debug.Log("7");
            Destroy(this.gameObject);
           //_operatorController.ChangeHealth(-3);

        }
    }
}

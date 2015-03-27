using UnityEngine;
using System.Collections;

public class ObstacleBehavior : MonoBehaviour {
    [SerializeField]
    private ParticleSystem part;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == (Tags.PLAYER))
        {
            part.Play();
            Destroy(this.gameObject);
            other.GetComponent<PlayerOperator>().ChangeHealth(3 , -1);
        }
    }
}

using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour {
    public string userName;
    private string url = "http://Localhost/AtlantisGame/Connection.php";
    public GameObject player;
    public PlayerOperator _operatorController;
    private bool dead = false;
    

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

	void Update () 
    {
        float health = _operatorController.GetHealth();
        
        if (health <= 0)
        {
            dead = true;
        }

        if (dead == true)
        {
            Debug.Log("stuur");
            WWWForm form = new WWWForm();
            form.AddField("score", Mathf.FloorToInt(-player.transform.position.y));
            form.AddField("name", userName);
            WWW www = new WWW(url, form);
            StartCoroutine(WaitForRequest(www));
            Application.LoadLevel("Kevin");
            
        }
	}
}
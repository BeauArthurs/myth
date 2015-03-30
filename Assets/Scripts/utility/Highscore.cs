using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour {
    public string userName;
    private string url = "http://lycan-games.com/myth/Connection.php";
    

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

	public void send (float score) 
    {
            WWWForm form = new WWWForm();
            form.AddField("score", Mathf.FloorToInt(score));
            form.AddField("name", userName);
            WWW www = new WWW(url, form);
            StartCoroutine(WaitForRequest(www));
	}
}
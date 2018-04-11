using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerInteraction : MonoBehaviour {

    //Radar Object
    public GameObject radar;

    private string url;

    private float interval;

	// Use this for initialization
	void Start () {
        url = "http://lurker.000webhostapp.com/getalert.php";
    }

    // Update is called once per frame
    void Update () {
        if(Time.time > interval)
        {
            interval = Time.time + 5.0f;
            GetGhostRoom();
        }		
	}

    void GetGhostRoom()
    {
        WWW form = new WWW(url);

        StartCoroutine(WaitForRequest(form));

        //Debug.Log(form.text);

        /*
        form.AddField("room_id", room);
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www));

        switch (other.name)
        {
            case "Kitchen":
                {
                    room = "1";
                    break;
                }
            case "Dining":
                {
                    room = "2";
                    break;
                }
            case "Nursery":
                {
                    room = "3";
                    break;
                }
            case "Closet":
                {
                    room = "4";
                    break;
                }
            case "SRA":
                {
                    room = "5";
                    break;
                }
            case "Hallway":
                {
                    room = "6";
                    break;
                }
            case "SRB":
                {
                    room = "7";
                    break;
                }
            case "Bathroom":
                {
                    room = "8";
                    break;
                }
            case "RUC":
                {
                    room = "9";
                    break;
                }
            case "Bedroom":
                {
                    room = "10";
                    break;
                }
            case "Lab":
                {
                    room = "11";
                    break;
                }
            case "Library":
                {
                    room = "12";
                    break;
                }
            default:
                break;
                */
    }


    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            //radar.GetComponent<Radar>().UpdateRadar(new Vector3());
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            //Debug.Log("WWW Error: " + www.error);
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
	
public class Radar : MonoBehaviour {
    /*
    // implements radar which shows where the ghost "is" depending on audience input
    // right now it shows where the ghost is with 50% accuracy

    public Transform player;    //get player rotation
	float mapScale = 2.0f;

    public Image icon;

    float time;
    Vector3 prevRadarPos;

    public GameObject ro;  //ghost
    GameObject parent;

    public void UpdateRadar(Vector3 pos)
    {
        Vector3 radarPos = prevRadarPos;

        if (Time.time > time + 3.0f)
        {
            time = Time.time;
            radarPos = (ro.transform.position - pos);
            prevRadarPos = radarPos;

        }

        float distToObject = Vector3.Distance(pos, ro.transform.position) * mapScale;
        float deltay = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - player.eulerAngles.y;
        radarPos.x = distToObject * Mathf.Cos(deltay * Mathf.Deg2Rad) * -1;
        radarPos.z = distToObject * Mathf.Sin(deltay * Mathf.Deg2Rad);

        icon.transform.SetParent(this.transform);
        icon.transform.position = new Vector3(radarPos.x, radarPos.z, 0) + this.transform.position;
    }
    
	// Use this for initialization
	void DelayedStart () {
        time = Time.time - 2.0f;
        prevRadarPos = new Vector3();
        Debug.Log("happened");
       // ro = radObjects[0];
    }

    // Update is called once per frame
    void Update () {
        //DrawRadarDots();
        UpdateRadar(transform.position);
	}
    */

    GameObject player;
    GameObject ghost;
    float frequency;
    float updateTime;
    float mapScale;
    Vector3 radarPos;
    Vector3 ghostPos;
    public Image icon;
    float distToObject;

    public Text warning;
    int prevUpdate;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ghost = GameObject.FindGameObjectWithTag("Ghost");
        radarPos = (ghost.transform.position - player.transform.position);
        frequency = 3f;
        updateTime = Time.time;
        mapScale = 1.5f;
        warning.text = "Waiting for audience input...";
    }

    void Update()
    {
        DrawRadar();
        warning.text = "Last updated " + (Mathf.FloorToInt(Time.time) - prevUpdate) + " seconds ago.";
    }

    public void UpdateRadar(Vector3 pos)
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        radarPos = (pos - player.transform.position);
        distToObject = Vector3.Distance(player.transform.position, pos) * mapScale;
        prevUpdate = Mathf.FloorToInt(Time.time);
    }

    void DrawRadar()
    {
        ghostPos = radarPos;
        /*if (Time.time > updateTime)
        {
            updateTime = Time.time + frequency;
            UpdateRadar(ghost.transform.position);
        }*/
        float deltay = Mathf.Atan2(ghostPos.x, ghostPos.z) * Mathf.Rad2Deg - 270 - player.transform.eulerAngles.y;
        // print(player.transform.eulerAngles.y);
        // print(deltay);
        ghostPos.x = distToObject * Mathf.Cos(deltay * Mathf.Deg2Rad) * -1;
        ghostPos.z = distToObject * Mathf.Sin(deltay * Mathf.Deg2Rad);

        //icon.transform.SetParent(this.transform);
        icon.transform.position = new Vector3(ghostPos.x, ghostPos.z, 0) + this.transform.position;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebAudio : MonoBehaviour {

    [Serializable]
    struct Vote
    {
        public string choice;
    }

    [Serializable]
    struct GhostPos
    {
        public int room;
    }

    // These are normal Unity Gameplay elements
    public AudioSource toilet;
    public AudioSource tv;

    public Radar r;
    public mapKeyEvent mke;

    // This is the monobehavior the takes care of all IRC networking.
    public TwitchNetworking networking;

    // This is the interface for sending and recieving network messages.
    APG.APGSys apg;

    // This is a function for recieiving network messages from clients.
    // The logic for this will work as follows: when any client taps their HTML5 client or clicks
    // their mouse over it, we will show a firework briefly on the streamer's screen in
    // the location of the tap.

    void AudioHandler(string sender, Vote data)
    {
        if (data.choice == "toilet") { 
            toilet.Play();
        }
        else if(data.choice == "tv")
        {
            tv.Play();
        }
    }

    void RadarHandler(string sender, GhostPos data)
    {
        string location = "";
        print(data.room);
        switch (data.room)
        {
            case 1:
                {
                    location = "Kitchen";
                    break;
                }
            case 2:
                {
                    location = "Dining";
                    break;
                }
            case 3:
                {
                    location = "Nursery";
                    break;
                }
            case 4:
                {
                    location = "Closet";
                    break;
                }
            case 5:
                {
                    location = "SRA";
                    break;
                }
            case 6:
                {
                    location = "Hallway";
                    break;
                }
            case 7:
                {
                    location = "SRB";
                    break;
                }
            case 8:
                {
                    location = "Bathroom";
                    break;
                }
            case 9:
                {
                    location = "RUC";
                    break;
                }
            case 10:
                {
                    location = "Bedroom";
                    break;
                }
            case 11:
                {
                    location = "Lab";
                    break;
                }
            case 12:
                {
                    location = "Library";
                    break;
                }
            default:
                break;
        }
        print(location);

        GameObject radarGhost = GameObject.Find(location);
        Debug.Log(radarGhost);
        mke.EnableRadar();
        r.UpdateRadar(radarGhost.transform.position);
        mke.manualClose = false;
        Invoke("DelayedDisableMap", 5f);
    }

    void DelayedDisableMap()
    {
        if(!mke.manualClose)
        {
            mke.DisableRadar();
        }
    }


    void Start()
    {
        Application.runInBackground = true;

        apg = networking.GetAudienceSys();
        apg.ResetClientMessageRegistry();
        apg.Register<Vote>("vote", AudioHandler);
        apg.Register<GhostPos>("radar", RadarHandler);
    }

    void Update()
    {
    }
}

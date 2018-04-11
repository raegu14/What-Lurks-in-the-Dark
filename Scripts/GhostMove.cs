using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class GhostMove : MonoBehaviour {

    public TwitchNetworking tn;

    public float minSpeed;
    public float maxSpeed;

    public GameObject firstLocation;
    int locationIdx;
    float DIST_MARGIN;       //acceptable distance from player to target location
    GameObject[] possibleLocations;
    GameObject prevLocation;
    GameObject currLocation;
    GameObject targetLocation;
    GameObject[] allLocations;

    AudioSource sound;
    Animator anim;
    Transform player;
    Quaternion look;
    float speed;
    Vector3 target;
    bool targeting;

    bool entered = false;
//    string url = "http://lurker.000webhostapp.com/text.php";

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(0, 0, 1).normalized;
        transform.localRotation = Quaternion.LookRotation(target);
        anim = GetComponent<Animator>();
        speed = minSpeed;
        //anim.speed = minSpeed/8;
        sound = GetComponent<AudioSource>();
        transform.position = firstLocation.transform.position;
        currLocation = firstLocation;
        var neighbors = firstLocation.GetComponent<Vertex>().getNeighbors();
        if(neighbors.Length != 0)
        {
            targetLocation = neighbors[UnityEngine.Random.Range(0, neighbors.Length)];
        }
        allLocations = GameObject.FindGameObjectsWithTag("GhostPositions");
        DIST_MARGIN = 0.25f;
    }

    void FixedUpdate()
    {
        Vector3 distance = player.transform.position - transform.position;
        //if x distance away head towards target location
        if (distance.magnitude > 15)
        {
            targeting = false;
        }

        else
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, distance, out hit, 15);
            if (hit.collider == null || hit.collider.tag == "Player")
            {
                targeting = true;
            }
            else
            {
                targeting = false;
            }
        }

        if (!targeting)
        {
            anim.SetBool("Walking", true);
            //if arrived at location, choose new location
            if(entered || targetLocation == null)
            {
                float dist = Mathf.Infinity;
                //find closest vertex not blocked
                for(int i = 0; i < allLocations.Length; i++)
                {
                    if(!Physics.Raycast(transform.position + new Vector3(0, 2, 0), transform.position - allLocations[i].transform.position, Vector3.Distance(transform.position, allLocations[i].transform.position)))
                    {
                        if(Vector3.Distance(transform.position, allLocations[i].transform.position) < dist)
                        {
                            dist = Vector3.Distance(transform.position, allLocations[i].transform.position);
                            targetLocation = allLocations[i];
                        }
                    }
                }
            }

            else if (Vector3.Distance(transform.position, targetLocation.transform.position) < DIST_MARGIN)
            {
                possibleLocations = targetLocation.GetComponent<Vertex>().getNeighbors();
                if (possibleLocations.Length != 0)
                {
                    var idx = possibleLocations[UnityEngine.Random.Range(0, possibleLocations.Length)];
                    if (idx == prevLocation)
                    {
                        idx = possibleLocations[UnityEngine.Random.Range(0, possibleLocations.Length)];
                    }
                    prevLocation = currLocation;
                    currLocation = targetLocation;
                    targetLocation = idx;
                }
            }
            target = (targetLocation.transform.position - transform.position).normalized;
            transform.localRotation = Quaternion.LookRotation(target);
            entered = false;
            speed = minSpeed;
        }
        //else move towards the player faster and faster
        else
        {
            anim.SetBool("Walking", false);
            sound.volume = 10 / distance.magnitude;
            if (!entered)
            {
                sound.Play();
                entered = true;
            }
            target = distance.normalized;
            target.y = 0f;
            transform.localRotation = Quaternion.LookRotation(target);
            speed = Mathf.Min(speed + 0.05f, maxSpeed);
        }
        transform.position += new Vector3(target.x * Time.deltaTime * speed, 0, target.z * Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        //kill the player on collision
        if (collision.collider.name == "player")
        {
            StartCoroutine(death(collision.collider.gameObject));
        }
    }

    [Serializable]
    struct Room
    {
        public float roomNum;
    }
    void OnTriggerEnter(Collider other)
    {
        //if triggered location, send location to the server
/*        WWWForm form = new WWWForm(); */
        int room = 100;
        switch(other.name)
        {
            case "Kitchen" :
            {
                room = 1;
                break;
            }
            case "Dining":
            {
                room = 2;
                break;
            }
            case "Nursery":
            {
                room = 3;
                break;
            }
            case "Closet":
            {
                room = 4;
                break;
            }
            case "SRA":
            {
                room = 5;
                break;
            }
            case "Hallway":
            {
                room = 6;
                break;
            }
            case "SRB":
            {
                room = 7;
                break;
            }
            case "Bathroom":
            {
                room = 8;
                break;
            }
            case "RUC":
            {
                room = 9;
                break;
            }
            case "Bedroom":
            {
                room = 10;
                break;
            }
            case "Lab":
            {
                room = 11;
                break;
            }
            case "Library":
            {
                room = 12;
                break;
            }
            default:
                break;
        }

/*        form.AddField("room_id", room);
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www)); */
        tn.GetAudienceSys().WriteToClients("room", new Room { roomNum = room });
    }

    void OnTriggerExit(Collider other)
    {
        tn.GetAudienceSys().WriteToClients("room", new Room { roomNum = 100 });

        /*
        WWWForm form = new WWWForm();
        form.AddField("room_id", "100");
        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRequest(www)); */
    }

    /*
    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
 
         // check for errors
        if (www.error == null)
        {
            //Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            //Debug.Log("WWW Error: " + www.error);
        }
    }*/

    IEnumerator death(GameObject obj)
    {
        //play death sound (in the future)
        yield return new WaitForSeconds(1);
        Cursor.lockState = CursorLockMode.None;
        Destroy(obj);
        StartCoroutine(loadStartMenu());
    }

    IEnumerator loadStartMenu()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("StartMenu");
    }
}


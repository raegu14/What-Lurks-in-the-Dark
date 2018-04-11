using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    //control movement with wasd keys

    public float walkSpeed;
    public float runSpeed;
    public GameObject cam;

    private AudioSource footsteps;
    private float speed;
    private bool moving;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        speed = walkSpeed;
        footsteps = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if(translation != 0 || straffe != 0)
        {
            if (!moving)
            {
                footsteps.Play();
            }
            moving = true;
        }
        else
        {
            moving = false;
            footsteps.Pause();
        }
 
        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape")) { 
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown("left shift"))
        {
            speed = runSpeed;
        }

        if (Input.GetKeyUp("left shift"))
        {
            speed = walkSpeed;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        print(other);
        if (other.name == "Bedroom")
        {
            cam.GetComponent<playerInteraction>().inBedroom = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        print(other);
        if (other.name == "Bedroom")
        {
            cam.GetComponent<playerInteraction>().inBedroom = false;
        }
    }
}

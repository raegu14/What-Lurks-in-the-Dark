using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //control movement with wasd keys

    //adjustable player stats
    public float walkSpeed;     //walk speed
    public float runSpeed;      //run speed

    //main camera
    public GameObject cam;      //player camera (First Person)

    //dynamic stats
    private float speed;                //current player speed
    private bool moving;                //detect if player is moving
    private AudioSource footsteps;      //walking sound
    private Vector3 rayPos1;
    private Vector3 rayPos2;
    private Vector3 rayPos3;
    private Vector3 rayPos4;

    bool cast1;
    bool cast2;
    bool cast3;
    bool cast4;

    Rigidbody rb;


    // Use this for initialization
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        speed = walkSpeed;
        footsteps = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        rayPos1 = transform.position + GetComponent<CapsuleCollider>().bounds.extents;
        rayPos2 = transform.position - GetComponent<CapsuleCollider>().bounds.extents;
        rayPos3 = new Vector3(rayPos2.x, 0, rayPos1.z);
        rayPos4 = new Vector3(rayPos1.x, 0, rayPos2.z);

        cast1 = false;
        cast2 = false;
        cast3 = false;
        cast4 = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3();

        if (Input.GetKeyDown("left shift"))
        {
            speed = runSpeed;
        }

        if (Input.GetKeyUp("left shift"))
        {
            speed = walkSpeed;
        }

        /* update raycast positions */
        var offset = transform.rotation * GetComponent<CapsuleCollider>().bounds.extents;
        var pos = GetComponent<CapsuleCollider>().bounds.center;
        pos.y = pos.y / 2;
        rayPos1 = pos + offset;
        rayPos2 = pos - offset;
        rayPos1.y = 0;
        rayPos2.y = 0;

        rayPos3 = pos + new Vector3(-offset.z, 0, offset.x);
        rayPos4 = pos + new Vector3(offset.z, 0, -offset.x);

        cast1 = false;
        cast2 = false;
        cast3 = false;
        cast4 = false;

        /* get direction */

        if (Input.GetKey(KeyCode.W))
        {
            movement += new Vector3(0, 0, 1);
            cast1 = true;
            cast3 = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement += new Vector3(0, 0, -1);
            cast2 = true;
            cast4 = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += new Vector3(1, 0, 0);
            cast1 = true;
            cast4 = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movement += new Vector3(-1, 0, 0);
            cast2 = true;
            cast3 = true;
        }

        if (movement.magnitude != 0)
        {
            movement.Normalize();
            movement *= Time.deltaTime * speed;
        }

        /* get rotation in x-z plane */
        var rEuler = transform.rotation.eulerAngles;
        Vector3 direction = Quaternion.Euler(rEuler) * movement;
        direction.Normalize();

        /* check if wall is in the way */
        RaycastHit hit1;
        RaycastHit hit2;
        RaycastHit hit3;
        RaycastHit hit4;

        cast1 &= Physics.Raycast(rayPos1, direction, out hit1, movement.magnitude + 0.3f);
        cast2 &= Physics.Raycast(rayPos2, direction, out hit2, movement.magnitude + 0.3f);
        cast3 &= Physics.Raycast(rayPos3, direction, out hit3, movement.magnitude + 0.3f);
        cast4 &= Physics.Raycast(rayPos4, direction, out hit4, movement.magnitude + 0.3f);

        if (cast1 || cast2 || cast3 || cast4)
        {
            // may check for tags
            if (cast1)
            {
                if(hit1.collider.tag == "Room")
                {
                    Move(movement);
                }
            }

            if (cast2)
            {
                if (hit2.collider.tag == "Room")
                {
                    Move(movement);
                }
            }

            if (cast3)
            {
                if (hit3.collider.tag == "Room")
                {
                    Move(movement);
                }
            }

            if (cast4)
            {
                if (hit4.collider.tag == "Room")
                {
                    Move(movement);
                }
            }
        }
        else
        {
            Move(movement);
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Move(Vector3 movement)
    {
        if (movement.magnitude != 0)
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
            rb.velocity = new Vector3(0, 0);
        }

        transform.Translate(movement);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bedroom")
        {
            cam.GetComponent<playerInteraction>().inBedroom = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Bedroom")
        {
            cam.GetComponent<playerInteraction>().inBedroom = false;
        }
    }
}

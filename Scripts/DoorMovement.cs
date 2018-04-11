using UnityEngine;

public class DoorMovement : MonoBehaviour {

    //opens and closes the door naturally

    public bool open = false;
    public float doorOpenAngle = 90f;
    public float doorCloseAngle = 0f;
    public float smooth = 2f;
    AudioSource doorOpen;
    AudioSource doorClose;

	// Use this for initialization
	void Start () {
        doorOpen = this.gameObject.AddComponent<AudioSource>();
        doorOpen.clip = Resources.Load<AudioClip>("Sounds/doorOpen");
        doorOpen.volume = 0.5f;

        doorClose = this.gameObject.AddComponent<AudioSource>();
        doorClose.clip = Resources.Load<AudioClip>("Sounds/doorClose");
        doorClose.volume = 0.5f;
    }

    public void changeDoorState()
    {
        open = !open;
        if (open)
        {
            doorOpen.Play();
        }
        else
        {
            doorClose.Play();
        }
    }
    // Update is called once per frame
    void Update () {
	    if(open)
        {
            Quaternion targetRot = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRot = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, smooth * Time.deltaTime);
        }
	}
}

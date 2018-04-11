using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerInteraction : MonoBehaviour {

    //set up player interaction with doors and objects using input [e]
    //also sets up win condition using talisman in the bedroom

    //Interactable Objects
    public GameObject note;         //note that player reads at the beginning
    public Talisman tc;     //talismans that player pick up

    //Progress Text
    public Text text;               //updated text to indicate progress to player

    //Player restrictions
    public float interactLength = 10f;   //interactable length

    //Boolean event trackers
    public bool inBedroom;              //detect if player is in bedroom
    private bool exorcise = false;      //check if player can exorise ghost
    private bool noteActive = false;    //check if note is pulled up


	// Use this for initialization
	void Start () {
        note.SetActive(noteActive);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "";
        if (noteActive)
        {
            text.text = "Press [e] to stop reading note";
        }
        if(tc.finished && inBedroom)
        {
            text.text = "Press [e] to exorcise ghost";
            exorcise = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactLength))
            {
                print(hit.collider.tag);
                print(hit.collider.name);
                if (hit.collider.CompareTag("Door"))
                {
                    hit.collider.GetComponent<DoorMovement>().changeDoorState();
                }
                else if (hit.collider.CompareTag("NoteObj"))
                {
                    noteActive = !noteActive;
                    note.SetActive(noteActive);
                }
                else if (hit.collider.CompareTag("TalismanObj"))
                {
                    tc.FindTalisman(hit.collider.gameObject);
                    note.SetActive(noteActive);
                }
                else if (noteActive)
                {
                    noteActive = !noteActive;
                    note.SetActive(noteActive);
                }
            }
            else if (noteActive)
            {
                noteActive = !noteActive;
                note.SetActive(noteActive);
            }

            if (exorcise)
            {
                //cutscene of ghost dying
                SceneManager.LoadScene("Epilogue");
            }
        }
    }
}

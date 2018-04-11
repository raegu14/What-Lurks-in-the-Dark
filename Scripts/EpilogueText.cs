using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EpilogueText : MonoBehaviour {

    //sets up ending text if player manages to exorcise ghost

    public Text text;

    int textNum;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        text.text = "Congratulations! Not only did you survive the night, but you defeated the spirit of the rogue doctor! Now the doctor and his family can rest peacefully, and Samantha is safe. The door unlocks and Samantha doesn’t even bother picking up her equipment, and instead promptly starts her car and leaves. She isn’t sure if she will ever ghost hunt again. For now, she and her team decide to take a break from it and become involved in charity work. In particular, they decide to volunteer to help people with mental illness.";
        textNum = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeText()
    {
        textNum++;

        if (textNum == 1)
        {
            text.text = "As for the house, several realtors attempted to sell it, to no avail.The dark history and general aura of the house deterred dozens of interested buyers.Eventually, an odd fellow by the name of Frederick Allman decided to buy the house and turn it into an occult museum.To this day, people from all over the world come and see various oddities and specimens, as well as to hear the story of one Dr.Vincent Vaturo, who is said to have learned how to separate the spirit from the body, and who is said to still haunt the hallways of the very house that the spectators are standing in. No one knows for sure if the stories are true.";
        }
        else
        {
            SceneManager.LoadScene("StartMenu");
        }
    }
}

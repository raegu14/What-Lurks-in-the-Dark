using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroText : MonoBehaviour {
    //public string text;

    //updates the narrative at the beginning of the game
    public Text text;

    int textNum;

	// Use this for initialization
	void Start () {
        text.text = "“Alone. Yes, that's the key word, the most awful word in the English tongue. Murder doesn't hold a candle to it and hell is only a poor synonym.” \n \n ― Stephen King";
        textNum = 0;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void changeText()
    {
        textNum++;

        if (textNum == 1)
        {
            text.text = "Samantha Price is a scholar and an avid fan of the occult. She spends her free time traveling to allegedly “haunted” locales trying to gather evidence of the paranormal. She sets up cameras and audio equipment, hoping to gather the data she needs to finish her documentary on the paranormal. Aiding her in her endeavor are a handful of friends from across the country who watch the camera footage and update Samantha as events unfold. Despite having friends who are willing to accompany her, Samantha believes that she must hunt alone, as it is believed that ghosts fear crowds, and she also believes that having multiple footsteps and multiple voices can dilute the evidence, thus making it less credible. So, as always, Samantha is all by herself for the investigation.";
        }
        else if(textNum == 2)
        {
            text.text = "Today, she has come to the abandoned Vaturo estate in rural New York. It is the former residence of Dr. Vincent Vaturo, a psychologist who, over time, transitioned into an experimental physicist. His goal was to see if the psyche could be split into its separate parts to be studied.";
        }
        else if(textNum == 3)
        {
            text.text = "Dr. Vaturo, during an experiment gone wrong, is said to have successfully split his psyche, killing him. It is rumored that Dr. Vaturo, who died tragically in the house, now haunts the house as a malicious spirit that seeks to find a new body to possess and continue his research.";
        }
        else if(textNum == 4)
        {
            text.text = "Samantha comes to the house at 7 o’clock PM on August 13th, 2017 to set up her equipment. The house is spacious and well preserved, with everything that Vaturo owned still in the place that it was when he died. Samantha wonders why this is the case. She puts a camera and microphone in each room of the house, double checking each piece of equipment to make sure that it works. At approximately 10:05 PM, Samantha remembers that she has left her own personal camera in her car, and tries to leave the house to go out to her car and quickly discovers that the front door has been sealed shut by a mysterious force.";
        }
        else if(textNum == 5)
        {
            text.text = "Suddenly, a gust of wind rushes through the hallway, and to Samantha’s shock, a spectre appears in the hallway.";
        }
        else if(textNum == 6)
        {
            text.text = "Samantha is frozen. Even her mind has paused, unable to think or to ponder.  The specter slowly wanders toward Samantha, eagerly eyeing her with hunger and lust. It begins to open its maws in an otherworldly yawn-like gesture, eager to devour her. Time has frozen as Samantha’s life flashes before her eyes; her past becomes a whirlwind of memories and distant beauty as the horror of a final present looms before her eyes. The specter of death lowers its face to Samantha’s and begins to inhale, and Samantha begins to feel her spirit lift from her body. She is helpless, lost, and cold.";
        }
        else if(textNum == 7)
        {
            text.text = "Then it happens.";
        }
        else if(textNum == 8)
        {
            text.text = "The sound of an object falling in the sitting room startles the spectre of Vincent Vaturo, and he halts his feast to go investigate. Samantha’s spirit falls back into place, and she regains her senses and strength and promptly runs off into the adjacent room, shutting the door behind her. She finds a letter on the nearby table, and this is where our story begins…";
        }
        else {
            SceneManager.LoadScene("House");
        }
    }
}

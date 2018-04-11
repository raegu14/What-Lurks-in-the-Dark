using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public GameObject instructions;
    private bool instructionsActive = false;

	// Use this for initialization
	void Start () {
        instructions.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if(instructionsActive)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                instructions.SetActive(false);
            }
        }
	}

    public void showInstructions()
    {
        instructions.SetActive(true);
        instructionsActive = true;
    }

    public void loadHouse()
    {
        SceneManager.LoadScene("New Scene");
    }
}

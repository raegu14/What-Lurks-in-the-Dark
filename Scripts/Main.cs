using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public GameObject Talisman;     //talisman object to spawn
    private int numTalismans = 3;   //number of talismans to be spawned
    
	void Awake () {
        //get three positions and spawn the talismans
        GameObject[] talisPos = GameObject.FindGameObjectsWithTag("TalismanPositions");
        for(int i = 0; i < numTalismans; i++)
        {
            int idx = Random.Range(0, talisPos.Length);
            //Instantiate(Talisman, talisPos[idx].transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

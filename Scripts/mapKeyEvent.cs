using UnityEngine;
using System.Collections;

public class mapKeyEvent : MonoBehaviour {

    //pulls up radar 

	public GameObject map;
    public bool manualClose = true;

	// Use this for initialization
	void Start () {
		map = GameObject.FindGameObjectWithTag("map");
        map.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("m")) {
			//Code here to call the same method that pressing Button1 calls
			if (map.activeInHierarchy == true) {
                DisableRadar();
                manualClose = true;
			} else {
                EnableRadar();
			}
		}
	}

    public void EnableRadar()
    {
        map.SetActive(true);
    }

    public void DisableRadar()
    {
        map.SetActive(false);
    }
}

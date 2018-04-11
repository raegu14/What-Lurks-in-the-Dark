using UnityEngine;
using System.Collections;

public class keyEvent : MonoBehaviour {

    //pulls up radar 

	public GameObject map;
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
				map.SetActive (false);
			} else {
				map.SetActive (true);
			}
		}
	}
}

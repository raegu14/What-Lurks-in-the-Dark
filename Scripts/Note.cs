using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    private GameObject cam;
    private Vector3 frontPos;

    public Vector3 rot;

	// Use this for initialization
	void Start () {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        frontPos = new Vector3(1, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Activate()
    {
        transform.position = cam.transform.position + frontPos;
        transform.rotation = Quaternion.Euler(rot);
        // disable movement
        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLight : MonoBehaviour {

    private Light f;
    private bool active;

	// Use this for initialization
	void Start () {
        f = GetComponent<Light>();
        EnableFlashLight();
    }

    // Update is called once per frame
    void Update ()
    {
		if (Input.GetKeyDown(KeyCode.F))
        {
            /*  if(active)
              {
                  DisableFlashLight();
              }

              else
              {
                  EnableFlashLight();
              }*/
            EnableFlashLight();
        }
    }

    void EnableFlashLight()
    {
        f.enabled = true;
        active = true;
    }

    void DisableFlashLight()
    {
        f.enabled = false;
        active = false;
    }

}

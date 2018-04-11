using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riseHand : MonoBehaviour {

    public Animator handAnim;
    private int _risePhone;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("m")) {
            if (_risePhone == 0) {
                handAnim.SetInteger("rise", 1);
                _risePhone = 1;
            }else {
                handAnim.SetInteger("rise", 0);
                _risePhone = 0;
            }
        }
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class makeRadarObject : MonoBehaviour {

    //creates radar

	public Image image;
	// Use this for initialization
	void Start () {
		Radar.RegisterRadarObject (this.gameObject, image);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onDestroy() {
		Radar.RemoveRadarObject (this.gameObject);
	}
}

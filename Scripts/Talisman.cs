using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talisman : MonoBehaviour {

    public int spawnNum;
    public Text counterText;
    //public GameObject talisman;
    public bool finished;

    private GameObject[] talismanPos;
    private int numCollected;

    /* fade 
    public float step;
    private bool fade;
    private Color opaque;
    private Color transparent;
    private float t;
    */

	// Use this for initialization
	void Start () {
        talismanPos = GameObject.FindGameObjectsWithTag("TalismanObj");
        for(int j = 0; j < talismanPos.Length; j++)
        {
            talismanPos[j].SetActive(false);
        }

        int i = 0;
		while (i < spawnNum)
        {
            int idx = Random.Range(0, talismanPos.Length - i);
            talismanPos[idx].SetActive(true);
            var tmp = talismanPos[idx];
            talismanPos[idx] = talismanPos[talismanPos.Length - i - 1];
            talismanPos[talismanPos.Length - i - 1] = tmp;
            i++;
        }

        //t = 0;
        counterText.text = "Talisman: 0/" + spawnNum;
        finished = false;
	}
	
	// Update is called once per frame
	void Update () {
        //if (fade)
        //{
        //    talisman.GetComponent<Image>().color = Color.Lerp(opaque, transparent, t);
        //    t += step;
        //    if(t < 0.05f)
        //    {
        //        fade = false;
        //    }
        //}
	}

    public void FindTalisman(GameObject t)
    {
        t.SetActive(false);
        //talisman.SetActive(true);
        //StartCoroutine(DisplayTalisman());

        numCollected++;
        counterText.text = "Talisman: " + numCollected + "/" + spawnNum;
        if(numCollected == spawnNum)
        {
            finished = true;
        }
    }

    //IEnumerator DisplayTalisman()
    //{
    //    talisman.SetActive(true);
    //    fade = true;
    //    t = 1;
    //    yield return new WaitForSeconds(1f);
    //    talisman.SetActive(false);
    //}
}

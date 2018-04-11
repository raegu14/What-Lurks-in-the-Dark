using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : MonoBehaviour {

    public GameObject[] neighbors;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject[] getNeighbors()
    {
        List<GameObject> validList = new List<GameObject>();
        for(int i = 0; i < neighbors.Length; i++)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, neighbors[i].transform.position - transform.position, out hit, Vector3.Distance(transform.position, neighbors[i].transform.position)))
            {
                if(hit.collider.tag != "Door")
                {
                    //Add to array
                    validList.Add(neighbors[i]);
                }
            }
            else
            {
                validList.Add(neighbors[i]);
            }
        }
        GameObject[] valid = new GameObject[validList.Count];
        validList.CopyTo(valid);
        return valid;
    }

    public GameObject randomNeighbor()
    {
        int rand = Random.Range(0, neighbors.Length);
        return neighbors[rand];
    }
}

using UnityEngine;
using System.Collections;

public class camMouseLook : MonoBehaviour {

    //jerk camera around when ghost is near
    public GameObject ghost;
    private Vector3 offset;

    //look around using mouse movement as input

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 1.0f;
    public float smoothing = 2.0f;

    public float minY;
    public float maxY;

    GameObject character;

	// Use this for initialization
	void Start () {
        character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
         
        transform.localRotation = Quaternion.AngleAxis(ClampY(-mouseLook.y), Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

        transform.position -= offset;

        if((ghost.transform.position - transform.position).magnitude < 10)
        {
            float limit = 1f / (ghost.transform.position - transform.position).magnitude;
            limit *= 0.5f;
            offset = new Vector3(Random.Range(-limit, limit), Random.Range(-limit, limit), Random.Range(-limit, limit));
            transform.position += offset;
        }
        else
        {
            offset = new Vector3();
        }
	}

    float ClampY(float y)
    {
        if(y < minY)
        {
            mouseLook.y = -minY;
            return minY;
        }
        else if (y > maxY)
        {
            mouseLook.y = -maxY;
            return maxY;
        }
        return y;
    }
}

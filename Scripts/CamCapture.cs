using UnityEngine;
using System.Collections;

public class CamCapture : MonoBehaviour
{

    //used to capture the pictures from all cameras except the main (player) camera

    private GameObject[] cameras;

    private float time;
    private int cameraNumber;
    Texture2D imageOverview;
    System.Threading.Thread thread;

    byte[] bytes;

    void Start()
    {
        time = Time.time;
        cameras = GameObject.FindGameObjectsWithTag("Camera");
    }
    
    void Update()
    {
        if (Time.time > time + 3.0f)
        {
            time = Time.time;
          //  for(int i = 0; i < cameras.Length; i++)
            //{
                grabCameraView(cameras[8], 8);
            //}
        }
    }

    private void grabCameraView(GameObject cam, int i)
    {
        StartCoroutine(grabView(cam, i));
        //grabView(obj, i);
    }

    public IEnumerator grabView(GameObject obj, int i)
    {
        //wait for frame end
        yield return new WaitForEndOfFrame();

        Camera cameraView = obj.GetComponent<Camera>();

        //create a texture that stores screenshot information
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = cameraView.targetTexture;
        cameraView.Render();

        //start grabbing screenshot information and render
        imageOverview = new Texture2D(cameraView.targetTexture.width,
                                        cameraView.targetTexture.height,
                                        TextureFormat.RGB24,
                                        false);

        imageOverview.ReadPixels(new Rect(0, 0,
                            cameraView.targetTexture.width,
                            cameraView.targetTexture.height),
                            0, 0);

        imageOverview.Apply();

        RenderTexture.active = currentRT;

        // Encode texture into PNG
        byte[] bytes = imageOverview.EncodeToPNG();


        //TODO: write the png to a path
        string filename = string.Format("{0}/screenshots/screen_{1}_{2}.png",
            Application.dataPath, i, Time.time);
        System.IO.File.WriteAllBytes(filename, bytes);
    }
}

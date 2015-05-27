using UnityEngine;
using System.Collections;

public class RsCameraAspectScript : MonoBehaviour
{
    public float aspectWidth = 19f;
    public float aspectHeight = 9f;

    // Use this for initialization
    void Start()
    {
        Camera camera = GetComponent<Camera>();


        //float t = (float)Screen.height / 3 * 4 / (float)Screen.width;
        //Rect r = new Rect((1 - t) / 2, 0, t, 1);
        //camera.rect = r;
        //return;

        //Matrix4x4 sclmat = Camera.main.projectionMatrix;
        //sclmat[0, 0] = sclmat[1, 1] * 0.75f;
        //Camera.main.projectionMatrix = sclmat;
        //return;

        // set the desired aspect ratio (the values in this example are
        // hard-coded for 16:9, but you could make them into public
        // variables instead so you can set them at design time)
//        float targetaspect = 16.0f / 9.0f;
        float targetaspect = aspectWidth / aspectHeight;

        // determine the game window's current aspect ratio
        float windowaspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleheight = windowaspect / targetaspect;

        // obtain camera component so we can modify its viewport
        //Camera camera = GetComponent<Camera>();

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }

    }

}

using UnityEngine;
using System.Collections;

public class RsFollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 7.5f, 0f);
    public float smoothing = 2.0f;

    void Awake()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void LateUpdate()
    {
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}

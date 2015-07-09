using UnityEngine;
using System.Collections;

public class AirPlaneController : MonoBehaviour
{

    public bool useKeyboard = true;
    /*
    #if UNITY_IPHONE || UNITY_ANDROID || UNITY_BLACKBERRY || UNITY_WP8
        private bool useKeyboard = false;
    #else
        private bool useKeyboard = true;
    #endif 
     */

    public GameObject player;
    public Transform cameraTransform;
    public Transform airPlaneTransform;

    public float speed = 20.0f;
    public float handling = 50.0f;
    public float rotation = 20.0f;
    private float minAcceleratedSpeed = 10.0f;
    public float forwardAcceleratedSpeed;
    public float backwardAcceleratedSpeed;
    private float maxAcceleratedSpeed = 100.0f;

    public float minRoll = -45.0f;
    public float maxRoll = 45.0f;
    public float roll = 10.0f;

    public float cameraRotationX = 25.0f;
    public float cameraOffsetY = 20.0f;
    public float cameraOffsetZ = 20.0f;

    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void FixedUpdate()
    {
        if (Globals.gameStatus == Globals.GameStatus.Pause)
            return;

    }

    public void SetupCamera()
    {

    }

}

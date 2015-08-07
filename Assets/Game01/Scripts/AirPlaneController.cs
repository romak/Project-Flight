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

    public float speed = 10.0f;
    public float handling = 50.0f;
    public float rotation = 20.0f;
    private float minAcceleratedSpeed = 5.0f;
    public float forwardAcceleratedSpeed;
    public float backwardAcceleratedSpeed;
    private float maxAcceleratedSpeed = 100.0f;
    public float handlingAcceleratedSpeed = 10.0f;

    public float minRoll = -50.0f;
    public float maxRoll = 50.0f;
    public float roll = 40.0f;

    public float cameraRotationX = 35;
    public float cameraOffsetY = 10.0f;
    public float cameraOffsetZ = 9.0f;

    private bool moveForward = false;
    private Rigidbody airPlaneRigidBody;

    private EllipsoidParticleEmitter engineParticleEmmiter;

    void Awake()
    {
        airPlaneRigidBody = airPlaneTransform.GetComponent<Rigidbody>();
        engineParticleEmmiter = player.GetComponentInChildren<EllipsoidParticleEmitter>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (Globals.gameStatus == Globals.GameStatus.Pause)
            return;

        if (engineParticleEmmiter != null)
        {
            engineParticleEmmiter.emit = (Globals.gameStatus == Globals.GameStatus.Crashing) ? false : true;
            engineParticleEmmiter.maxEnergy = moveForward ? Random.Range(1.5f, 2.5f) : 1f;
        }
    }

    public void FixedUpdate()
    {
        if (Globals.gameStatus == Globals.GameStatus.Pause)
            return;

        moveForward = false;

        //Camera movement
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y + cameraOffsetY, transform.position.z - cameraOffsetZ);
        cameraTransform.position = targetPosition;
        cameraTransform.localRotation = Quaternion.Euler(cameraRotationX, 0, 0);

        //Left/right aiplane tilt
        airPlaneTransform.eulerAngles = new Vector3(airPlaneTransform.eulerAngles.x,
                                                     airPlaneTransform.eulerAngles.y,
                                                     Mathf.Clamp(-(airPlaneRigidBody.velocity.x * Time.deltaTime * roll) * 5.0f, minRoll, maxRoll));

        if (Input.GetKey(KeyCode.LeftArrow))
            MoveLeft();

        if (Input.GetKey(KeyCode.RightArrow))
            MoveRight();

        if (Input.GetKey(KeyCode.UpArrow))
            MoveForward();

        airPlaneRigidBody.AddForce(Vector3.forward * minAcceleratedSpeed);

    }

    public void MoveForward()
    {
        moveForward = true;

        forwardAcceleratedSpeed += forwardAcceleratedSpeed * Time.deltaTime;
        //Check Max acceleration
        if (forwardAcceleratedSpeed <= maxAcceleratedSpeed)
            airPlaneRigidBody.AddForce(Vector3.forward * (speed + forwardAcceleratedSpeed));
        else
            airPlaneRigidBody.AddForce(Vector3.forward * maxAcceleratedSpeed);

    }

    public void MoveBack()
    {
        backwardAcceleratedSpeed += backwardAcceleratedSpeed * Time.deltaTime;

        if (backwardAcceleratedSpeed <= maxAcceleratedSpeed)
            airPlaneRigidBody.AddForce(Vector3.back * (speed + backwardAcceleratedSpeed));
        else
            airPlaneRigidBody.AddForce(Vector3.back * maxAcceleratedSpeed);

    }

    public void MoveLeft()
    {
        airPlaneRigidBody.AddForce(Vector3.left * handlingAcceleratedSpeed);

    }

    public void MoveRight()
    {
        airPlaneRigidBody.AddForce(Vector3.right * handlingAcceleratedSpeed);
    }


    public void SetupCamera()
    {

    }

}

using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class RsPlayerMovement : MonoBehaviour
{
    public RsPlayer player;
    public Text speedText;
    public Text positionText;

    public float speed = 1.5f;
    public float maxSpeed = 1.5f;
    public float turnSpeed = 1.7f;
    public float forwardSpeed = 1.5f;
    public float upSpeed = 2.0f;
    public float downSpeed = 1.0f;
    public Vector3 cameraPosSpeedUp = new Vector3(0f, 2.5f, -1f);

    float backSpeed;
    public float maxUp = 10f;
    //    bool stopped = false;

    public RsTouchPad touchPadLeft;
    public RsTouchPad touchPadRight;

    Vector3 forwardOffset = new Vector3(0, 0, 1f);
    Vector3 upOffset = new Vector3(0, 1f, 0);
    Vector3 downOffset = new Vector3(0, -1f, 0);

    Animator animator;
    int leftHash, rightHash, upHash, downHash;

    Transform playerTransform;
    RsPlayerHealth playerHealth;

    RsFollowTarget followScript;
    Vector3 oldCcameraPos;


    bool lockedInput;


    void Awake()
    {
        backSpeed = speed / 2;
        lockedInput = false;
        playerHealth = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<RsPlayerHealth>();
        followScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RsFollowTarget>();
        oldCcameraPos = followScript.offset;

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<RsPlayer>();
    }

    void Start()
    {
        animator = player.GetComponent<Animator>();
        if (animator == null)
            Debug.Log("Cannot find 'Animator' component");

        leftHash = Animator.StringToHash("MoveLeft");
        rightHash = Animator.StringToHash("MoveRight");
        upHash = Animator.StringToHash("MoveUp");
        downHash = Animator.StringToHash("MoveDown");

        playerTransform = player.transform;
    }

    public void LockInput()
    {
        lockedInput = true;
    }

    public void UnLockInput()
    {
        lockedInput = false;
    }

    public void MoveLeft()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if ((stateInfo.fullPathHash != leftHash))
        {
            playerTransform.position = new Vector3((playerTransform.position.x - turnSpeed * Time.deltaTime), playerTransform.position.y, playerTransform.position.z);
            animator.SetBool("MoveLeft", true);
        }
    }

    public void MoveRight()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if ((stateInfo.fullPathHash != rightHash))
        {
            playerTransform.position = new Vector3((playerTransform.position.x + turnSpeed * Time.deltaTime), playerTransform.position.y, playerTransform.position.z);
            animator.SetBool("MoveRight", true);
        }
    }

    public void MoveForward()
    {
        Vector3 newPos = playerTransform.position + forwardOffset;
        playerTransform.position = Vector3.Lerp(playerTransform.position, newPos, forwardSpeed * Time.deltaTime);
        followScript.offset = cameraPosSpeedUp;
    }

    public void MoveBack()
    {
        speed = backSpeed;
    }

    public void MoveUp()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if ((stateInfo.fullPathHash != upHash))
        {
            Vector3 newPos = playerTransform.position + upOffset;
            newPos = new Vector3(newPos.x, Mathf.Clamp(newPos.y, 0f, maxUp), newPos.z);
            playerTransform.position = Vector3.Lerp(playerTransform.position, newPos, upSpeed * Time.deltaTime);
            animator.SetBool("MoveUp", true);
        }
    }

    public void MoveDown()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if ((stateInfo.fullPathHash != downHash))
        {
            Vector3 newPos = playerTransform.position + downOffset;
            newPos = new Vector3(newPos.x, Mathf.Clamp(newPos.y, 0f, newPos.y), newPos.z);
            playerTransform.position = Vector3.Lerp(playerTransform.position, newPos, downSpeed * Time.deltaTime);
            animator.SetBool("MoveDown", true);
        }
    }

    void Update()
    {
        if (speedText != null)
            speedText.text = speed.ToString();

        if (positionText != null)
            positionText.text = playerTransform.position.ToString();

        followScript.offset = oldCcameraPos;

    }

    public void SetIdleAnimation()
    {
        animator.SetBool("MoveLeft", false);
        animator.SetBool("MoveRight", false);
        animator.SetBool("MoveUp", false);
        animator.SetBool("MoveDown", false);
    }

    void ProcessInput()
    {

        if (playerHealth.IsDeath() || lockedInput)
            return;

        if (touchPadLeft.IsTouched())
            MoveLeft();

        if (touchPadRight.IsTouched())
            MoveRight();

/*
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                //MoveLeft();
            }

            if (touch.position.x > Screen.width / 2)
            {
                //MoveRight();
            }
        }
*/
        if (Input.GetKey("left"))
            MoveLeft();

        if (Input.GetKey("right"))
            MoveRight();

        if (Input.GetKey("up"))
            MoveForward();

        if (Input.GetKey("down"))
            MoveBack();

        if (Input.GetKey("q"))
            MoveUp();

        if (Input.GetKey("a"))
            MoveDown();

    }

    void FixedUpdate()
    {

        followScript.offset = oldCcameraPos;
        SetIdleAnimation();

        if (!playerHealth.IsDeath())
        {
            ProcessInput();

            playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, (playerTransform.position.z + speed * Time.deltaTime));
            if (speed < maxSpeed)
            {
                speed = Mathf.Lerp(speed, maxSpeed, 10 * Time.deltaTime);
            }
        }
    }

}

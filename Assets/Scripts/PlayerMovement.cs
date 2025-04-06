using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    private float verticalRotation = 0f;
    private Transform cameraTransform;

    // Ground Movement
    private Rigidbody rb;
    public float MoveSpeed = 5f;
    private float moveHorizontal;
    private float moveForward;

    // Jumping
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f;
    public float ascendMultiplier = 2f;
    private bool isGrounded = true;
    public LayerMask groundLayer;
    private float groundCheckTimer = 0f;
    private float groundCheckDelay = 0.3f;
    private float playerHeight;
    private float raycastDistance;

    public CounterManager counterManager;

    // Animator
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        cameraTransform = Camera.main.transform;

        animator = GetComponent<Animator>();

        playerHeight = GetComponent<CapsuleCollider>().height * transform.localScale.y;
        raycastDistance = (playerHeight / 2) + 0.2f;

        // Make cursor visible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveForward = Input.GetAxisRaw("Vertical");

        RotateCamera();

        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    Jump();
        //}

        // Ground check
        if (!isGrounded && groundCheckTimer <= 0f)
        {
            Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;
            isGrounded = Physics.Raycast(rayOrigin, Vector3.down, raycastDistance, groundLayer);
        }
        else
        {
            groundCheckTimer -= Time.deltaTime;
        }

        // Set IsRunning animation
        bool isMoving = moveHorizontal != 0 || moveForward != 0;
        animator.SetBool("IsRunning", isMoving);
        if(isMoving && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if(!isMoving && Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
        ApplyJumpPhysics();
    }

    public float upwardForce = 10f;
    public bool rightTime = false;

    public void SetRightTime(bool value)
    {
        rightTime = value;
    }

    private bool once = false;
    void MovePlayer()
    {
        if (!gameObject.CompareTag("Dead"))
        {
            Vector3 movement = (transform.right * moveHorizontal + transform.forward * moveForward).normalized;
            Vector3 targetlinearVelocity = movement * MoveSpeed;

            Vector3 linearVelocity = rb.linearVelocity;
            linearVelocity.x = targetlinearVelocity.x;
            linearVelocity.z = targetlinearVelocity.z;
            rb.linearVelocity = linearVelocity;

            if (isGrounded && moveHorizontal == 0 && moveForward == 0)
            {
                rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
            }
        }
        else if(rightTime)
        {
            rb.linearVelocity = new Vector3 (0, upwardForce, 0);
            if (!once)
            {
                once = true;
                StartCoroutine(StartEnd());
            }
        }
    }

    IEnumerator StartEnd()
    {
        yield return new WaitForSeconds(3);
        rightTime = false;
        animator.SetTrigger("StartEnd");
        counterManager.SaveTime();
    }

    void RotateCamera()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    //void Jump()
    //{
    //    isGrounded = false;
    //    groundCheckTimer = groundCheckDelay;
    //    rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
    //}

    void ApplyJumpPhysics()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.fixedDeltaTime;
        }
        else if (rb.linearVelocity.y > 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * ascendMultiplier * Time.fixedDeltaTime;
        }
    }
}

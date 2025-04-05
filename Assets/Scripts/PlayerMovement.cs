using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 720f;

    private Rigidbody rb;
    private Vector3 move;
    private Quaternion toRotation;
    private Animator animator;
    private bool isRunning = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        isRunning = false;
    }

    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        var moveDir = new Vector3(h, 0, v).normalized;
        if (moveDir.magnitude >= 0.1f)
        {
            if (!isRunning)
            {
                animator.SetBool("run", true);
                isRunning = true;
            }
            
            move = moveSpeed * Time.deltaTime * moveDir;
            toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
        }
        else
        {
            isRunning = false;
            animator.SetBool("run", false);
            move = Vector3.zero;
        }
    }

    void FixedUpdate()
    {      
        rb.MovePosition(rb.position + move);
        //rb.linearVelocity = move;
        toRotation = Quaternion.Normalize(toRotation);
        rb.rotation = Quaternion.RotateTowards(rb.rotation, toRotation, turnSpeed * Time.fixedDeltaTime);
    }
}

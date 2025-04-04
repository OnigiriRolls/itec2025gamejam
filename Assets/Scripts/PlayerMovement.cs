using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 720f;

    private Rigidbody rb;
    private Vector3 move;
    private Quaternion toRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        var moveDir = new Vector3(h, 0, v).normalized;
        if (moveDir.magnitude >= 0.1f)
        {
            move = moveSpeed * Time.deltaTime * moveDir;
            toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
        }
    }

    void FixedUpdate()
    {      
        rb.MovePosition(rb.position + move);
        toRotation = Quaternion.Normalize(toRotation);
        rb.rotation = Quaternion.RotateTowards(rb.rotation, toRotation, turnSpeed * Time.fixedDeltaTime);
    }
}

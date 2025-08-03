using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementZS : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GroundCheck();
        Move();
        Jump();
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal"); // A-D
        float moveZ = Input.GetAxis("Vertical");   // W-S

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        Vector3 velocity = move * currentSpeed;
        velocity.y = rb.linearVelocity.y; // y ekseni bozulmasın
        rb.linearVelocity = velocity;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }
}

using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Rigidbody2D rb=>GetComponent<Rigidbody2D>();
    private float inputAxis;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Vector2 velocity;
    [SerializeField] private Transform grondCheck;
    [SerializeField] LayerMask groundLayer;

    private bool isGrounded=>Physics2D.OverlapCircle(grondCheck.position, .2f, groundLayer); 

    private void Update()
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity = new(inputAxis * speed, rb.velocity.y);
        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
            rb.velocity = new(rb.velocity.x, jumpForce);
        }
        if(rb.velocity.x> 0f)//right
        {
            transform.eulerAngles= Vector3.zero;
        }
        else if (rb.velocity.x < 0)//left
        {
            transform.eulerAngles = new(0,180,0);
        }
        else//idle
        {

        }
    }
    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }
    
}

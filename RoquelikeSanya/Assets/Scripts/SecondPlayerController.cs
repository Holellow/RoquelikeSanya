using UnityEngine;


public class SecondPlayerController : MonoBehaviour
{
    [SerializeField] private Vector2 v2Direction;
    
    [SerializeField] private float jumpGravity;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float jumpHeight = 15.0f;
    [SerializeField] private float jumpPressedTime;
    [SerializeField] private float jumpRememberer;
    [SerializeField] private float groundRememberer;
    [SerializeField] private float groundRemembererTime;
    
    [SerializeField] private float direction = 1;
    
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isFacingRight = true;
    
    public Transform groundCheck;
    
    public LayerMask whatIsGround;

    public float groundCheckRadius;

    public bool isActive;
        
    private Rigidbody2D _rigidbody;
    
    private bool _jumpedOnce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        Grounded();
    }
    
    void Update()
    {
        if (isActive)
        {
            CheckInput();
            CheckMovementDirection();
        }
    }
    
    private void CheckMovementDirection()
    {
        if(isFacingRight && direction < 0)
        {
            Flip();
        }
        else if(!isFacingRight && direction > 0)
        {
            Flip();
        }
    }
    private void Flip()
    {
        direction *= -1;
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    
    private void CheckInput()
    {
        direction = Input.GetAxisRaw("Horizontal");
        
        jumpRememberer -= Time.deltaTime;
        
        if (Input.GetKeyUp(KeyCode.Space) )
        {
            if (_rigidbody.velocity.y > 0)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * jumpGravity);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            jumpRememberer = jumpPressedTime;
        }

        if (jumpRememberer > 0 && groundRememberer > 0 && !_jumpedOnce)
        {
            _jumpedOnce = true;
            jumpRememberer = 0;
            groundRememberer = 0;
            
            Jump();
        }
         
        if (Input.GetButton("Horizontal")) 
        {
            Run();
        }
    }
    
    private void Jump()
    {
        _rigidbody.velocity = Vector2.up * jumpHeight;
    }
    private void Run()
    {
        v2Direction.x = direction;
        _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, _rigidbody.position + v2Direction, speed * Time.deltaTime);
            
    }
    
    private void Grounded()
    {
       
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius,whatIsGround);
        if (isGrounded)
        {
            groundRememberer = groundRemembererTime;
            _jumpedOnce = false;
        }
        else
        {
            groundRememberer -= Time.deltaTime;
        }
           
    }
}

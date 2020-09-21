using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerUnit : MonoBehaviour
{
    [SerializeField] protected Vector2 v2Direction;
    
    [SerializeField] protected float jumpGravity;
    [SerializeField] protected float speed = 3.0f;
    [SerializeField] protected float jumpHeight = 15.0f;
    [SerializeField] protected float jumpPressedTime;
    [SerializeField] protected float jumpRememberer;
    [SerializeField] protected float groundRememberer;
    [SerializeField] protected float groundRemembererTime;
    
    [SerializeField] protected float direction = 1;
    
    [SerializeField] protected bool isGrounded;
    [SerializeField] protected bool isFacingRight = true;
    
    [SerializeField] protected Transform groundCheck;
    
    [SerializeField] protected LayerMask whatIsGround;

    [SerializeField] protected float groundCheckRadius;

    public bool isActive { set; get; }
        
    [SerializeField] protected Rigidbody2D _rigidbody;
    
    [SerializeField] protected bool _jumpedOnce;

    private protected void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private protected void FixedUpdate()
    {
       
    }
    
    void Update()
    {
        if (isActive)
        {
            CheckInput();
            CheckMovementDirection();
            Grounded();     
        }
    }

     protected virtual void CheckInput()
    {
        
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
    
    protected void Run()
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
        }
        else
        {
            groundRememberer -= Time.deltaTime;
        }
           
    }
}

using UnityEngine;

public class JumpScript : MonoBehaviour
{
    [SerializeField] private IsGrounded _isGrounded;
    
    [SerializeField] private int realJumps;
    [SerializeField] private float jumpHeight;

    [SerializeField] private int jumps;
    
    private float direction = 1;
   
    private Rigidbody2D _rigidbody2D;
    
    private bool jumpedOnce;
    private bool startJump;
        
    private void Awake()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        jumps = realJumps;
    }

    private void Jump()                             
    {                                                 
        jumpedOnce = true;
        _rigidbody2D.velocity = Vector2.up * jumpHeight;
    }

    private void Update()
    {
        if (!_isGrounded.isGrounded && startJump)
        {
            startJump = false;
        }
        
        if (_isGrounded.isGrounded && jumps == 0 && jumpedOnce && !startJump)
        {
            jumpedOnce = false;
            jumps = realJumps;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0)
        {
            if (jumps > 0)
            {
                startJump = true;
                Jump();
                jumps--;
            }
        }
    }
}

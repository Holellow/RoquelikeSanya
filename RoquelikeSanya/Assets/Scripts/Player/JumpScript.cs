using Player;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    [SerializeField] private IsGrounded isGrounded;
    
    [SerializeField] private int realJumps;
    [SerializeField] private float jumpHeight;

    [SerializeField] private int jumps;
    
    private Rigidbody2D _rigidbody2D;
    
    private bool _jumpedOnce;
    private bool _startJump;
        
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
        _jumpedOnce = true;
        _rigidbody2D.AddForce( new Vector2(0,jumpHeight)) ;
    }

    private void Update()
    {
        if (!isGrounded.isGrounded && _startJump)
        {
            _startJump = false;
        }
        
        if (isGrounded.isGrounded && jumps == 0 && _jumpedOnce && !_startJump || isGrounded.isGrounded && jumps == 1 && _jumpedOnce && !_startJump)
        {
            _jumpedOnce = false;
            jumps = realJumps;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0)
        {
            if (jumps > 0)
            {
                _startJump = true;
                Jump();
                jumps--;
            }
        }
    }
}

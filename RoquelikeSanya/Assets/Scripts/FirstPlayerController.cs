using System;
using UnityEngine;


public class FirstPlayerController : PlayerUnit
{
    [SerializeField] private int jumps;

    public int realJumps;

    private void Start()
    {
        isActive = true;
    }

    private override protected void CheckInput()
    {
        
        if (Input.GetKeyUp(KeyCode.Space) )
        {
            if (_rigidbody.velocity.y > 0)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * jumpGravity);
            }
        }
        
        direction = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space) && realJumps > 0)
        {
            if (realJumps > 0)
            {
                Jump();
                realJumps--;
            }
            
        }
        
        if (realJumps == 0 && isGrounded || isGrounded)
        {
            realJumps = jumps;
        }
        
        if (Input.GetButton("Horizontal")) 
        {
            Run();
        }
        
    }
}

using UnityEngine;


public class SecondPlayerController : PlayerUnit
{
    private protected override void CheckInput()
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

}

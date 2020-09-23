using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerUnit : MonoBehaviour
{
    [SerializeField] protected Vector3 v3Direction;
    
    [SerializeField] protected float speed = 3.0f;
   
    [SerializeField] protected float direction = 1;
    
    [SerializeField] protected bool isFacingRight = true;
    
    [SerializeField] protected Rigidbody2D _rigidbody;
    
    [SerializeField] protected bool _jumpedOnce;
    
    public bool isActive { set; get; }

    protected Vector2 force;
    
    protected float xforce;
    private protected void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        CheckVelocity();
        if (isActive)
        {
            CheckInput();
            CheckMovementDirection();
        }
    }

     protected virtual void CheckInput()
    {
        
    }

     protected void CheckVelocity()
     {
         if (_rigidbody.velocity.x > 7 )
         {
             _rigidbody.velocity = new Vector2(7,_rigidbody.velocity.y);
         }
         if (_rigidbody.velocity.x < -7 )
         {
             _rigidbody.velocity = new Vector2(-7,_rigidbody.velocity.y);
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
    
    protected void Run()
    {
        var transform1 = transform;
        var localPosition = transform1.localPosition;
        
        v3Direction.x = direction;
        xforce = (speed * Time.deltaTime * direction);
        force = new Vector2(xforce,0);
        
        _rigidbody.AddForce(force);
        /*transform.localPosition = Vector2.MoveTowards(localPosition, 
            localPosition + v3Direction,
            Time.deltaTime * speed);*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            collision.collider.transform.SetParent(transform);
            
            if (collision.gameObject != collision.collider.gameObject.transform)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            transform.parent = null;
        }
    }
}

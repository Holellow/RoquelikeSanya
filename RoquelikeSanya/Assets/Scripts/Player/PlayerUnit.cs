using System;
using UnityEngine;

namespace Player
{
    public abstract class PlayerUnit : MonoBehaviour
    {
        [SerializeField] protected float speed = 3.0f;
    
        [SerializeField] private float maxVelocity;
   
        [SerializeField] protected float direction = 1;
    
        [SerializeField] protected bool isFacingRight = true;
    
        [SerializeField] protected Rigidbody2D _rigidbody;

        private float _velocity;

        public float Velocity
        {
            get => _velocity;
            set => _velocity = value;
        }

        public float MaxVelocity
        {
            get => maxVelocity;
            set => maxVelocity = value;
        }
        public bool isActive { set; get; }

        protected Vector2 force;
    
        protected float xforce;
        private protected void Awake()
        {
            _velocity = maxVelocity;
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
            if (_rigidbody.velocity.x > _velocity)
            {
                _rigidbody.velocity = new Vector2(_velocity,_rigidbody.velocity.y);
            }
            if (_rigidbody.velocity.x < -_velocity )
            {
                _rigidbody.velocity = new Vector2(-_velocity,_rigidbody.velocity.y);
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
            xforce = speed * Time.deltaTime * direction;
            force = new Vector2(xforce,0);
        
            _rigidbody.AddForce(force);
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
}

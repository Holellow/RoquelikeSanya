using UnityEngine;

namespace Player
{
    public abstract class PlayerUnit : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D _rigidbody;
        
        [SerializeField] protected float speed = 3.0f;
        
        [SerializeField] protected float direction = 1;
    
        [SerializeField] protected bool isFacingRight = true;

        [SerializeField] private float maxVelocity;
        
        private Vector2 _force;
        
        private float _velocity;
        private float _xforce;
        
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
        
        public bool IsActive { set; get; }
        
        private protected void Awake()
        {
            _velocity = maxVelocity;
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        void Update()
        {
            CheckVelocity();
        
            if (IsActive)
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
            if(isFacingRight && direction < 0 || !isFacingRight && direction > 0)
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
            _xforce = speed * Time.deltaTime * direction;
            _force = new Vector2(_xforce,0);

            _rigidbody.AddForce(_force);
        }
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<MovingPlatform>() != null)
            {
                collision.collider.transform.SetParent(transform);
            }
        }
    
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<MovingPlatform>() != null)
            {
                transform.parent = null;
            }
        }
    }
}

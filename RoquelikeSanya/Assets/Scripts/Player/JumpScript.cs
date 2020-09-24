using UnityEngine;

namespace Player
{
    public class JumpScript : MonoBehaviour
    {
        [SerializeField] private IsGrounded _isGrounded;
    
        [SerializeField] private int _realJumps;
        [SerializeField] private int _jumps;
        
        [SerializeField] private float _jumpHeight;
        
        private Rigidbody2D _rigidbody2D;
    
        private bool _jumpedOnce;
        private bool _startJump;
        
        private void Awake()
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _jumps = _realJumps;
        }

        private void Jump()                             
        {                                                 
            _jumpedOnce = true;
            _rigidbody2D.velocity = new Vector3 (_rigidbody2D.velocity.x,0,0);
            _rigidbody2D.AddForce( new Vector2(0,_jumpHeight)) ;
        }

        private void Update()
        {
            if (!_isGrounded.isGrounded && _startJump)
            {
                _startJump = false;
            }
        
            if (_isGrounded.isGrounded && _jumps == 0 && _jumpedOnce && !_startJump || _isGrounded.isGrounded && _jumps == 1 && _jumpedOnce && !_startJump)
            {
                _jumpedOnce = false;
                _jumps = _realJumps;
            }
        
            if (Input.GetKeyDown(KeyCode.Space) && _jumps > 0)
            {
                if (_jumps > 0)
                {
                    _startJump = true;
                    Jump();
                    _jumps--;
                }
            }
        }
    }
}

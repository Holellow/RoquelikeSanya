using UnityEngine;

namespace Player
{
    public class IsGrounded : MonoBehaviour
    {
       // [SerializeField] protected float groundRememberer;   
       
        [SerializeField] protected float groundRemembererTime;   
        [SerializeField] protected LayerMask whatIsGround;   
                                                     
        [SerializeField] protected float groundCheckRadius;  
        public bool isGrounded { get; set; }
    
        [SerializeField] protected Transform groundCheck;

        public void Update()
        {
            Grounded();
        }

        private void Grounded()                                                                                  
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius,whatIsGround);
            /*if (isGrounded)                                                                                      
            {                                                                                                    
                groundRememberer = groundRemembererTime;                                                         
            }                                                                                                    
            else                                                                                                 
            {                                                                                                    
                groundRememberer -= Time.deltaTime;                                                              
            }*/
        }                                                                                                        
    }
}

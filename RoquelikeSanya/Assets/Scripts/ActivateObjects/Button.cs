using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace ActivateObjects
{
    public class Button : MonoBehaviour
    {
        [SerializeField] private bool isPressed;
        
        [SerializeField] private UnityEvent activeEvent;
        [SerializeField] private UnityEvent disactivateEvent;
        
        private Animator _animator;
    
        private static readonly int IsPressed = Animator.StringToHash("isPressed");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !isPressed || other.CompareTag("Box") && !isPressed)
            {
                isPressed = true;
                _animator.SetBool(IsPressed, true);
                Active();
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player") && isPressed || other.CompareTag("Box") && isPressed)
            {
                isPressed = false;
                _animator.SetBool(IsPressed, false);
                
                disactivateEvent.Invoke();
            }
        }
        
        private void Active()
        {
            activeEvent.Invoke();
        }

        private void Disactivate()
        {
            disactivateEvent.Invoke();
        }
    }
}

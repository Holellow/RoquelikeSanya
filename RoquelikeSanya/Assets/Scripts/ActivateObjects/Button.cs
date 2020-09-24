using Player;
using UnityEngine;
using UnityEngine.Events;

namespace ActivateObjects
{
    public class Button : MonoBehaviour
    {
        [SerializeField] private bool _isPressed;
        
        [SerializeField] private UnityEvent _activeEvent;
        [SerializeField] private UnityEvent _disactivateEvent;
        
        private Animator _animator;
    
        private static readonly int IsPressed = Animator.StringToHash("isPressed");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((other.gameObject.GetComponent<PlayerUnit>() == null || _isPressed) &&
                (other.gameObject.GetComponent<Box>() == null || _isPressed)) return;
            _isPressed = true;
            _animator.SetBool(IsPressed, true);
            Active();
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if ((other.gameObject.GetComponent<PlayerUnit>() != null || !_isPressed) &&
                (other.gameObject.GetComponent<Box>() != null || !_isPressed)) return;
            _isPressed = false;
            _animator.SetBool(IsPressed, false);
                
            _disactivateEvent.Invoke();
        }

        private void Active()
        {
            _activeEvent.Invoke();
        }

        private void Disactivate()
        {
            _disactivateEvent.Invoke();
        }
    }
}

using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Door door;

    private Animator _animator;
    
    private static readonly int IsPressed = Animator.StringToHash("isPressed");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("asdsad");
            _animator.SetBool(IsPressed, true);
        }
        Active();
    }

    private void Active()
    {
        door.Active();
    }
}

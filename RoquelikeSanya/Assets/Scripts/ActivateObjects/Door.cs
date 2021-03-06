﻿using UnityEngine;

namespace ActivateObjects
{
    public class Door : MonoBehaviour
    {
        private Animator _animator;

        private static readonly int IsOpen = Animator.StringToHash("isOpen");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Active()
        {
            GetComponent<Collider2D>().enabled = false;
            _animator.SetBool(IsOpen,true);
        }

        public void Disactivate()
        { 
            GetComponent<Collider2D>().enabled = true;
            _animator.SetBool(IsOpen,false);
        }
    }
}

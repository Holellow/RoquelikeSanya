using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Box : MonoBehaviour
{
   [SerializeField] private Rigidbody2D _rigidbody2D;
   [SerializeField] private Collider2D _collider2D;
   [SerializeField] private Collision2D _collision2D;
   
   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.contactCount == 1 || other.contactCount == 0)
      {
         _rigidbody2D.constraints = RigidbodyConstraints2D.None;
      }
      else
      {
         if (other.gameObject.name != "BigPlayer")
         {
            Debug.Log("sasa");
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
         }
         else
         {
            _rigidbody2D.constraints = RigidbodyConstraints2D.None;
         }
      }
   }

   
   /*private void OnCollisionExit2D(Collision2D other)
   {
      if (other.gameObject.name == "BigPlayer")
      {
         _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
      }
   }*/
   
   private void Update()
   {
      
   }
}

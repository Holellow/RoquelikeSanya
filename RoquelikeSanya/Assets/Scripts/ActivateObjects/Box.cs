using Player;
using UnityEngine;

namespace ActivateObjects
{
   public class Box : MonoBehaviour
   {
      [SerializeField] private Rigidbody2D _rigidbody2D;
   
      private void OnCollisionEnter2D(Collision2D other)
      {
         SecondPlayerController secondPlayerController = other.gameObject.GetComponent<SecondPlayerController>();
         _rigidbody2D.constraints = other.contactCount == 0 || other.contactCount == 1 || secondPlayerController != null ? RigidbodyConstraints2D.None : RigidbodyConstraints2D.FreezeAll;
      }

      private void OnCollisionExit(Collision other)
      {
         if (other.contactCount == 1 || other.contactCount == 0)
         {
            _rigidbody2D.constraints = RigidbodyConstraints2D.None;
         }
      }
   }
}

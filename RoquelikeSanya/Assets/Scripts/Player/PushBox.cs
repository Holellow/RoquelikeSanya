using ActivateObjects;
using UnityEngine;

namespace Player
{
    public class PushBox : MonoBehaviour
    {
        public LayerMask boxMask;
    
        public float distance = 1f;

        private GameObject _box;
    
        void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                var transform1 = transform;
                
                Physics2D.queriesStartInColliders = false;

                RaycastHit2D hit = Physics2D.Raycast(transform1.position, 
                    Vector2.right * transform1.localScale.x, 
                    distance, boxMask);
       
                if (hit.collider.gameObject.TryGetComponent<Box>(out _))
                {
                    _box = hit.collider.gameObject;

                    _box.GetComponent<FixedJoint2D>().enabled = true;
                    _box.GetComponent<FixedJoint2D>().connectedBody = gameObject.GetComponent<Rigidbody2D>();

                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    _box.GetComponent<FixedJoint2D>().enabled = false;
                }
            }
        }
        private void OnDrawGizmos()
        {
            var transform1 = transform;
            var position = transform1.position;
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(position, (Vector2) position +
                                                distance * transform1.localScale.x *
                                                Vector2.right);
        }
    }
}

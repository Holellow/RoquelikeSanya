using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    public LayerMask boxMask;
    
    public float distance = 1f;

    private GameObject _box;

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Physics2D.queriesStartInColliders = false;
        
            RaycastHit2D hit = Physics2D.Raycast(transform.position, 
                Vector2.right * transform.localScale.x, 
                distance, boxMask);
       
            if (hit.collider != null  && hit.collider.gameObject.CompareTag("Box"))
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2) transform.position +
            distance * transform.localScale.x *
            Vector2.right);
    }
}

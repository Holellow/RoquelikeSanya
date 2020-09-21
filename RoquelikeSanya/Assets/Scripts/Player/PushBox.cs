using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    public LayerMask boxMask;
    
    public float distance = 1f;

    private GameObject box;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
       RaycastHit2D hit = Physics2D.Raycast(transform.position, 
            Vector2.right * transform.localScale.x, 
            distance, boxMask);
       
       /*if (hit.collider.gameObject.CompareTag("Ground"))
       {
           Debug.Log("adasdsad");
       }
       
       if (hit.collider != null && Input.GetKeyDown(KeyCode.E) && hit.collider.gameObject.CompareTag("Ground"))
       {
           box = hit.collider.gameObject;

           box.GetComponent<FixedJoint2D>().enabled = true;
           box.GetComponent<FixedJoint2D>().connectedBody = gameObject.GetComponent<Rigidbody2D>();

       }*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2) transform.position +
            distance * transform.localScale.x *
            Vector2.right);
        
    }
}

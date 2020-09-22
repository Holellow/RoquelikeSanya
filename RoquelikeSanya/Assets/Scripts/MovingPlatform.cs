using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform pos1, pos2;
    
    [SerializeField] private Transform startPos;
    
    [SerializeField] private float platformSpeed;

    private Vector3 _nextPos;

    public bool IsActive { get; set; } = true;
    void Start()
    {
        _nextPos = startPos.position;    
    }

    void FixedUpdate()
    {
        if (IsActive){
            if (transform.position == pos1.position)
            {
                _nextPos = pos2.position;
            }

            if (transform.position == pos2.position)
            {
                _nextPos = pos1.position;
            }

            transform.position = Vector3.MoveTowards(transform.position, _nextPos, platformSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
    
    
}
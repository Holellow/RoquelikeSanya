using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularPlatformScript : MonoBehaviour
{
    [SerializeField] private float RotateSpeed = 5f;
    [SerializeField] private float Radius = 0.1f;
 
    private Vector2 _centre;
    private float _angle;
 
    private void Start()
    {
        _centre = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
    private void Update()
    {
 
        _angle += RotateSpeed * Time.deltaTime;
 
        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
    }
}

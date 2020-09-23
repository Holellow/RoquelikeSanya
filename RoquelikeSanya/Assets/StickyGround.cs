using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class StickyGround : MonoBehaviour
{
    private PlayerUnit _playerUnit;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerUnit = other.gameObject.GetComponent<PlayerUnit>();
            _playerUnit.Velocity /= 2;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerUnit = other.gameObject.GetComponent<PlayerUnit>();
            _playerUnit.Velocity = _playerUnit.MaxVelocity;
        }
    }
}

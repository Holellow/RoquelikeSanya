using System;
using Player;
using UnityEngine;

public class FirstPlayerController : PlayerUnit
{
    private void Start()
    {
        isActive = true;
    }

    protected override void CheckInput()
    {
        direction = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Horizontal")) 
        {
            Run();
        }
    }
}
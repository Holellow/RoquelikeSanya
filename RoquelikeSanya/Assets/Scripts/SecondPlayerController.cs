using UnityEngine;


public class SecondPlayerController : PlayerUnit
{
     protected override void CheckInput()
    {
        direction = Input.GetAxisRaw("Horizontal");
        if (Input.GetButton("Horizontal")) 
        {
            Run();
        }
    }

}

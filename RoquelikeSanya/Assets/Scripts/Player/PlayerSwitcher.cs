using Player;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    [SerializeField] private PlayerUnit FirstPlayer;
    [SerializeField] private PlayerUnit SecondPlayer;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {

            SecondPlayer.IsActive = !SecondPlayer.IsActive;
            SecondPlayer.GetComponent<JumpScript>().enabled = !SecondPlayer.GetComponent<JumpScript>().enabled;
            
            
            FirstPlayer.GetComponent<JumpScript>().enabled = !FirstPlayer.GetComponent<JumpScript>().enabled;
            FirstPlayer.IsActive = !FirstPlayer.IsActive;
        }
    }
}

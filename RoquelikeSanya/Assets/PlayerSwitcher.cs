using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    [SerializeField] private PlayerUnit FirstPlayer;
    [SerializeField] private PlayerUnit SecondPlayer;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {

            SecondPlayer.isActive = !SecondPlayer.isActive;
            SecondPlayer.GetComponent<JumpScript>().enabled = !SecondPlayer.GetComponent<JumpScript>().enabled;
            
            
            FirstPlayer.GetComponent<JumpScript>().enabled = !FirstPlayer.GetComponent<JumpScript>().enabled;
            FirstPlayer.isActive = !FirstPlayer.isActive;
        }
    }
}

using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    [SerializeField] private FirstPlayerController FirstPlayer;
    [SerializeField] private SecondPlayerController SecondPlayer;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            FirstPlayer.isActive = !FirstPlayer.isActive;
            SecondPlayer.isActive = !SecondPlayer.isActive;
        }
    }
}

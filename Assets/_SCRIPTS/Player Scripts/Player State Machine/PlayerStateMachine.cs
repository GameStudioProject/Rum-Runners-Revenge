using UnityEngine;


public class PlayerStateMachine
{
    public PlayerStates PlayerCurrentState { get; private set; }

    public void InitializeStateMachine(PlayerStates playerStartingState)
    {
        PlayerCurrentState = playerStartingState;
        PlayerCurrentState.StateEnter();
    }

    public void ChangePlayerState(PlayerStates newPlayerState)
    {
        PlayerCurrentState.StateExit();
        PlayerCurrentState = newPlayerState;
        PlayerCurrentState.StateEnter();
    }
}

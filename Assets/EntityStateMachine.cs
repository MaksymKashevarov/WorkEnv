using UnityEngine;

public class EntityStateMachine : MonoBehaviour
{
    private EntityBaseState _currentState;

    public void ChangeState(EntityBaseState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
    }

    public void Update()
    {
        _currentState?.Update();
    }
}

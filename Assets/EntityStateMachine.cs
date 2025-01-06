using UnityEngine;

public class EntityStateMachine : MonoBehaviour
{
    private EntityBaseState _currentState;
    private EntityBaseState _previousState;
    public Vector3 LastDirection { get; set; }
    public Vector3 LastOrigin { get; set; }

    public void ChangeState(EntityBaseState newState)
    {
        _previousState = _currentState;
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
        Debug.Log("State Switched to " + newState);
    }

    public void Update()
    {
        _currentState?.Update();
    }

    public void ReturnToPreviousState()
    {
        if (_previousState != null)
        {
            ChangeState(_previousState);
        }
    }
}

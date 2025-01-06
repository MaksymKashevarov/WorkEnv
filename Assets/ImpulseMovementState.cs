using UnityEngine;

public class ImpulseMovementState : EntityBaseState
{
    private Rigidbody rb;
    private Vector3 impulseDirection;
    private float impulseForce;

    public ImpulseMovementState(Rigidbody rb, Vector3 impulseDirection,float impulseForce)
    {
        this.rb = rb;
        this.impulseDirection = impulseDirection;
        this.impulseForce = impulseForce;
    }

    public bool isMoving()
    {
        return rb.linearVelocity.magnitude > 0.1f;
    }

    public override void Enter()
    {
        rb.AddForce(impulseDirection * impulseForce, ForceMode.Impulse);
        Debug.Log("State Switched!");
    }

    public override void Update()
    {

    }

    public override void Exit()
    {

    }
}

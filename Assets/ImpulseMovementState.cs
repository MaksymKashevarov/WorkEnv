using UnityEngine;

public class ImpulseMovementState : EntityBaseState
{
    private EntityStateMachine stateMachine;
    private Rigidbody rb;
    private Vector3 impulseDirection;
    private float impulseForce;
    private Vector3 origin;
    private Vector3 direction = Vector3.right;
    private RaycastHit hit;
    private float maxDistance = 2f;


    public ImpulseMovementState(Rigidbody rb, Vector3 impulseDirection, float impulseForce, Vector3 origin, Vector3 direction)
    {
        this.rb = rb;
        this.impulseDirection = impulseDirection;
        this.impulseForce = impulseForce;
        this.origin = origin;
        this.direction = direction;
    }

    private bool isFacingObstacle()
    {
        origin = rb.position + Vector3.up * 0.1f;
        direction = rb.linearVelocity.normalized;
        Debug.DrawRay(origin, direction * maxDistance, Color.red);
        if (Physics.Raycast(origin, direction, out hit, maxDistance))
        {
            return true;
        }
        return false;
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
        if (isFacingObstacle()) Debug.Log("Obstacle detected!");


    }

    public override void Exit()
    {

    }
}

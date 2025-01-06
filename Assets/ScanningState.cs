using UnityEngine;

public class ScanningState : EntityBaseState
{
    private EntityStateMachine stateMachine;
    private Vector3 origin;
    private Vector3 direction;
    private Rigidbody rb;
    private float scanRange;
    private float rotationSpeed;

    public ScanningState(EntityStateMachine stateMachine, Rigidbody rb, float scanRange, float rotationSpeed)
    {
        this.stateMachine = stateMachine;
        this.rb = rb;
        origin = stateMachine.LastOrigin;
        direction = stateMachine.LastDirection;
        this.scanRange = scanRange;
        this.rotationSpeed = rotationSpeed;
    }

    public void rotate()
    {
        direction = Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0) * direction;
    }

    public bool isLookingAtObstacle()
    {
        Vector3 scanOrigin = origin + Vector3.up * 0.5f;
        Debug.DrawRay(scanOrigin, direction * scanRange, Color.blue);

        if (Physics.Raycast(scanOrigin, direction, out RaycastHit hit, scanRange))
            return true;

        return false;
           
    }

    public override void Enter() 
    {
        Debug.Log("Scanning!");
    }

    public override void Update()
    {
        if (!isLookingAtObstacle()) 
        {            
            stateMachine.ReturnToPreviousState();
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
            rotate();
        }
    }

    public override void Exit() { }
}

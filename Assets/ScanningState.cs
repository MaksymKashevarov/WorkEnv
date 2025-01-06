using System;
using UnityEngine;
[Serializable]

public class ScanningState : EntityBaseState
{
    private EntityStateMachine stateMachine;
    private Vector3 origin;
    private Vector3 direction;
    private Rigidbody rb;
    private float scanRange;
    [SerializeField] private float rotationSpeed;
    private float time = 1;

    public ScanningState(EntityStateMachine stateMachine, Rigidbody rb, float scanRange, float rotationSpeed)
    {
        this.stateMachine = stateMachine;
        this.rb = rb;
        origin = stateMachine.LastOrigin;
        direction = stateMachine.LastDirection;
        this.scanRange = scanRange;
        this.rotationSpeed = rotationSpeed;
    }

    private void Decelerate()
    {
        if (rb.linearVelocity.magnitude != 0)
        {
            Vector3 deceleration = rb.linearVelocity.normalized * (time * Time.deltaTime);
            rb.linearVelocity -= deceleration;
            if (rb.linearVelocity.magnitude < 0)
            {
                rb.linearVelocity = Vector3.zero;
            }
        }
    }
    private bool isNotMoving()
    {
        return rb.linearVelocity.magnitude < 0.1f;
    }

    private void Rotate()
    {
        float rotationStep = rotationSpeed * Time.deltaTime;
        rb.transform.Rotate(0, rotationStep, 0); 
    }


    public override void Enter() 
    {
        Debug.Log("Scanning!");
        
    }

    public override void Update()
    {
        Decelerate();
        if(isNotMoving())
            Rotate();

    }

    public override void Exit() { }
}

using Unity.VisualScripting;
using UnityEngine;

public class AriaBall : MonoBehaviour
{
    [Header("Entity Data Settings")]
    [SerializeField] private string entityName = "Aria";
    [Header("Entity Engine Components")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private EntityStateMachine stateMachine;
    [Header("Entity Movement Settings")]
    [SerializeField] private Vector3 impulseDirection = Vector3.forward;
    [SerializeField] private float impulseForce = 1.0f;

    private void Start()
    {
        GetComponent<Rigidbody>();
        if (rb != null)
        {           
            Debug.Log("RigidBody Installed!");
        }
        Move();
    }

    private void Move()
    {
        Vector3 origin = transform.position;
        Vector3 direction = impulseDirection;

        stateMachine.ChangeState(new ImpulseMovementState(stateMachine, rb, impulseDirection, impulseForce, origin, direction));
    }

}

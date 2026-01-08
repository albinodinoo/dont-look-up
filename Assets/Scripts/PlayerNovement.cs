using UnityEngine;

public class PlayerNovement : MonoBehaviour
{
    [Header("Movement")]
    public float MoveSpeed;

    [Header("Drag")]
    public float GroundDrag;

    public Transform Orientation;
    private float HorizonTalInput;
    private float VerticalInput;

    Vector3 MoveDirection;
    Rigidbody Rb;
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizonTalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        MoveDirection = Orientation.forward * VerticalInput + Orientation.right * HorizonTalInput;
        Rb.AddForce(MoveDirection.normalized * MoveSpeed * 1f, ForceMode.Force);
        Rb.linearDamping = GroundDrag;
    }

}

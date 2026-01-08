using UnityEngine;

public class Billboard : MonoBehaviour 
{
    [SerializeField] private BillboardType BillType;
    [SerializeField] private bool LockXRotation;
    [SerializeField] private bool LockYRotation;
    [SerializeField] private bool LockZRotation;

    public enum BillboardType{LookAtCamara, CamaraForward};

    private Vector3 OriginalRotation;

    void Start()
    {
        OriginalRotation = transform.rotation.eulerAngles;
    }

    void LateUpdate()
    {
        switch (BillType)
        {
            case BillboardType.LookAtCamara:
            transform.LookAt(Camera.main.transform.position, Vector3.up);
            break;
            case BillboardType.CamaraForward:
            transform.forward = Camera.main.transform.forward;
            break;
            default:
            break;

        }

        Vector3 Rotation = transform.rotation.eulerAngles;
        if (LockXRotation)
        {
            Rotation.x = OriginalRotation.x;
        }
        if (LockYRotation)
        {
            Rotation.y = OriginalRotation.y;
        }
        if (LockZRotation)
        {
            Rotation.z = OriginalRotation.z;
        }
        transform.rotation = Quaternion.Euler(Rotation);
    }
}

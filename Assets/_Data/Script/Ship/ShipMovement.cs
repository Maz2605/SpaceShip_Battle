using UnityEngine;

public class ShipMovement : MazMonoBehavior
{
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float shipSpeed = 0.01f;
    private void Update()
    {
        this.Moving();
    }
    private void LookAtTarget()
    {
        var parent = transform.parent;
        Vector3 diff = this.targetPosition - parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
    private void GetTargetPos()
    {
        this.targetPosition = InputManager.Instance.mouseWorldPos;
        this.targetPosition.z = 0;
    }
    private void Moving()
    {
        GetTargetPos();
        LookAtTarget();
        var parent = transform.parent;
        Vector3 newPos = Vector3.Lerp(parent.position, targetPosition, this.shipSpeed);
        parent.position = newPos;
    }
}

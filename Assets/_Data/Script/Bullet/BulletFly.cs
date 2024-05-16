
using UnityEngine;

public class BulletFly : MazMonoBehavior
{
    [SerializeField] private int bulletSpeed = 10;
    [SerializeField] Vector3 bulletDirection = Vector3.right;
    protected void FixedUpdate()
    {
        var parent = transform.parent;
        parent.Translate(this.bulletDirection * this.bulletSpeed * Time.deltaTime);
    }
}

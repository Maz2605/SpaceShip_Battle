using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : MazMonoBehavior
{
    [SerializeField] protected float moveSpeed = 0f;
    [SerializeField] Vector3 bulletDirection = Vector3.right;
    protected void FixedUpdate()
    {
        var parent = transform.parent;
        parent.Translate(this.bulletDirection * this.moveSpeed * Time.deltaTime);
    }
}


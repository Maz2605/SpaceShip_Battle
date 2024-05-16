using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : MazMonoBehavior
{
    protected void Update()
    {
        this.Despawning();
    }
    protected void Despawning()
    {
        if (!CanDespwan()) return;
        this.DespawnObj();  
    }
    protected virtual void DespawnObj()
    {
        Destroy(transform.parent.gameObject);
        Debug.Log("Despawned");
    }
    protected abstract bool CanDespwan();

}

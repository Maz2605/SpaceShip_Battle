using System.Collections.Generic;

using UnityEngine;

public abstract class Spawner : MazMonoBehavior
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;

    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }
    protected void LoadHolder() 
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }
    protected void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach(Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();

        Debug.Log(transform.name + ": LoadPrefab", gameObject);
    }

    protected void HidePrefabs()
    {
        foreach(Transform prefabs in this.prefabs)
        {
            prefabs.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 swanPos, Quaternion rolation)
    {
        Transform prefab = this.GetPrebfabByName(prefabName);
        if(prefab == null)
        {
            Debug.LogWarning("Prefab is not found: " + prefabName);
            return null;
        }

        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(swanPos, rolation);

        newPrefab.parent = this.holder;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach(Transform poolObj in this.poolObjs)
        {
            if(poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    


    protected virtual Transform GetPrebfabByName(string prefabName)
    {
        foreach(Transform prefab in prefabs)
        {
            if (prefab.name == prefabName)
                return prefab;
        }
        return null;
    }
}

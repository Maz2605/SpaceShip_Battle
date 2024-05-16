using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    protected static JunkSpawner instance;
    public static JunkSpawner Instance { get => instance; }
    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 JunkSpawner allow to exit");
        JunkSpawner.instance = this;
    }
}

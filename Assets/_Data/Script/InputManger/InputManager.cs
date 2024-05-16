using UnityEngine;

public class InputManager : MazMonoBehavior
{
    protected static InputManager instance;
    public static InputManager Instance { get => instance; }
    [SerializeField] public Vector3 mouseWorldPos;
    //private float onFiring = 0;
    public bool OnFiring { get => GetFire(); }
    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only one InputManager allow to exist");
        InputManager.instance = this;
    }
    protected void Update()
    {
        this.GetFire();
    }
    protected void FixedUpdate()
    {
        this.GetMousePos();
    }
    
    protected bool GetFire()
    {
        if (Input.GetKey(KeyCode.F)||Input.GetKey(KeyCode.Space)) 
            return true;
        if (Input.GetAxis("Fire1") == 1) 
            return true;
        return false;
    }

    protected void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
}

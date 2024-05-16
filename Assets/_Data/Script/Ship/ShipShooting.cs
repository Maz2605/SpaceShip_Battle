using UnityEngine;

public class ShipShooting : MazMonoBehavior
{
    [SerializeField] private float shootDelay = 0.09f;
    [SerializeField] private float shootTimer = 0f;
    [SerializeField] private Transform bulletPrefab;
    protected static string bulletName = "Bullet_2";
    protected bool isShooting = false;

    private void Update()
    {
        this.IsShooting();
        this.Shooting();        
    }
    protected bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == true;
        return isShooting;
    }
    protected void Shooting()
    {
        if (!isShooting) return;

        this.shootTimer += Time.deltaTime;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0f;

        Vector3 swanPos = transform.position;
        Quaternion rolation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(bulletName, swanPos, rolation);
        
        if (newBullet == null) 
            return;
        
        newBullet.gameObject.SetActive(true);
        Debug.Log("Shooting");
    }
}

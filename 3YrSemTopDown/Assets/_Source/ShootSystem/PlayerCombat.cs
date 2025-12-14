using Core.ObjectPool;
using UnityEngine;

public class PlayerCombat
{
    private IObjectPool<Bullet> _bulletPool;

    public void Construct(IObjectPool<Bullet> bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public void Shoot(Camera worldCamera,
        Transform aimTransform,
        float bulletSpeed)
    {
        Vector3 mouseWorldPos = worldCamera.ScreenToWorldPoint(Input.mousePosition);

        //float defaultRotZ = bulletPrefab.transform.rotation.eulerAngles.z;

        Bullet bullet = _bulletPool.GetFromPool();
        bullet.transform.position = aimTransform.position;

        float defaultRotZ = bullet.transform.rotation.z;

        //GameObject bulletInstance = Object.Instantiate(bulletPrefab, aimTransform.position, Quaternion.identity);
        Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();
        //Bullet bullet = bulletInstance.GetComponent<Bullet>();

        Vector3 bulletDirection = (mouseWorldPos - aimTransform.position);
        Vector3 bulletRotation = (aimTransform.position - mouseWorldPos);

        rb2D.linearVelocity = new Vector2 (bulletDirection.x, bulletDirection.y).normalized * bulletSpeed;
        float rotZ = Mathf.Atan2(bulletRotation.y, bulletRotation.x) * Mathf.Rad2Deg;

        bullet.transform.rotation = Quaternion.Euler(0, 0, rotZ + defaultRotZ);
    }
}

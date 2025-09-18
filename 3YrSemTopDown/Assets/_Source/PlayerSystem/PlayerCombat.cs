using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat
{
    //public void ShootDirection(Vector3 mouseScreenPos, Camera worldCamera, Transform playerTransform, Transform aimTransform)
    //{
    //    Vector3 mouseWorldPos = worldCamera.ScreenToWorldPoint(mouseScreenPos);
    //    Vector3 aimDirection = (mouseWorldPos - playerTransform.position).normalized;
    //    float rotZ = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
    //    aimTransform.rotation = Quaternion.Euler(0, 0, rotZ);
    //}

    public void Shoot(GameObject bulletPrefab,
                           Camera worldCamera,
                       Transform aimTransform,
                            float bulletSpeed,
                         float bulletLifeTime, 
                         float bulletDamage)
    {
        Vector3 mouseWorldPos = worldCamera.ScreenToWorldPoint(Input.mousePosition);

        float defaultRotZ = bulletPrefab.transform.rotation.eulerAngles.z;

        GameObject bulletGameObject = Object.Instantiate(bulletPrefab, aimTransform.position, Quaternion.identity);
        Rigidbody2D rb2D = bulletGameObject.GetComponent<Rigidbody2D>();
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();

        bullet.Construct(bulletLifeTime, bulletDamage);

        Vector3 bulletDirection = (mouseWorldPos - aimTransform.position);
        Vector3 bulletRotation = (aimTransform.position - mouseWorldPos);

        rb2D.linearVelocity = new Vector2 (bulletDirection.x, bulletDirection.y).normalized * bulletSpeed;
        float rotZ = Mathf.Atan2(bulletRotation.y, bulletRotation.x) * Mathf.Rad2Deg;

        bulletGameObject.transform.rotation = Quaternion.Euler(0, 0, rotZ + defaultRotZ);
    }
}

using UnityEngine;

public class PlayerCombat
{
    public void ShootDirection(Vector3 mouseScreenPos, Camera worldCamera, Transform playerTransform)
    {
        Vector3 mouseWorldPos = worldCamera.ScreenToWorldPoint(mouseScreenPos);
        Vector3 aimDirection = (mouseWorldPos - playerTransform.position).normalized;
        float rotZ = Mathf.Atan2(aimDirection.x, aimDirection.y) * Mathf.Rad2Deg;
        playerTransform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    public void Shoot(GameObject bulletPrefab)
    {
        Debug.Log("Took a shot");
        //TODO: Shooting
    }
}

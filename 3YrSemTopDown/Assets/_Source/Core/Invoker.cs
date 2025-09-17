using Unity.VisualScripting;
using UnityEngine;

public class Invoker
{
    private PlayerMovement _playerMovement;
    private PlayerData _playerData;
    private PlayerCombat _playerCombat;
    private Ammo _playerAmmo;

    public Invoker(PlayerMovement playerMovement,
                   PlayerData playerData,
                   PlayerCombat playerCombat,
                   Ammo playerAmmo)
    {
        _playerMovement = playerMovement;
        _playerData = playerData;
        _playerCombat = playerCombat;
        _playerAmmo = playerAmmo;
    }

    public void InvokeMove(Vector2 movement2D)
    {
        _playerMovement.Move(_playerData.Rb2D,
                                   movement2D,
                             _playerData.MoveSpeed);
    }

    //public void InvokeShootDirection(Vector3 mousePosition)
    //{
    //    _playerCombat.ShootDirection(mousePosition, Camera.main, _playerData.transform, _playerData.AimTransform);
    //}
    
    public void InvokeReload()
    {

    }

    public void InvokeShoot()
    {
        if (_playerAmmo.IsReadyToShoot())
        {
            _playerCombat.Shoot(_playerData.BulletPrefab,
                                         Camera.main,
                                         _playerData.AimTransform,
                                         _playerData.BulletSpeed,
                                         _playerData.BulletLifeTime);
        }
    }
}

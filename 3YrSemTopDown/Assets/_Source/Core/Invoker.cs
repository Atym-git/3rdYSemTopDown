using Unity.VisualScripting;
using UnityEngine;

public class Invoker
{
    private PlayerMovement _playerMovement;
    private PlayerData _playerData;
    private PlayerCombat _playerCombat;

    public Invoker(PlayerMovement playerMovement, PlayerData playerData, PlayerCombat playerCombat)
    {
        _playerMovement = playerMovement;
        _playerData = playerData;
        _playerCombat = playerCombat;
    }

    public void InvokeMove(Vector2 movement2D)
    {
        _playerMovement.Move(_playerData.Rb2D, movement2D, _playerData.MoveSpeed);
    }

    public void InvokeShootDirection(Vector3 mousePosition)
    {
        _playerCombat.ShootDirection(mousePosition, Camera.main, _playerData.transform);
    }
    
    public void InvokeShoot()
    {
        _playerCombat.Shoot(_playerData.BulletPrefab);
    }
}

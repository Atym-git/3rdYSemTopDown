using UnityEngine;

public class BootStrapper : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private InputListener inputListener;
    [SerializeField] private CoroutineRunner coroutineRunner;

    private PlayerMovement _playerMovement;
    private PlayerCombat _playerCombat;
    private Ammo _playerAmmo;
    private PlayerUI _playerUI;

    private Invoker _invoker;

    private void Awake()
    {
        _playerMovement = new PlayerMovement();
        _playerCombat = new PlayerCombat();
        _playerUI = new PlayerUI();
        _playerAmmo = new Ammo(playerData.BulletsAmount,
                               playerData.ClipSize,
                               playerData.ReloadTime,
                               playerData.AmmoTMP,
                               _playerUI,
                               coroutineRunner);

        _invoker = new Invoker(_playerMovement, playerData, _playerCombat, _playerAmmo);

        inputListener.Construct(_invoker);
    }
}

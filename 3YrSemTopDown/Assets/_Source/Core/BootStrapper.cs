using UnityEngine;
using UnityEngine.UI;

public class BootStrapper : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private InputListener inputListener;
    [SerializeField] private CoroutineRunner coroutineRunner;
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private Consumable consumable;

    [SerializeField] private Transform enemyRootsParent;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private Image settingsPanel;

    private PlayerMovement _playerMovement;
    private PlayerHealth _playerHealth;
    private PlayerCombat _playerCombat;
    private Ammo _playerAmmo;
    private PlayerUI _playerUI;

    private EnemyHealth _enemyHealth;

    private ResourceLoader _resourceLoader;
    private EnemyFabric _enemyFabric;
    private Pause _pause;
    private Invoker _invoker;

    private void Awake()
    {
        _playerMovement = new();
        _playerCombat = new();
        _playerUI = new();
        _playerHealth = new PlayerHealth(playerData.PlayerHealth, playerData.HealthTMP, playerData.RevivePanel, _pause);

        _enemyHealth = new();

        _pause = new Pause(settingsPanel);

        _playerAmmo = new Ammo(playerData.BulletsAmount,
                               playerData.ClipSize,
                               playerData.ReloadTime,
                               playerData.AmmoTMP,
                               _playerUI,
                               coroutineRunner);

        _invoker = new Invoker(_playerMovement, playerData, _playerCombat, _playerAmmo);

        inputListener.Construct(_invoker, _pause);
        consumable.Construct(_playerAmmo);

        _enemyFabric = new EnemyFabric(enemyPrefab, enemyRootsParent);
        _resourceLoader = new ResourceLoader(_enemyFabric);
        
    }
}

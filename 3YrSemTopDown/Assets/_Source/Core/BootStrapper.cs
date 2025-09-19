using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BootStrapper : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private InputListener inputListener;
    [SerializeField] private CoroutineRunner coroutineRunner;
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private List<Consumable> consumables = new();
    //ToDo: make the consumables fabric

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

        _enemyHealth = new();

        _pause = new Pause(settingsPanel);

        _playerHealth = new PlayerHealth(playerData.PlayerHealth, playerData.HealthTMP, playerData.RevivePanel, _pause);

        _playerAmmo = new Ammo(playerData.BulletsAmount,
                               playerData.ClipSize,
                               playerData.ReloadTime,
                               playerData.AmmoTMP,
                               _playerUI,
                               coroutineRunner);

        _invoker = new Invoker(_playerMovement, playerData, _playerCombat, _playerAmmo);

        inputListener.Construct(_invoker, _pause, _playerHealth);
        
        _enemyFabric = new EnemyFabric(enemyPrefab, enemyRootsParent, _playerHealth);
        _resourceLoader = new ResourceLoader(_enemyFabric);

        for (int i = 0; i < consumables.Count; i++)
        {
            consumables[i].Construct(_playerAmmo);
        }
    }
}

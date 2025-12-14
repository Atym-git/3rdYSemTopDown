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

    private void Awake()
    {
        Pause pause = new Pause(settingsPanel);

        #region PlayerInstaller
        PlayerMovement playerMovement = new();
        PlayerCombat playerCombat = new();
        PlayerUI playerUI = new();

        PlayerHealth playerHealth = new PlayerHealth(playerData.PlayerHealth, playerData.HealthTMP, playerData.RevivePanel, pause);

        Ammo playerAmmo = new Ammo(playerData.BulletsAmount,
                               playerData.ClipSize,
                               playerData.ReloadTime,
                               playerData.AmmoTMP,
                               playerUI,
                               coroutineRunner);

        #endregion

        #region EnemyInstaller

        EnemyHealth _enemyHealth = new();

        EnemyFabric enemyFabric = new EnemyFabric(enemyPrefab, enemyRootsParent, playerHealth);

        #endregion

        Invoker invoker = new Invoker(playerMovement, playerData, playerCombat, playerAmmo);

        ResourceLoader resourceLoader = new ResourceLoader(enemyFabric);

        inputListener.Construct(invoker, pause, playerHealth);

        #region ConsumablesInstaller

        for (int i = 0; i < consumables.Count; i++)
        {
            consumables[i].Construct(playerAmmo);
        }

        #endregion

        #region BulletPool

        BulletPoolSettings bulletPoolSettings = resourceLoader.LoadBulletPoolSettings();
        bulletPoolSettings.Construct(playerData.BulletPrefab);

        BulletFactory bulletFactory = new BulletFactory(bulletPoolSettings);

        BulletPool bulletPool = new BulletPool(bulletPoolSettings, bulletFactory);

        playerCombat.Construct(bulletPool);
        #endregion
    }
}

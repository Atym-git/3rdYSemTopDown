using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ResourceLoader
{
    private EnemyFabric _enemyFabric;

    private const string ENEMY_SO_PATH = "SO/EnemySO";

    public ResourceLoader(EnemyFabric enemyFabric)
    {
        _enemyFabric = enemyFabric;

        _enemyFabric.InstantiateEnemy(LoadEnemySO());
    }

    //SO/EnemySO
    private EnemySO[] LoadEnemySO()
    {
        EnemySO[] enemySOs = Resources.LoadAll(ENEMY_SO_PATH, typeof(EnemySO))
            .Cast<EnemySO>()
            .ToArray();
        return enemySOs;
    }

    public BulletPoolSettings LoadBulletPoolSettings()
    {
        BulletPoolSettings[] settingsArray = Resources.LoadAll("SO/BulletPoolSO", typeof(BulletPoolSettings))
            .Cast<BulletPoolSettings>()
            .ToArray();
        if (settingsArray.Length == 1)
        {
            BulletPoolSettings settings = settingsArray[0];
            return settings;
        }
        Debug.LogWarning("Bullet pool settings instances aren't 1");
        return null;
    }
}

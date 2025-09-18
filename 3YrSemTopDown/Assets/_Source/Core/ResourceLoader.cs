using System.Linq;
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
}

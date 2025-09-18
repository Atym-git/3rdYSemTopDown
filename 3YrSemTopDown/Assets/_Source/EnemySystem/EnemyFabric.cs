using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Collections.Generic;

public class EnemyFabric
{
    private GameObject _enemyPrefab;
    private Transform _enemyRootsParent;
    //private List<Transform> _enemyRoots = new();

    //private Sprite _enemySprite;
    //private float _enemyMoveSpeed;

    public EnemyFabric(GameObject enemyPrefab, Transform enemyRootsParent)
    {
        _enemyPrefab = enemyPrefab;
        _enemyRootsParent = enemyRootsParent;
    }

    public void InstantiateEnemy(EnemySO[] enemySOs)
    {
        if (_enemyRootsParent != null)
        {
            for (int i = 0; i < _enemyRootsParent.childCount; i++)
            {
                GameObject enemyInstance = UnityEngine.Object.Instantiate(_enemyPrefab, _enemyRootsParent.GetChild(i));
                EnemyData enemy = enemyInstance.GetComponent<EnemyData>();
                int enemySOIndex = UnityEngine.Random.Range(0, enemySOs.Length);
                enemy.Construct(enemySOs[enemySOIndex].EnemySprite,
                                         enemySOs[enemySOIndex].EnemyMoveSpeed,
                                         enemySOs[enemySOIndex].EnemyHealth);
            }
        }
        else
        {
            Debug.Log($"_enemyRoots = null; Check your code!");
        }
    }
}

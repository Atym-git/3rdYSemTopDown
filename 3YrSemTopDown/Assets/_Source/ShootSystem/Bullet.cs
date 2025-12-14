using Core.ObjectPool;
using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, IObjectPoolItem<Bullet>
{
    [SerializeField] private LayerMask enemyLayerMask;

    [SerializeField] private float _bulletLifeTime;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDamage;

    public event Action<Bullet> OnObjectLifeEndRequest;

    private void OnEnable() => StartCoroutine(DestroyingCoroutine(_bulletLifeTime));

    private void OnDestroy() => OnObjectLifeEndRequest = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(enemyLayerMask, collision.gameObject))
        {
            EnemyData enemyData = collision.GetComponent<EnemyData>();
            EnemyHealth.TakeDamage(_bulletDamage, enemyData);
            OnObjectLifeEndRequest = null;
        }
    }

    private IEnumerator DestroyingCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        OnObjectLifeEndRequest?.Invoke(this);
        OnObjectLifeEndRequest = null;
        gameObject.SetActive(false);
    }

    
}

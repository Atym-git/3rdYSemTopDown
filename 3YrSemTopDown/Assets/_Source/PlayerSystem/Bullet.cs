using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayerMask;

    private float _bulletLifeTime;
    private float _bulletSpeed;
    private float _bulletDamage;

    public void Construct(float bulletLifeTime, float bulletDamage)
    {
        _bulletLifeTime = bulletLifeTime;
        _bulletDamage = bulletDamage;
        SelfDestruct();
    }

    private void OnEnable()
    {
        //ToDo: probably change destroy to objects pool
    }

    private void SelfDestruct()
    {
        Destroy(gameObject, _bulletLifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(enemyLayerMask, collision.gameObject))
        {
            EnemyData enemyData = collision.GetComponent<EnemyData>();
            EnemyHealth.TakeDamage(_bulletDamage, enemyData);
            Destroy(gameObject);
        }
    }
}

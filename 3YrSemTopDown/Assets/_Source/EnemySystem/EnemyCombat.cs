using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayerMask;

    private PlayerHealth _playerHealth;

    private float _enemyDamage;

    public void Construct(PlayerHealth playerHealth, float enemyDamage)
    {
        _playerHealth = playerHealth;
        _enemyDamage = enemyDamage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(playerLayerMask, collision.gameObject))
        {
            Debug.Log("Player health" + _playerHealth);
            _playerHealth.TakeDamage(_enemyDamage);
        }
    }
}

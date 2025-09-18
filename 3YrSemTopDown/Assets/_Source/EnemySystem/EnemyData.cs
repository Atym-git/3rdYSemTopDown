using UnityEngine;
using UnityEngineInternal;

public class EnemyData : MonoBehaviour
{
    private Sprite _enemySprite;
    private float _enemySpeed;
    private float _enemyHealth;
    private float _enemyDamage;

    [field: SerializeField]
    public float EnemyCurrHealth { get; set; }

    [SerializeField] private EnemyChaseTrigger enemyChaseTrigger;

    [SerializeField] private EnemyCombat enemyCombat;

    private PlayerHealth _playerHealth;

    public void Construct(Sprite enemySprite, float enemySpeed, float enemyHealth, float enemyDamage, PlayerHealth playerHealth)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = enemySprite;
        _enemySpeed = enemySpeed;
        _enemyHealth = enemyHealth;
        _enemyDamage = enemyDamage;

        _playerHealth = playerHealth;
        
        EnemyCurrHealth = _enemyHealth;

        Debug.Log("Player health" + _playerHealth);

        enemyChaseTrigger.Construct(enemySpeed);
        enemyCombat.Construct(_playerHealth, _enemyDamage);
    }

    //[field: SerializeField]
    //public GameObject EnemyPrefab { get; private set; }

    //[field: SerializeField]
    //public Transform EnemyRootsParent { get; private set; }
}

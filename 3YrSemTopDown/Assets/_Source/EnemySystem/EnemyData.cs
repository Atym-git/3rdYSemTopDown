using UnityEngine;
using UnityEngineInternal;

public class EnemyData : MonoBehaviour
{
    private Sprite _enemySprite;
    private float _enemySpeed;
    private float _enemyHealth;

    [field: SerializeField]
    public float EnemyCurrHealth { get; set; }

    [SerializeField] private EnemyChaseTrigger enemyChaseTrigger;

    public void Construct(Sprite enemySprite, float enemySpeed, float enemyHealth)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = enemySprite;
        _enemySpeed = enemySpeed;
        _enemyHealth = enemyHealth;
        EnemyCurrHealth = _enemyHealth;

        enemyChaseTrigger.Construct(enemySpeed);
    }

    

    //[field: SerializeField]
    //public GameObject EnemyPrefab { get; private set; }

    //[field: SerializeField]
    //public Transform EnemyRootsParent { get; private set; }
}

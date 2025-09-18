using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO",
 menuName = "SO/Enemy/New Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField]
    public Sprite EnemySprite { get; private set; }
    
    [field: SerializeField]
    public float EnemyMoveSpeed { get; private set; }
    
    [field: SerializeField]
    public float EnemyHealth { get; private set; }
    
    [field: SerializeField]
    public float EnemyDamage { get; private set; }
    
}

using UnityEngine;

//[CreateAssetMenu(fileName = "CustomerSO",
//menuName = "SO/Customer/New Customer")]
//
[CreateAssetMenu(fileName = "EnemySO",
 menuName = "SO/Enemy/New Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField]
    public Sprite EnemySprite { get; private set; }
    
    [field: SerializeField]
    public float MoveSpeed { get; private set; }
}

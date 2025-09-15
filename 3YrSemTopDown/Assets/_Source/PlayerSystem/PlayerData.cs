using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [field: SerializeField]
    public float MoveSpeed { get; private set; } = 5f;
    
    [field: SerializeField]
    public int ClipSize { get; private set; } = 15;
    
    [field: SerializeField]
    public int BulletsAmount { get; private set; } = 150;

    [field: SerializeField]
    public float BulletSpeed { get; private set; } = 5f;

    [field: SerializeField]
    public float BulletLifeTime { get; private set; } = 3.5f;

    [field: SerializeField]
    public Rigidbody2D Rb2D { get; private set; }

    [field: SerializeField]
    public GameObject BulletPrefab { get; private set; }

    [field: SerializeField]
    public Transform AimTransform { get; private set; }
}

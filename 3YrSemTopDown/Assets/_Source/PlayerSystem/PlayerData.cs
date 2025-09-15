using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [field: SerializeField]
    public float MoveSpeed { get; private set; } = 5f;

    [field: SerializeField]
    public Rigidbody2D Rb2D { get; private set; }

    [field: SerializeField]
    public GameObject BulletPrefab { get; private set; }
}

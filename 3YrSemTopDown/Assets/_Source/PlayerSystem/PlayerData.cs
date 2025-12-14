using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    
    [field:Header("Physical stats")]

    [field: SerializeField]
    public float MoveSpeed { get; private set; } = 5f;
    
    [field: SerializeField]
    public float PlayerHealth { get; private set; } = 25f;

    [field:Header("Bullet Stats")]

    [field: SerializeField]
    public float BulletSpeed { get; private set; } = 5f;

    [field: SerializeField]
    public float BulletLifeTime { get; private set; } = 3.5f;
    
    [field: SerializeField]
    public float BulletDamage { get; private set; } = 3.5f;

    [field:Header("Ammo related")]

    [field: SerializeField]
    public int ClipSize { get; private set; } = 15;

    [field: SerializeField]
    public int BulletsAmount { get; private set; } = 150;
    
    [field: SerializeField]
    public float ReloadTime { get; private set; } = 3.5f;

    [field:Header("Not for GameDesigners stuff")]

    [field: SerializeField]
    public Rigidbody2D Rb2D { get; private set; }

    [field: SerializeField]
    public Bullet BulletPrefab { get; private set; }

    [field: SerializeField]
    public Transform AimTransform { get; private set; }

    [field: SerializeField]
    public TextMeshProUGUI AmmoTMP { get; private set; }

    [field: SerializeField]
    public TextMeshProUGUI HealthTMP { get; private set; }

    [field: SerializeField]
    public Image RevivePanel { get; private set; }
}

using UnityEngine;

[CreateAssetMenu(fileName = "BulletPoolSettings",
    menuName = "SO/Object Pool Data/New BulletPoolSettings")]
public class BulletPoolSettings : ScriptableObject
{
    [field: SerializeField]
    public Bullet BulletPrefab { get; private set; }

    [field: SerializeField]
    public int StartPoolCount { get; private set; }

    public void Construct(Bullet bulletPrefab)
    {
        if (BulletPrefab == null)
        {
            BulletPrefab = bulletPrefab;
        }
    }
}

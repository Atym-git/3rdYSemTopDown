using UnityEngine;

public class BulletPool : ObjectPool<Bullet>
{
    private readonly BulletPoolSettings _settings;
    private readonly BulletFactory _bulletFactory;

    public BulletPool(BulletPoolSettings settings, BulletFactory bulletFactory) : base(bulletFactory.Create)
    {
        _settings = settings;
        _bulletFactory = bulletFactory;

        Init();
    }

    private void Init()
    {
        for (var i = 0; i < _settings.StartPoolCount; i++)
            PutToPool(_bulletFactory.Create());
    }
}

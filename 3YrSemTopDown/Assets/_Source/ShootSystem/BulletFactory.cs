using UnityEngine;

public class BulletFactory
{
    private readonly BulletPoolSettings _settings;

    //[Inject]
    public BulletFactory(BulletPoolSettings settings) => _settings = settings;

    public Bullet Create()
    {
        return Object.Instantiate(_settings.BulletPrefab);
    }
}

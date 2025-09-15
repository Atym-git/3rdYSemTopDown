using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _bulletLifeTime;

    public void Construct(float bulletLifeTime)
    {
        _bulletLifeTime = bulletLifeTime;
    }

    private void OnEnable()
    {
        Destroy(gameObject, _bulletLifeTime);
        //ToDo: probably change destroy to objects pool
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ToDo: based on LayerMaskUtil check who got hit & call some voids
    }
}

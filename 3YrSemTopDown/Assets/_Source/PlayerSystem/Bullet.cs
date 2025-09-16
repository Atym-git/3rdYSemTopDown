using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _bulletLifeTime;

    public void Construct(float bulletLifeTime)
    {
        _bulletLifeTime = bulletLifeTime;
        SelfDestruct();
    }

    private void OnEnable()
    {
        
        //ToDo: probably change destroy to objects pool
    }

    private void SelfDestruct()
    {
        Destroy(gameObject, _bulletLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ToDo: based on LayerMaskUtil check who got hit & call some voids
    }
}

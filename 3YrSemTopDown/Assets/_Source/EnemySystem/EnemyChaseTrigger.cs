using UnityEngine;

public class EnemyChaseTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;

    private float _enemyMoveSpeed = 1;

    public void Construct(float enemyMoveSpeed)
    {
        _enemyMoveSpeed = enemyMoveSpeed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(playerLayer, collision.gameObject))
        {
            Rigidbody2D enemyRb = gameObject.GetComponentInParent<Rigidbody2D>();
            float xVelocity = collision.transform.position.x - transform.position.x;
            float yVelocity = collision.transform.position.y - transform.position.y;
            enemyRb.linearVelocity = new Vector2(xVelocity,
                                                 yVelocity) * _enemyMoveSpeed;
        }
    }
}

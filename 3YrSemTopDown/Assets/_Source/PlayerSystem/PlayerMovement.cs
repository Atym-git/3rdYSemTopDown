using UnityEngine;

public class PlayerMovement
{
    public void Move(Rigidbody2D rb2D, Vector2 movement, float moveSpeed)
    {
        rb2D.linearVelocity = new Vector2(movement.x, movement.y) * moveSpeed;
    }
}

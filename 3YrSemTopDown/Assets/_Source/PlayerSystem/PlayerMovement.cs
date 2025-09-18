using UnityEngine;

public class PlayerMovement
{
    public void Move(Rigidbody2D rb2D, Vector2 movement, float moveSpeed)
    {
        rb2D.linearVelocity = new Vector2(movement.x, movement.y) * moveSpeed;
    }

    private void FlipX(float movementX, SpriteRenderer playerSr)
    {
        if (movementX < 0)
        {
            playerSr.flipX = true;
        }
        else if (movementX > 0)
        {
            playerSr.flipX = false;
        }
        /*ToDo: When I'll get player animations
         * bool _animIdle = movementX == 0;
           bool _animWalking = movementX != 0;
           _animator.SetBool(_animIdleName, _animIdle);
           _animator.SetBool(_animWalkingName, _animWalking);
         */
    }
}

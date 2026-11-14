
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public Rigidbody2D rb;

    [Header("Animation")]
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector2 movement;
    private Vector2 lastDirection = Vector2.down;

    void Update()
    {
        // Đọc phím di chuyển
        movement = Vector2.zero;

        if (Keyboard.current != null)
        {
            movement.x =
                (Keyboard.current.dKey.isPressed ? 1 : 0) -
                (Keyboard.current.aKey.isPressed ? 1 : 0);

            movement.y =
                (Keyboard.current.wKey.isPressed ? 1 : 0) -
                (Keyboard.current.sKey.isPressed ? 1 : 0);
        }

        // Chuẩn hóa di chuyển
        movement = movement.normalized;

        // Lưu hướng cuối cùng
        if (movement != Vector2.zero)
        {
            lastDirection = movement;
        }

        // Lật nhân vật trái / phải
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        // Cập nhật Animator
        animator.SetFloat("Xinput", movement.x);
        animator.SetFloat("Yinput", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // Di chuyển Rigidbody2D
        rb.linearVelocity = movement * speed;
    }
}

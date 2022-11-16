using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask platform;
    Animator animator;
    Rigidbody2D rb;
    BoxCollider2D boxCollider;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        CheckForWalk();
        CheckForJump();
    }

    private void CheckForWalk()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = Input.acceleration.x * 6f;

        if (velocity.x > 0)
        {
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        rb.velocity = velocity;
        animator.SetFloat("Movement", velocity.sqrMagnitude);
    }

    private void CheckForJump()
    {
        Vector2 jumpVelocity = rb.velocity;

        if (Input.GetTouch(0).tapCount == 1 && PlayerIsGrounded())
        {
            jumpVelocity.y = 5f;
            animator.SetTrigger("Jump");
        }

        rb.velocity = jumpVelocity;
    }

    private bool PlayerIsGrounded()
    {
        float heightTest = .06f;
        RaycastHit2D raycast = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + heightTest, platform);
        return raycast.collider != null;
    }
}

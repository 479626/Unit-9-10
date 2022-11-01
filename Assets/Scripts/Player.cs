using System.Collections;
using System.Collections.Generic;
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
        CheckForInput();
    }

    private void CheckForInput()
    {
        Vector2 velocity = rb.velocity;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity.x = -3;
            gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
            print("Move attempt [" + velocity + "]");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity.x = 3;
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            print("Move attempt [" + velocity + "]");
        }

        if (Input.GetKeyDown(KeyCode.Space) && PlayerIsGrounded())
        {
            velocity.y = 3f;
            animator.SetTrigger("Jump");
            print("Move attempt [" + velocity + "]");
        }

        animator.SetFloat("Movement", velocity.x);
        rb.velocity = velocity;
    }

    private bool PlayerIsGrounded()
    {
        float heightTest = .06f;
        RaycastHit2D raycast = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + heightTest, platform);
        return raycast.collider != null;
    }
}

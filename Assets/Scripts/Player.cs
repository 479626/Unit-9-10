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

        #region PC Controls
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity.x = -3;
            gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity.x = 3;
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && PlayerIsGrounded())
        {
            velocity.y = 3f;
            animator.SetTrigger("Jump");
        }
        #endregion

        #region Gyroscopic Controls
        // UNTESTED
        velocity = new Vector2(Input.acceleration.x, Input.acceleration.y);
        #endregion

        #region Touch Controls
        Touch touch = Input.GetTouch(0);
        if (touch.tapCount == 1)
        {
            velocity.y = 3f;
            animator.SetTrigger("Jump");
        } 
        else if (touch.tapCount == 2)
        {
            velocity.y = 6f;
            animator.SetTrigger("Jump");
        }
        #endregion

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
